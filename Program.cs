using EfCoreTeacherAndStudent.Service;

namespace EfCoreTeacherAndStudent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SchoolService service = new SchoolService();
            List<string> TeacherName = service.IndexListTeacher();
            List<string> StudentName = service.IndexListStudent();

            var menyu = new List<string>
            {
                "Teacher",
                "Student",
            };

            var TeacherMenyu = new List<string>
            {
                "Add Teacher",
                "List Teacher",
                "Update Teacher",
                "Delete Teacher",
            };

            var StudentMenyu = new List<string>
            {
                "Add Student",
                "List Student",
                "Update Student",
                "Delete Student",
            };

            int TeacherIndex = 0;
            int StudentIndex = 0;
            int index = 0;
            bool exit = true;

            while (exit)
            {
                index = ArrowIndex(menyu);
                switch (index)
                {
                    case 0:
                        bool teacheExit = true;
                        while (teacheExit)
                        {
                            index = ArrowIndex(TeacherMenyu);
                            switch (index)
                            {
                                case 0:
                                    service.CreateTeacher();
                                    TeacherName = service.IndexListTeacher();
                                    Console.ReadKey();
                                    continue;

                                case 1:
                                    service.ListTeacher();
                                    Console.ReadKey();
                                    continue;

                                case 2:
                                    TeacherName = service.IndexListTeacher();
                                    TeacherIndex = ArrowIndex(service.IndexListTeacher());
                                    if (TeacherIndex == TeacherName.Count) continue;
                                    service.UpdateTeacher(TeacherName[TeacherIndex]);
                                    Console.ReadKey();
                                    continue;

                                case 3:
                                    TeacherName = service.IndexListTeacher();
                                    TeacherIndex = ArrowIndex(service.IndexListTeacher());
                                    if (TeacherIndex == TeacherName.Count) continue;
                                    service.DeleteTeacher(TeacherName[TeacherIndex]);
                                    Console.ReadKey();
                                    continue;

                                default:
                                    teacheExit = false;
                                    continue;
                            }
                        }
                        continue;

                    case 1:
                        bool StudentExit = true;
                        while (StudentExit)
                        {
                            index = ArrowIndex(StudentMenyu);
                            switch (index)
                            {
                                case 0:
                                    service.CreateStudent();
                                    StudentName = service.IndexListStudent();
                                    Console.ReadKey();
                                    continue;

                                case 1:
                                    service.ListStudent();
                                    Console.ReadKey();
                                    continue;

                                case 2:
                                    StudentName = service.IndexListStudent();
                                    StudentIndex = ArrowIndex(service.IndexListStudent());
                                    if (StudentIndex == StudentName.Count) continue;
                                    service.UpdateStudent(StudentName[StudentIndex]);
                                    Console.ReadKey();
                                    continue;

                                case 3:
                                    StudentName = service.IndexListStudent();
                                    StudentIndex = ArrowIndex(service.IndexListStudent());
                                    if (StudentIndex == StudentName.Count) continue;
                                    service.DeleteStudent(StudentName[StudentIndex]);
                                    Console.ReadKey();
                                    continue;

                                default:
                                    StudentExit = false;
                                    continue;
                            }
                        }
                        continue;

                    default:
                        exit = false;
                        break;
                }
            }
        }

        public static int ArrowIndex(List<string> buyruq)
        {
            int selectIndex = 0;
            buyruq.Add("<--Back");
            while (true)
            {
                Console.Clear();
                for (int i = 0; i < buyruq.Count; i++)
                {
                    if (i == selectIndex) Console.WriteLine($">>>>  {buyruq[i]}");
                    else Console.WriteLine($"      {buyruq[i]}");
                }
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.DownArrow) selectIndex = (selectIndex + 1) % buyruq.Count;
                else if (key.Key == ConsoleKey.UpArrow) selectIndex = (selectIndex - 1 + buyruq.Count) % buyruq.Count;
                else if (key.Key == ConsoleKey.Enter)
                {
                    buyruq.RemoveAt(buyruq.Count - 1);
                    return selectIndex;
                }
            }
        }
    }
}
