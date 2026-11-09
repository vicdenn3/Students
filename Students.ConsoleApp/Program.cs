using System;
using Ninject;
using Students.BusinessLogic;
using Students.DataAccessLayer;
using Students.Model;

namespace Students.View.ConsoleApp
{
    internal class Program
    {
        // Точка входа = composition root: здесь создаётся контейнер,
        // а все зависимости он разрешает сам (см. SimpleConfigModule).
        private static IKernel _kernel;
        private static StudentService _service;

        static void Main(string[] args)
        {
            _kernel = new StandardKernel(new SimpleConfigModule());
            _service = _kernel.Get<StudentService>();

            _service.InitializeDatabase();

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"   СТУДЕНТЫ | Режим: {_service.GetCurrentProviderName()}");
                Console.WriteLine("1. Показать всех студентов");
                Console.WriteLine("2. Добавить студента");
                Console.WriteLine("3. Удалить студента");
                Console.WriteLine("4. Переключить провайдер");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите пункт: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": ShowAllStudents(); break;
                        case "2": AddStudent(); break;
                        case "3": DeleteStudent(); break;
                        case "4": ToggleProvider(); break;
                        case "5":
                            exit = true;
                            Console.WriteLine("До свидания!");
                            break;
                        default:
                            Console.WriteLine("Неверный пункт меню. Попробуйте снова.");
                            Pause();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.ResetColor();
                    Pause();
                }
            }
        }

        private static void ShowAllStudents()
        {
            Console.Clear();
            Console.WriteLine("\n Список студентов");
            var students = _service.GetAll();

            if (students.Count == 0)
            {
                Console.WriteLine("Список пуст.");
            }
            else
            {
                Console.WriteLine($"{"Id",-5} {"Имя",-15} {"Фамилия",-15} {"Группа",-10}");
                Console.WriteLine(new string('-', 50));
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id,-5} {s.FirstName,-15} {s.LastName,-15} {s.Group,-10}");
                }
            }

            Console.WriteLine($"\nВсего записей: {students.Count}");
            Pause();
        }

        private static void AddStudent()
        {
            Console.Clear();
            Console.WriteLine("\n Добавление студента");

            Console.Write("Имя: ");
            string firstName = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Фамилия: ");
            string lastName = Console.ReadLine()?.Trim() ?? "";
            Console.Write("Группа: ");
            string group = Console.ReadLine()?.Trim() ?? "";

            _service.Add(firstName, lastName, group);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n Студент добавлен (провайдер: {_service.GetCurrentProviderName()})");
            Console.ResetColor();
            Pause();
        }

        private static void DeleteStudent()
        {
            Console.Clear();
            Console.WriteLine("\n Удаление студента");
            Console.Write("Введите Id студента для удаления: ");

            if (int.TryParse(Console.ReadLine(), out int id))
            {
                _service.Remove(id);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n Студент с Id={id} удалён (провайдер: {_service.GetCurrentProviderName()})");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n Неверный формат Id.");
                Console.ResetColor();
            }

            Pause();
        }

        private static void ToggleProvider()
        {
            // Второй экземпляр репозитория берём не через new, а у контейнера —
            // по имени привязки из SimpleConfigModule.
            bool usingEf = _service.GetCurrentProviderName() == "EF Core";

            // Второй экземпляр репозитория берём не через new, а у контейнера.
            _service.UseRepository(usingEf
                ? _kernel.Get<DapperRepository>()
                : _kernel.Get<IRepository<Student>>());

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n Провайдер переключён на: {_service.GetCurrentProviderName()}");
            Console.ResetColor();
            Pause();
        }

        private static void Pause()
        {
            Console.WriteLine("\n Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        }
    }
}
