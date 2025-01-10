namespace Person.Model;


    public class Person
    {

        public Person(string name, string email)
        {
            Name = name;
            Email = email;
            Id = Guid.NewGuid();
            
        }
        public Guid Id { get; init; }

        public string Name { get; private set; }
        
        public string Email { get; set; }
    }
