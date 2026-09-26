using System;

namespace Lab1Library
{
    [Serializable]
    public class Student
    {
        /// vārds
        public string Name { get; set; }
        /// uzvārds
        public string Surname { get; set; }
        /// studenta ID
        public string Id { get; set; }
        /// grupa
        public string Group { get; set; }
        /// e-pasts
        public string Email { get; set; }

        
        public Student() { }

        public Student(string name, string surname, string id, string group)
            : this(name, surname, id, group, string.Empty) { }

        public Student(string name, string surname, string id, string group, string email)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname)
                || string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("Jāievada studenta vārds, uzvārds un apliecības numurs.");
            Name = name.Trim();
            Surname = surname.Trim();
            Id = id.Trim();
            Group = (group ?? string.Empty).Trim();
            Email = (email ?? string.Empty).Trim();
        }

        public override string ToString()
        {
            return Id + " : " + Name + " " + Surname + " | " + Group + " | " + Email;
        }
    }
}
