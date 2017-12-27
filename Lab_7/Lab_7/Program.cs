using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {
        static List<office.Worker> workers = new List<office.Worker>()
        {
            new office.Worker(1, "Лескина "),
            new office.Worker(2, "Брысина "),
            new office.Worker(3, "Байбарин "),
            new office.Worker(4, "Гаврилюк "),
            new office.Worker(5, "Баскакова "),
            new office.Worker(6, "Кондрашева "),
            new office.Worker(7, "Тимаков "),
            new office.Worker(8, "Авдеев "),
            new office.Worker(9, "Александрова "),
        };
        static List<office.Department> rooms = new List<office.Department>()
        {
            new office.Department(1, "Отдел финансов "),
            new office.Department(2, "Общий отдел "),
            new office.Department(3, "Отдел кадров "),
            new office.Department(4, "IT отдел ")
        };
        static List<office.Relations> rel = new List<office.Relations>()
        {
            new office.Relations(1, 1),
            new office.Relations(2, 4),
            new office.Relations(3, 2),
            new office.Relations(4, 3),
            new office.Relations(5, 3),
            new office.Relations(6, 4),
            new office.Relations(7, 1),
            new office.Relations(8, 2),
            new office.Relations(9, 2),
            new office.Relations(6, 3),
            new office.Relations(7, 2),
            new office.Relations(8, 4),
            new office.Relations(9, 1)
        };
        static void Main(string[] args)
        {
            Console.WriteLine("Перечисление всех сотрудников\n" +
                "ID|Фамилия|");
            var i1 = from x in workers select x;
            foreach (var x in i1) Console.WriteLine(x);

            Console.WriteLine("\nПеречисление всех отделов\n" +
                "ID|Название отдела");
            var i2 = from x in rooms select x;
            foreach (var x in i2) Console.WriteLine(x);

            Console.WriteLine("\nМежду сотрудниками и отделами существует свзь М:М\n" +
                "Количество сотрудников в каждом отделе\n" +
                "ID|Название отдела|Количество сотрудников");
            foreach (var x in rooms)
            {
                var i8 = from y in rel
                         where (y.id_department == x.id_department)
                         select y;
                Console.WriteLine(x + " " + i8.Count()+"|");
            }
            Console.WriteLine("\nСотрудники каждого отдела");
            foreach (var x in rooms)
            {
                //Перебор по связям отдел-сотрудник
                var i6 = from y in rel
                         where (y.id_department == x.id_department)
                         select y;
                //Перебор по списку сотрудников
                var i7 = from y in workers
                         from z in i6
                         where (z.id_worker == y.id_worker)
                         select y;
                Console.WriteLine(x.id_department+"-------"+x.title);
                foreach (var y in i7) Console.WriteLine(y);
            }

            Console.WriteLine("\nСотрудники, состоящие в 2-х и более отделах");
            foreach (var x in workers)
            {
                var i11 = from y in rel
                          where (x.id_worker == y.id_worker)
                          select y;
                if (i11.Count() > 1)
                    Console.WriteLine(x);
            }
            Console.ReadKey();
        }
    }
}

namespace office
{
    class Worker
    {
        public int id_worker;
        public string surname;
        public Worker() { }
        public Worker(int a, string s)
        {
            this.id_worker = a;
            this.surname = s;
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            return this.id_worker.ToString() + "| " + this.surname + b.Append(Convert.ToChar(32), 15 - this.surname.Length)+"|";
        }
    }
    class Department
    {
        public int id_department;
        public string title;
        public Department() { }
        public Department(int a, string s)
        {
            this.id_department = a;
            this.title = s;
        }
        public override string ToString()
        {
            StringBuilder b = new StringBuilder();
            return this.id_department.ToString() + "| " + this.title.ToString() + b.Append(Convert.ToChar(32), 15 - this.title.Length) + "|";
        }
    }
    class Relations
    {
        public int id_worker;
        public int id_department;
        public Relations(int a, int b)
        {
            this.id_worker = a;
            this.id_department = b;
        }
        public override string ToString()
        {
            return this.id_worker.ToString() + "| " + this.id_department + "|";
        }
    }
}
