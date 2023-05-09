using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstConsoleApp548
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new StudentDataBase())
            {
                Console.WriteLine("Enter a name for a new Student: ");
                var name = Console.ReadLine();

                var student = new Student { Name = name };
                db.Students.Add(student);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Students
                            orderby b.Name
                            select b;

                Console.WriteLine("All students in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();

            }
        }
    }
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
       
    }
    
    public class StudentDataBase : DbContext
    {
        public DbSet<Student> Students { get; set; }
        
    }
}
