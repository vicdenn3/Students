using System.Collections.Generic;
using System.Linq;
using Students.Model;

namespace Students.DataAccessLayer
{
    public class EFRepository : IRepository<Student>
    {
        public void Create(Student obj)
        {
            using var db = new AppDbContext();
            db.Students.Add(obj);
            db.SaveChanges();
        }

        public IEnumerable<Student> ReadAll()
        {
            using var db = new AppDbContext();
            return db.Students.ToList();
        }

        public Student ReadById(int id)
        {
            using var db = new AppDbContext();
            return db.Students.Find(id);
        }

        public void Update(Student obj)
        {
            using var db = new AppDbContext();
            db.Students.Update(obj);
            db.SaveChanges();
        }

        public void Delete(Student obj)
        {
            using var db = new AppDbContext();
            var item = db.Students.Find(obj.Id);
            if (item != null)
            {
                db.Students.Remove(item);
                db.SaveChanges();
            }
        }
    }
}
