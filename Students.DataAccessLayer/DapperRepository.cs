using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using Students.Model;

namespace Students.DataAccessLayer
{
    public class DapperRepository : IRepository<Student>
    {
        private readonly string _connectionString;

        // Конструктор без параметров нужен IoC-контейнеру (л.р. №3).
        public DapperRepository() : this(DatabaseConfig.ConnectionString)
        {
        }

        public DapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection CreateConnection() => new SqlConnection(_connectionString);

        public void Create(Student obj)
        {
            using var db = CreateConnection();
            db.Execute(@"INSERT INTO Students (FirstName, LastName, [Group])
                         VALUES (@FirstName, @LastName, @Group)", obj);
        }

        public IEnumerable<Student> ReadAll()
        {
            using var db = CreateConnection();
            return db.Query<Student>("SELECT Id, FirstName, LastName, [Group] FROM Students").ToList();
        }

        public Student ReadById(int id)
        {
            using var db = CreateConnection();
            return db.QueryFirstOrDefault<Student>(
                "SELECT Id, FirstName, LastName, [Group] FROM Students WHERE Id = @Id", new { Id = id });
        }

        public void Update(Student obj)
        {
            using var db = CreateConnection();
            db.Execute(@"UPDATE Students
                         SET FirstName = @FirstName, LastName = @LastName, [Group] = @Group
                         WHERE Id = @Id", obj);
        }

        public void Delete(Student obj)
        {
            using var db = CreateConnection();
            db.Execute("DELETE FROM Students WHERE Id = @Id", new { obj.Id });
        }
    }
}
