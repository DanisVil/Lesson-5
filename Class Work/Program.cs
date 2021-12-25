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
            DoTask5();

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
            public ushort birthYear;
            public enum Subjects { physics, computer_science, foreign_language };
            public Subjects subject;
            public ushort exam_points;
            public Student(string inpname, string inpsurname, ushort inpbirth_year, string inpsubject, ushort inpexam_points)
            {
                name = inpname;
                surname = inpsurname;
                birthYear = inpbirth_year;
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
            public override string ToString()
            {
                string subjectLine;
                if (subject.Equals(Subjects.physics))
                {
                    subjectLine = "физика";
                }
                else if (subject.Equals(Subjects.computer_science))
                {
                    subjectLine = "информатика";
                }
                else
                {
                    subjectLine = "иностранный язык";
                }
                return $"Имя - {name}, фамилия - {surname}, год рождения - {birthYear}, предмет - {subjectLine}, баллов - {exam_points}";
            }
        }
        public struct Employee
        {
            public string name;
            public enum Post { junior, middle, teamlead, senior }
            public Post post;
            public byte impudence;
            public bool isStupid;
            public Employee(string name, Post post, byte impudence, bool isStupid)
            {
                this.name = name;
                this.post = post;
                this.impudence = impudence;
                this.isStupid = isStupid;
            }
            public override string ToString()
            {
                return $"Имя - {name}, должность - {post}, наглость - {impudence}, тупость - {isStupid}";
            }
        }
        public struct Table
        {
            public int Number { get; private set; }
            public enum Color { Red, Blue, Green, Yellow, Black, White };
            public Color Colour { get; private set; }
            private Stack<Employee> seaters;
            public Table(int number, Color color)
            {
                Number = number;
                Colour = color;
                seaters = new Stack<Employee>();
            }
            public bool PutOnTheTable(Dictionary<Employee, Employee[]> rels, Employee key, bool forced)
            {
                if (seaters.Count == 0)
                {
                    seaters.Push(key);
                    return true;
                }
                if (!forced && key.isStupid) return false;
                if (seaters.Count < 3 || seaters.Count <= 3 && key.impudence != 0)
                {
                    if (forced)
                    {
                        seaters.Push(key);
                        return true;
                    }
                    foreach (Employee relEmp in rels[key])
                    {
                        if (seaters.Contains(relEmp))
                        {
                            seaters.Push(key);
                            return true;
                        }
                    }
                }
                return false;
            }
            public Employee[] GetSeaters()
            {
                Queue<Employee> temp = new Queue<Employee>(seaters);
                Employee[] output = new Employee[seaters.Count];
                for (int i = 0; i < seaters.Count; i++)
                {
                    output[i] = temp.Dequeue();
                }
                return output;
            }
            public override string ToString()
            {
                string oaoammm = $"{Number},  {Colour}";
                foreach (Employee emp in seaters)
                {
                    oaoammm += $"\n{emp.name}";
                }
                return oaoammm;
            }
        }
        public enum Disease { Cancer = 0, AIDS = 1, Dysentery = 2, Hemorrhoid = 3}
        public enum Medicine { CancerHealer = 0, AIDSHealer = 1, DysHealer = 2, HemHealer = 3}
        public static Dictionary<Disease, Medicine> commonMedicines = new Dictionary<Disease, Medicine>() { [Disease.Cancer] = Medicine.CancerHealer,
        [Disease.AIDS] = Medicine.AIDSHealer, [Disease.Dysentery] = Medicine.DysHealer, [Disease.Hemorrhoid] = Medicine.HemHealer};
        public struct GMother
        {
            public string Name { get; private set; }
            public int Age { get; private set; }
            private List<Disease> diseases;
            private List<Medicine> medicines;
            public GMother(string name, int age, List<Disease> diseases, List<Medicine> medicines)
            {
                Name = name;
                Age = age;
                this.diseases = diseases;
                this.medicines = medicines;
            }
            public override string ToString()
            {
                string a = $"{Name}     {Age}\n";
                foreach (Disease disease in diseases)
                {
                    a += $"{disease} ";
                }
                a += "\n";
                foreach (Medicine med in medicines)
                {
                    a += $"{med} ";
                }
                return a;
            }
            public List<Disease> GetDiseases()
            {
                List<Disease> a = new List<Disease>();
                foreach (Disease disease in diseases)
                {
                    if (!medicines.Contains(commonMedicines[disease]))
                    {
                        a.Add(disease);
                    }
                }
                return a;
            }
        }
        public struct Hospital
        {
            public string Name { get; private set; }
            private List<Disease> diseases;
            public int Capacity { get; private set; }
            private List<GMother> patients;
            public Hospital(string name, List<Disease> diseases, int capacity)
            {
                Name = name;
                this.diseases = diseases;
                Capacity = capacity;
                patients = new List<GMother>();
            }
            public bool AddPatient(GMother gm)
            {
                if (patients.Count + 1 <= Capacity)
                {
                    int count = 0;
                    List<Disease> gmDiseases = gm.GetDiseases();
                    foreach (Disease gmDisease in gmDiseases)
                    {
                        if (diseases.Contains(gmDisease))
                        {
                            count++;
                        }
                    }
                    if (count >= (float)gmDiseases.Count / 2)
                    {
                        patients.Add(gm);
                        return true;
                    }
                }
                return false;
            }
            public override string ToString()
            {
                string a = Name;
                a += $"\nЗагруженность: {100 * patients.Count / Capacity}";
                foreach (GMother gm in patients)
                {
                    a += "\n" + gm.Name;
                }
                return a;
            }
        }
        static public void DoTask1()
        {
            Random random = new Random();
            byte clan_count = 10;
            byte[] bavarian_beer_bears = new byte[clan_count], scandinavian_schollers = new byte[clan_count];
            for (int i = 0; i < clan_count; i++)
            {
                bavarian_beer_bears[i] = (byte)random.Next(10);
                scandinavian_schollers[i] = (byte)random.Next(10);
            }

            for (int i = 0; i < clan_count; i++)
            {
                Console.Write(bavarian_beer_bears[i] + " ");
                scandinavian_schollers[i] = (byte)random.Next(10);
            }
            Console.WriteLine();
            for (int i = 0; i < clan_count; i++)
            {
                Console.Write(scandinavian_schollers[i] + " ");
            }
            Console.WriteLine();

            Console.WriteLine(BeerCheck(bavarian_beer_bears, scandinavian_schollers));
        }
        static public void DoTask2()
        {
            Random random = new Random();
            List<string> pictures_source = new List<string>();
            for (byte i = 1; i <= 32; i++)
            {
                pictures_source.Add(Convert.ToString(i));
                pictures_source.Add(Convert.ToString(i));
            }
            for (byte i = 0; i < pictures_source.Count; i++)
            {
                Console.Write($"{pictures_source[i]} ");
            }
            Console.WriteLine();

            for (int i = pictures_source.Count - 1; i > 1; i--)
            {
                int k = random.Next(i + 1);
                string value = pictures_source[k];
                pictures_source[k] = pictures_source[i];
                pictures_source[i] = value;
            }
            for (byte i = 0; i < pictures_source.Count; i++)
            {
                Console.Write($"{pictures_source[i]} ");
            }
            Console.WriteLine();
        }
        static public void DoTask3()
        {
            string[] text_array = File.ReadAllLines("../../students.TXT", Encoding.Default);
            Dictionary<uint, Student> student_group = new Dictionary<uint, Student>();
            List<uint> keys = new List<uint>(student_group.Keys);
            List<Student> values = new List<Student>(student_group.Values);
            for (uint i = 1; i <= text_array.Length; i++)
            {
                string[] splited_string = text_array[i - 1].Split();
                string name = splited_string[0], surname = splited_string[1], subject = splited_string[3];
                ushort birth_year, exam_points;
                ushort.TryParse(splited_string[2], out birth_year);
                ushort.TryParse(splited_string[4], out exam_points);
                student_group[i] = new Student(name, surname, birth_year, subject, exam_points);
            }
            keys = new List<uint>(student_group.Keys);
            values = new List<Student>(student_group.Values);
            Console.WriteLine("Введите \"Новый студент\", \"Удалить\", \"Сортировать\", \"Вывести список\" или \"Закрыть\"");
            string dialog = Console.ReadLine().ToLower();
            while (!dialog.Equals("закрыть"))
            {
                if (dialog.Equals("новый студент"))
                {
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine();
                    Console.Write("Введите год рождения: ");
                    ushort year;
                    ushort.TryParse(Console.ReadLine(), out year);
                    Console.Write("Введите предмет: ");
                    string subject = Console.ReadLine();
                    Console.Write("Введите кол-во баллов: ");
                    ushort points;
                    ushort.TryParse(Console.ReadLine(), out points);
                    student_group.Add(student_group.Keys.Max() + 1, new Student(name, surname, year, subject, points));
                    keys.Add(student_group.Keys.Max());
                    values = new List<Student>(student_group.Values);
                }
                else if (dialog.Equals("удалить"))
                {
                    Console.Write("Введите имя: ");
                    string name = Console.ReadLine().ToLower();
                    Console.Write("Введите фамилию: ");
                    string surname = Console.ReadLine().ToLower();
                    keys = new List<uint>(student_group.Keys);
                    foreach (uint key in keys)
                    {
                        Student student = student_group[key];
                        if (student.name.ToLower().Equals(name) && student.surname.ToLower().Equals(surname))
                        {
                            student_group.Remove(key);
                            break;
                        }
                    }
                    keys = new List<uint>(student_group.Keys);
                    values = new List<Student>(student_group.Values);
                }
                else if (dialog.Equals("сортировать"))
                {
                    uint change_count = 1;
                    Student dummy;
                    while (change_count != 0)
                    {
                        change_count = 0;
                        for (int i = 0; i < values.Count() - 1; i++)
                        {
                            if (values[i].exam_points > values[i + 1].exam_points)
                            {
                                dummy = values[i];
                                values[i] = values[i + 1];
                                values[i + 1] = dummy;
                                change_count++;
                            }
                        }
                    }
                    student_group = new Dictionary<uint, Student>();
                    for (uint i = 1; i <= values.Count(); i++)
                    {
                        student_group[i] = values[(int)i - 1];
                    }
                    keys = new List<uint>(student_group.Keys);
                    values = new List<Student>(student_group.Values);
                }
                else if (dialog.Equals("вывести список"))
                {
                    foreach (uint key in keys)
                    {
                        Console.Write($"{key} ");
                        Console.WriteLine(student_group[key]);
                    }
                }
                Console.WriteLine("Введите \"Новый студент\", \"Удалить\", \"Сортировать\", \"Вывести список\" или \"Закрыть\"");
                dialog = Console.ReadLine().ToLower();
            }
            Console.WriteLine("3-е задание завершилось");
        }
        static public void DoTask4()
        {
            List<Employee> queue = new List<Employee>();
            string[] text_array = File.ReadAllLines("../../employees.TXT", Encoding.Default);
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
                        post = Employee.Post.middle;
                        break;
                }
                byte.TryParse(splited_string[2], out byte impudence);
                bool is_stupid;
                int.TryParse(splited_string[3], out int tempBool);
                is_stupid = tempBool.Equals(1) ? true : false;
                queue.Add(new Employee(name, post, impudence, is_stupid));
            }
            int[] sortValue = new int[queue.Count];
            for (int i = 0; i < queue.Count; i++)
            {
                Console.WriteLine(queue[i]);
                sortValue[i] = queue[i].isStupid ? i - queue[i].impudence - 1 : i;
            }
            uint changeCount = 1;
            int dummy;
            Employee temp;
            while (changeCount != 0)
            {
                changeCount = 0;
                for (int i = 0; i < sortValue.Length - 1; i++)
                {
                    if (sortValue[i] > sortValue[i + 1])
                    {
                        dummy = sortValue[i];
                        temp = queue[i];
                        sortValue[i] = sortValue[i + 1];
                        queue[i] = queue[i + 1];
                        sortValue[i + 1] = dummy;
                        queue[i + 1] = temp;
                        changeCount++;
                    }
                }
            }
            Console.WriteLine();
            foreach (Employee employee in queue)
            {
                Console.WriteLine(employee);
            }
            Console.WriteLine("\n\n");

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
            //foreach (KeyValuePair<Employee, Employee[]> vivod in relations)
            //{
            //    Console.WriteLine(vivod.Key + "\n{");
            //    foreach (Employee emp in vivod.Value)
            //    {
            //        Console.WriteLine(emp);
            //    }
            //    Console.WriteLine("}");
            //}

            text_array = File.ReadAllLines("../../tables.TXT", Encoding.UTF8);
            List<Table> tables = new List<Table>();
            for (int i = 0; i < text_array.Length; i++)
            {
                string[] splited_string = text_array[i].Split();
                int number;
                switch (splited_string[1].ToLower())
                {
                    case "red":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Red));
                        break;
                    case "красный":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Red));
                        break;
                    case "blue":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Blue));
                        break;
                    case "синий":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Blue));
                        break;
                    case "green":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Green));
                        break;
                    case "зеленый":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Green));
                        break;
                    case "yellow":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Yellow));
                        break;
                    case "желтый":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Yellow));
                        break;
                    case "black":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Black));
                        break;
                    case "черный":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Black));
                        break;
                    case "white":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.White));
                        break;
                    case "белый":
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.White));
                        break;
                    default:
                        int.TryParse(splited_string[0], out number);
                        tables.Add(new Table(number, Table.Color.Black));
                        break;
                }
            }
            bool isForced = false;
            while (queue.Count != 0)
            {
                int i;
                for (i = 0; i < tables.Count; i++)
                {
                    if (tables[i].PutOnTheTable(relations, queue[0], isForced))
                    {
                        isForced = false;
                        queue.RemoveAt(0);
                        break;
                    }
                }
                if (i == tables.Count)
                {
                    isForced = true;
                }
            }

            foreach (Table table in tables)
            {
                Console.WriteLine(table);
                Console.WriteLine();
            }
            
        }
        static public void DoTask5()
        {
            Queue<GMother> gms = new Queue<GMother>();
            Stack<Hospital> hospitals = new Stack<Hospital>();
            string[] text_array = File.ReadAllLines("../../gms.TXT", Encoding.Default);
            for (int i = 0; i < text_array.Length; i++)
            {
                string[] splited_string = text_array[i].Split('|');
                string name = splited_string[0];
                int age;
                int.TryParse(splited_string[1], out age);
                List<Disease> diseases = new List<Disease>();
                foreach (string disease in splited_string[2].Split())
                {
                    switch (disease.ToLower())
                    {
                        case "рак":
                            diseases.Add(Disease.Cancer);
                            break;
                        case "спид":
                            diseases.Add(Disease.AIDS);
                            break;
                        case "дизентерия":
                            diseases.Add(Disease.Dysentery);
                            break;
                        case "геморрой":
                            diseases.Add(Disease.Hemorrhoid);
                            break;
                    }
                }
                List<Medicine> medicines = new List<Medicine>();
                foreach (string medicine in splited_string[3].Split())
                {
                    switch (medicine.ToLower())
                    {
                        case "глицин":
                            medicines.Add(Medicine.CancerHealer);
                            break;
                        case "йод":
                            medicines.Add(Medicine.AIDSHealer);
                            break;
                        case "ботва":
                            medicines.Add(Medicine.HemHealer);
                            break;
                        case "урина":
                            medicines.Add(Medicine.DysHealer);
                            break;
                    }
                }
                gms.Enqueue(new GMother(name, age, diseases, medicines));
            }
            hospitals.Push(new Hospital("1", new List<Disease>() { Disease.Cancer, Disease.AIDS }, 3));
            hospitals.Push(new Hospital("2", new List<Disease>() { Disease.Dysentery, Disease.Hemorrhoid }, 3));
            hospitals.Push(new Hospital("3", new List<Disease>() { Disease.Cancer, Disease.Dysentery }, 4));
            Stack<Hospital> helpingStack = new Stack<Hospital>();
            foreach (GMother gm in gms)
            {
                while (hospitals.Count != 0)
                {
                    Hospital hospital = hospitals.Pop();
                    helpingStack.Push(hospital);
                    if (hospital.AddPatient(gm))
                    {
                        break;
                    }
                }
                while (helpingStack.Count != 0)
                {
                    hospitals.Push(helpingStack.Pop());
                }
            }
            foreach (Hospital hosp in hospitals)
            {
                Console.WriteLine(hosp);
            } 
        }
    }
}