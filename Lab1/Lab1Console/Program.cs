using System;
using System.Text;
using Lab1Library;

namespace Lab1Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try
            {
                var studData = new StudentsData();
                studData.Load(StudentsData.DefaultFilename);
                foreach (var stud in studData.Students)
                    Console.WriteLine(stud);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            Console.ReadLine();
        }
    }
}
