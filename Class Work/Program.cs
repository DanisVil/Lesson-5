using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Class_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            ////task1
            //Random random = new Random();
            //byte clan_count = 10;
            //byte[] bavarian_beer_bears = new byte[clan_count], scandinavian_schollers = new byte[clan_count];
            //for (int i = 0; i < clan_count; i++)
            //{
            //    bavarian_beer_bears[i] = (byte)random.Next(10);
            //    scandinavian_schollers[i] = (byte)random.Next(10);
            //}
            //Console.WriteLine(BeerCheck(bavarian_beer_bears, scandinavian_schollers));

            ////task2
            //List<string> pictures_source = new List<string>();
            //for (byte i = 1; i <= 32; i++)
            //{
            //    pictures_source.Add(Convert.ToString(i));
            //    pictures_source.Add(Convert.ToString(i));
            //}
            //for (byte i = 0; i < pictures_source.Count; i++)
            //{
            //    Console.Write($"{pictures_source[i]} ");
            //}
            //Console.WriteLine();

            //for (int i = pictures_source.Count - 1; i > 1; i--)
            //{
            //    int k = random.Next(i + 1);
            //    string value = pictures_source[k];
            //    pictures_source[k] = pictures_source[i];
            //    pictures_source[i] = value;
            //}
            //for (byte i = 0; i < pictures_source.Count; i++)
            //{
            //    Console.Write($"{pictures_source[i]} ");
            //}
            //Console.WriteLine();

            ////task 3
            string[] text_array = File.ReadAllLines("../../students.TXT", Encoding.Default);
            //Dictionary<uint, Student> student_group = new Dictionary<uint, Student>();
            //List<uint> keys = new List<uint>(student_group.Keys);
            //List<Student> values = new List<Student>(student_group.Values);
            //for (uint i = 1; i <= text_array.Length; i++)
            //{
            //    string[] splited_string = text_array[i - 1].Split();
            //    string name = splited_string[0], surname = splited_string[1], subject = splited_string[3];
            //    ushort birth_year, exam_points;
            //    ushort.TryParse(splited_string[2], out birth_year);
            //    ushort.TryParse(splited_string[4], out exam_points);
            //    student_group[i] = new Student(name, surname, birth_year, subject, exam_points);
            //}
            //keys = new List<uint>(student_group.Keys);
            //values = new List<Student>(student_group.Values);
            //Console.WriteLine("Введите \"Новый студент\", \"Удалить\", \"Сортировать\", \"Вывести список\" или \"Закрыть\"");
            //string dialog = Console.ReadLine().ToLower();
            //while (!dialog.Equals("закрыть"))
            //{
            //    if (dialog.Equals("новый студент"))
            //    {
            //        Console.Write("Введите имя: ");
            //        string name = Console.ReadLine();
            //        Console.Write("Введите фамилию: ");
            //        string surname = Console.ReadLine();
            //        Console.Write("Введите год рождения: ");
            //        ushort year;
            //        ushort.TryParse(Console.ReadLine(), out year);
            //        Console.Write("Введите предмет: ");
            //        string subject = Console.ReadLine();
            //        Console.Write("Введите кол-во баллов: ");
            //        ushort points;
            //        ushort.TryParse(Console.ReadLine(), out points);
            //        student_group.Add(student_group.Keys.Max() + 1, new Student(name, surname, year, subject, points));
            //        keys.Add(student_group.Keys.Max());
            //        values = new List<Student>(student_group.Values);
            //    }
            //    else if (dialog.Equals("удалить"))
            //    {
            //        Console.Write("Введите имя: ");
            //        string name = Console.ReadLine().ToLower();
            //        Console.Write("Введите фамилию: ");
            //        string surname = Console.ReadLine().ToLower();
            //        keys = new List<uint>(student_group.Keys);
            //        foreach (uint key in keys)
            //        {
            //            Student student = student_group[key];
            //            if (student.name.ToLower().Equals(name) && student.surname.ToLower().Equals(surname))
            //            {
            //                student_group.Remove(key);
            //                break;
            //            }
            //        }
            //        keys = new List<uint>(student_group.Keys);
            //        values = new List<Student>(student_group.Values);
            //    }
            //    else if (dialog.Equals("сортировать"))
            //    {
            //        uint change_count = 1;
            //        Student dummy;
            //        while (change_count != 0)
            //        {
            //            change_count = 0;
            //            for (int i = 0; i < values.Count() - 1; i++)
            //            {
            //                if (values[i].exam_points > values[i + 1].exam_points)
            //                {
            //                    dummy = values[i];
            //                    values[i] = values[i + 1];
            //                    values[i + 1] = dummy;
            //                    change_count++;
            //                }
            //            }
            //        }
            //        student_group = new Dictionary<uint, Student>();
            //        for (uint i = 1; i <= values.Count(); i++)
            //        {
            //            student_group[i] = values[(int)i - 1];
            //        }
            //        keys = new List<uint>(student_group.Keys);
            //        values = new List<Student>(student_group.Values);
            //    }
            //    else if (dialog.Equals("вывести список"))
            //    {
            //        foreach (uint key in keys)
            //        {
            //            Console.Write($"{key} ");
            //            Console.WriteLine(Student.StudentInfo(student_group[key]));
            //        }
            //    }
            //    Console.WriteLine("Введите \"Новый студент\", \"Удалить\", \"Сортировать\", \"Вывести список\" или \"Закрыть\"");
            //    dialog = Console.ReadLine().ToLower();
            //}
            //Console.WriteLine("3-е задание завершилось");

            //task4
            List<Employee> queue = new List<Employee>();
            Stack<Table> tables = new Stack<Table>();
            text_array = File.ReadAllLines("../../employees.TXT", Encoding.Default);
            for (int i = 0; i < text_array.Length; i++)
            {
                string[] splited_string = text_array[i].Split();
                string name = splited_string[0];
                Employee.Post post;
                switch (splited_string[1])
                {
                    case "junior":
                        post = Employee.Post.junior;
                        break;
                    case "middle":
                        post = Employee.Post.middle;
                        break;
                    case "teamlead":
                        post = Employee.Post.teamlead;
                        break;
                    case "senior":
                        post = Employee.Post.senior;
                        break;
                    default:
                        throw new Exception("неправильный формат");
                }
                byte.TryParse(splited_string[2], out byte impudence);
                bool is_stupid;
                int.TryParse(splited_string[3], out int dummy);
                if (dummy.Equals(0))
                {
                    is_stupid = false;
                }
                else if (dummy.Equals(1))
                {
                    is_stupid = true;
                }
                else
                {
                    throw new Exception("Something wrong, I can feel it");
                }
                queue.Add(new Employee(name, post, impudence, is_stupid));
            }
            foreach (Employee employee in queue)
            {
                Console.WriteLine(Employee.EmployeeInfo(employee));
            }
            List<Employee> temp = new List<Employee>();
            while (queue.Count != 0)
            {
                int evaluation = queue[0].is_stupid ? queue.Count + queue[0].impudence : queue.Count;
                int number = 0;
                for (int i = 1; i < queue.Count; i++)
                {
                    if (queue[i].is_stupid && (queue.Count - i + queue[i].impudence >= evaluation))
                    {
                        evaluation = queue.Count - i + queue[i].impudence;
                        number = i;
                    }
                    else if (!queue[i].is_stupid && (queue.Count - i > evaluation))
                    {
                        evaluation = queue.Count - i;
                        number = i;
                    }
                }
                temp.Add(queue[number]);
                queue.RemoveAt(number);
            }
            queue = temp;
            Console.WriteLine();
            foreach (Employee employee in queue)
            {
                Console.WriteLine(Employee.EmployeeInfo(employee));
            }
            Dictionary<Employee, Employee[]> relations = new Dictionary<Employee, Employee[]>();
            text_array = File.ReadAllLines("../../relations.TXT", Encoding.Default);
            for (int i = 0; i < text_array.Length; i++)
            {
                string[] splited_string = text_array[i].Split();
                Employee key = queue[0];
                Employee[] value = new Employee[splited_string.Length - 1];
                foreach (Employee employee in queue)
                {
                    if (employee.name.Equals(splited_string[0]))
                    {
                        key = employee;
                        break;
                    }
                }
                for (int j = 1; j < splited_string.Length; j++)
                {
                    foreach (Employee employee in queue)
                    {
                        if (employee.name.Equals(splited_string[j]))
                        {
                            value[j - 1] = employee;
                            break;
                        }
                    }
                }
                relations.Add(key, value);
            }

            Console.ReadKey();
        }
        static public string BeerCheck(byte[] a, byte[] b)
        {
            byte afives = 0, bfives = 0;
            foreach (byte i in a)
            {
                if (i.Equals(5))
                {
                    afives++;
                }
            }
            foreach (byte i in b)
            {
                if (i.Equals(5))
                {
                    bfives++;
                }
            }
            if (afives.Equals(bfives))
            {
                return "Drinks All Round! Free Beers on Bjorg!";
            }
            return "Ой,Бьорг - пончик! Ни для кого пива!";
        }
        public struct Student
        {
            public string name;
            public string surname;
            public ushort birth_year;
            public enum Subjects { physics, computer_science, foreign_language };
            public Subjects subject;
            public ushort exam_points;
            public Student(string inpname, string inpsurname, ushort inpbirth_year, string inpsubject, ushort inpexam_points)
            {
                name = inpname;
                surname = inpsurname;
                birth_year = inpbirth_year;
                if (inpsubject.Equals("физика"))
                {
                    subject = Subjects.physics;
                }
                else if (inpsubject.Equals("информатика"))
                {
                    subject = Subjects.computer_science;
                }
                else if (inpsubject.Contains("кий"))
                {
                    subject = Subjects.foreign_language;
                }
                else
                {
                    throw new Exception("неправильно заполнена форма");
                }
                exam_points = inpexam_points;
            }
            public static string StudentInfo(Student student)
            {
                string subject;
                if (student.subject.Equals(Subjects.physics))
                {
                    subject = "физика";
                }
                else if (student.subject.Equals(Subjects.computer_science))
                {
                    subject = "информатика";
                }
                else
                {
                    subject = "иностранный язык";
                }
                return $"Имя - {student.name}, фамилия - {student.surname}, год рождения - {student.birth_year}, предмет - {subject}, баллов - {student.exam_points}";
            }
        }
        public struct Employee
        {
            public string name;
            public enum Post { junior, middle, teamlead, senior }
            public Post post;
            public byte impudence;
            public bool is_stupid;
            public Employee(string iname, Post ipost, byte iimpudence, bool iis_stupid)
            {
                name = iname;
                post = ipost;
                impudence = iimpudence;
                is_stupid = iis_stupid;
            }
            public static string EmployeeInfo(Employee employee)
            {
                string subject;
                return $"Имя - {employee.name}, должность - {employee.post}, наглость - {employee.impudence}, тупость - {employee.is_stupid}";
            }
        }
        public struct Table
        {
            public int number;
            public enum Color { Red, Blue, Green, Yellow, Black, White };
            public List<Employee> seat;
        }
    }
}
