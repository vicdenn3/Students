using System;
using System.Windows.Forms;
using Ninject;
using Students.BusinessLogic;
using Students.DataAccessLayer;
using Students.Model;

namespace Students.View
{
    public partial class Form1 : Form
    {
        private readonly StudentService _service;
        private readonly IKernel _kernel;

        // Конструктор нужен дизайнеру WinForms — он его вызывает сам.
        // В рантайме используется конструктор ниже, куда зависимости приходят извне.
        public Form1() : this(null, null) { }

        public Form1(StudentService service, IKernel kernel)
        {
            InitializeComponent();
            _service = service;
            _kernel = kernel;

            if (_service != null)
            {
                UpdateTitle();
                RefreshList();
            }
        }

        private void UpdateTitle()
        {
            Text = $"Студенты (провайдер: {_service.GetCurrentProviderName()})";
            string nextProvider = _service.GetCurrentProviderName() == "EF Core" ? "Dapper" : "EF Core";
            buttonToggleMode.Text = $"Переключить на {nextProvider}";
        }

        private void RefreshList()
        {
            try
            {
                dataGridViewStudents.DataSource = null;
                dataGridViewStudents.DataSource = _service.GetAll();
                UpdateTitle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string firstName = textBoxFirstName.Text.Trim();
            string lastName = textBoxLastName.Text.Trim();
            string group = textBoxGroup.Text.Trim();

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(group))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            try
            {
                _service.Add(firstName, lastName, group);
                RefreshList();

                textBoxFirstName.Clear();
                textBoxLastName.Clear();
                textBoxGroup.Clear();

                MessageBox.Show($"Студент добавлен (провайдер: {_service.GetCurrentProviderName()})", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите строку для удаления!");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dataGridViewStudents.SelectedRows[0].Cells["Id"].Value);
                _service.Remove(id);
                RefreshList();

                MessageBox.Show($"Студент удалён (провайдер: {_service.GetCurrentProviderName()})", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления: " + ex.Message);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e) => RefreshList();

        private void buttonToggleMode_Click(object sender, EventArgs e)
        {
            try
            {
                // Новую реализацию репозитория просим у контейнера, а не создаём через new.
                bool usingEf = _service.GetCurrentProviderName() == "EF Core";

                // Новую реализацию репозитория просим у контейнера, а не создаём через new.
                _service.UseRepository(usingEf
                    ? _kernel.Get<DapperRepository>()
                    : _kernel.Get<IRepository<Student>>());

                RefreshList();
                MessageBox.Show($"Провайдер переключён на: {_service.GetCurrentProviderName()}", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка переключения провайдера: " + ex.Message);
            }
        }
    }
}
