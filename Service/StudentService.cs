using EfCoreTeacherAndStudent.Models;

namespace EfCoreTeacherAndStudent.Service;

public partial class SchoolService
{
    public void CreateStudent()
    {
        Console.Write("Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Student age: ");
        int age;

        while (!int.TryParse(Console.ReadLine(), out age))
            Console.WriteLine("Enter number!");

        var AddStudent = new Student { Name = name, Age = age };
        dbContext.Add(AddStudent);
        dbContext.SaveChanges();
        Console.WriteLine("** Successful **");
    }

    public void ListStudent()
    {
        var listStudent = dbContext.Students.ToList();
        Console.WriteLine();
        Console.WriteLine("Student: ");
        Console.WriteLine();

        if (listStudent.Count != 0)
            foreach (var item in listStudent)
                Console.WriteLine($"id: {item.Id,-10}| name:{item.Name,-25}| age:{item.Age} ");
        else
            Console.WriteLine("Empty!!!!");
    }

    public List<string> IndexListStudent()
    {
        List<string> list = new List<string>();
        var listStudent = dbContext.Students.ToList();
        foreach (var item in listStudent)
            list.Add(item.Name);

        return list;
    }

    public void UpdateStudent(string StudentName)
    {
        var updateStudent = dbContext.Students.FirstOrDefault(t => t.Name == StudentName);
        if (updateStudent != null)
        {
            Console.Write("New Name: ");
            string NewName = Console.ReadLine();
            updateStudent.Name = NewName;
            dbContext.SaveChanges();
            Console.WriteLine("** Update Student **");
        }
        else
            Console.WriteLine("Student not found");
    }

    public void DeleteStudent(string StudentName)
    {
        var deleteStudent = dbContext.Students.FirstOrDefault(t => t.Name == StudentName);
        if (deleteStudent != null)
        {
            dbContext.Remove(deleteStudent);
            dbContext.SaveChanges();
            Console.WriteLine("** Delete Student **");
        }
        else
            Console.WriteLine("Student not found");
    }
}
