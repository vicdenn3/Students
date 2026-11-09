using System;

namespace Students.DataAccessLayer
{
    public static class DatabaseConfig
    {
        // База создаётся самим LocalDB по имени (Initial Catalog), без привязки к файлу .mdf и путям.
        // Таблица Students создаётся при первом запуске через EnsureCreated().
        // При необходимости строку можно переопределить переменной окружения STUDENTS_CONNECTION_STRING.
        public static readonly string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\User\Downloads\Students-lab3\StudentsLabs3\Students.DataAccessLayer\Database1.mdf;Integrated Security=True;";
    }
}
