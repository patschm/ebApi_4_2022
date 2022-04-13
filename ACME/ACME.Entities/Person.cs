namespace ACME.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }

        // ICollection<PersonHobby> PersonHobbies { get; set; } = new HashSet<PersonHobby>();
        public ICollection<Hobby> Hobbies { get; set; } = new HashSet<Hobby>();
    }
}