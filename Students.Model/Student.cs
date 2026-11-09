namespace Students.Model
{
    public class Student : IDomainObject
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }
    }
}
