using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab1Library
{
    public class StudentsData
    {
        public List<Student> Students { get; private set; }
        public const string DefaultFilename = @"..\..\..\students.xml";

        public StudentsData() { Students = new List<Student>(); }

        public void Add(Student newStud)
        {
            if (newStud != null) Students.Add(newStud);
        }

        
        
        private static string ResolveFilename(string filename)
        {
            if (string.IsNullOrEmpty(filename) || filename == DefaultFilename)
                return Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DefaultFilename));
            return filename;
        }

        public void Save(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var data = new FileStream(ResolveFilename(filename), FileMode.Create, FileAccess.Write))
                serializer.Serialize(data, Students);
        }

        public void Load(string filename)
        {
            var serializer = new XmlSerializer(typeof(List<Student>));
            using (var data = new FileStream(ResolveFilename(filename), FileMode.Open, FileAccess.Read))
            {
                
                var loaded = (List<Student>)serializer.Deserialize(data);
                Students.AddRange(loaded);
            }
        }
    }
}
