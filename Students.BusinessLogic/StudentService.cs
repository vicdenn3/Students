using System;
using System.Collections.Generic;
using System.Linq;
using Students.DataAccessLayer;
using Students.Model;

namespace Students.BusinessLogic
{
    // Слой бизнес-логики.
    // ВАЖНО (л.р. №3): зависимость от хранилища приходит СНАРУЖИ через конструктор.
    // Класс больше не знает, EF это или Dapper, и не создаёт репозиторий сам.
    public class StudentService
    {
        public IRepository<Student> Repository { get; set; }

        public StudentService(IRepository<Student> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public void InitializeDatabase()
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();
        }

        // Переключение реализации репозитория на лету (та же функциональность, что в л.р. №2).
        // Экземпляр репозитория тоже приходит извне — его разрешает IoC-контейнер.
        public void UseRepository(IRepository<Student> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public string GetCurrentProviderName() =>
            Repository is DapperRepository ? "Dapper" : "EF Core";

        public List<Student> GetAll() => Repository.ReadAll().ToList();

        public void Add(string firstName, string lastName, string group)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(group))
            {
                throw new ArgumentException("Все поля студента должны быть заполнены!");
            }

            var newStudent = new Student { FirstName = firstName, LastName = lastName, Group = group };
            Repository.Create(newStudent);
        }

        public void Remove(int id)
        {
            // Репозиторий удаляет по объекту (у него есть Id благодаря IDomainObject).
            var student = Repository.ReadById(id);
            if (student != null)
                Repository.Delete(student);
        }
    }
}
