using EfCoreTeacherAndStudent.Models;

namespace EfCoreTeacherAndStudent.Service
{
    public partial class SchoolService
    {
        public DatatsContext dbContext { get; set; }
        public SchoolService()
        {
            dbContext = new DatatsContext();
        }

        public void CreateTeacher()
        {
            Console.Write("Teacher Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Teacher age: ");
            int age;

            while (!int.TryParse(Console.ReadLine(), out age))
                Console.WriteLine("Enter number!");

            var AddTeacher = new Teacher { Name = name, Age = age };
            dbContext.Add(AddTeacher);
            dbContext.SaveChanges();
            Console.WriteLine("** Successful **");
        }

        public void ListTeacher()
        {
            var listTeacher = dbContext.Teachers.ToList();
            Console.WriteLine();
            Console.WriteLine("Teacher: ");
            Console.WriteLine();

            if (listTeacher.Count != 0)
                foreach (var item in listTeacher)
                {
                    Console.WriteLine($"id: {item.Id,-10}| name:{item.Name,-10}| age:{item.Age} ");
                }
            else 
                Console.WriteLine("Empty!!!!");
        }

        public List<string> IndexListTeacher()
        {
            List<string> list = new List<string>();
            var listTeacher = dbContext.Teachers.ToList();
            if (listTeacher != null)
            {
                foreach (var item in listTeacher)
                {
                    list.Add(item.Name);
                }
                return list;
            }
            return null;
        }
        public void UpdateTeacher(string TeacherName)
        {
            var updateTeacher = dbContext.Teachers.FirstOrDefault(t => t.Name == TeacherName);
            if (updateTeacher != null)
            {
                Console.Write("New Name: ");
                string NewName = Console.ReadLine();
                updateTeacher.Name = NewName;
                dbContext.SaveChanges();
                Console.WriteLine("** Update Teacher **");
            }
            else 
                Console.WriteLine("Teacher not found");
        }
        public void DeleteTeacher(string TeacherName)
        {
            var deleteTeacher = dbContext.Teachers.FirstOrDefault(t => t.Name == TeacherName);
            if (deleteTeacher != null)
            {
                dbContext.Remove(deleteTeacher);
                dbContext.SaveChanges();
                Console.WriteLine("** Delete Teacher **");
            }
            else 
                Console.WriteLine("Teacher not found");
        }
    }
}
