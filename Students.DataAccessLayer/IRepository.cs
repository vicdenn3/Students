using System.Collections.Generic;
using Students.Model;

namespace Students.DataAccessLayer
{
    /// <summary>
    /// Паттерн «Репозиторий»: абстракция доступа к данным.
    /// Ограничение where T : IDomainObject гарантирует наличие Id у любого T,
    /// поэтому методы Update и Delete получают сам объект, а не отдельный id.
    /// </summary>
    public interface IRepository<T> where T : IDomainObject, new()
    {
        void Create(T obj);
        IEnumerable<T> ReadAll();
        T ReadById(int id);
        void Update(T obj);
        void Delete(T obj);
    }
}
