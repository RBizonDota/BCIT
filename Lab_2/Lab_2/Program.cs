using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    abstract class Figure
    {
        virtual public double square() { return 0; }
    }
    interface IPrint
    {
        void print();
    }
    class Circle : Figure , IPrint
    {
        private double r;
        public double radius
        {
            get
            {
                return r;
            }
            set
            {
                if (value<0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным!");
                r = value;
            }
        }
        public Circle(double r1)
        {
            radius = r1;
        }
        public override string ToString()
        {
            string res;
            res = "Class: Circle \n" +
               $"radius: {radius}\n" +
               $"Area: {square()}";
            return res;
        }
        public override double square()
        {
            return Math.PI * r * r;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Rect : Figure, IPrint
    {
        private double a;
        private double b;
        virtual public double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным!");
                a = value;
            }
        }
        virtual public double B
        {
            get
            {
                return b;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным!");
                b = value;
            }
        }

        public Rect(double a1)
        {
            A = a1;
            B = a1;
        }
        public Rect(double a1,double b1)
        {
            A = a1;
            B = b1;
        }
        public override string ToString()
        {
            string res;
            res = "Class: Rectangle \n" +
               $"Height: {A}\n"+
               $"Width: {B}\n"+
               $"Area: {square()}";
            return res;
        }
        public override double square()
        {
            return A*B;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rect
    {
        private double a;
        public override double A
        {
            get
            {
                return a;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным!");
                a = value;
            }
        }
        public override string ToString()
        {
            string res;
            res = "Class: Square \n" +
               $"Side: {A}\n" +
               $"Area: {square()}";
            return res;
        }
        public override double square()
        {
            return A * A;
        }
        public Square(double a1): base(a1)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool t = true;
            bool p = true;
            while (p)
            {
                Console.Clear();
                if(t) Console.WriteLine("Lab_2 by Baybarin R.\n");
                t = false;
                Console.Write("============\n" +
                              "Menu\n" +
                              "============\n" +
                              "1) Circle\n" +
                              "2) Rectangle\n" +
                              "3) Square\n" +
                              "0) Exit\n" +
                              "============\n" +
                              "Your choice: ");
                int caseSwitch;
                double k, l;
                bool f;
                f = int.TryParse(Console.ReadLine(), out caseSwitch);
                if (!f||caseSwitch<0||caseSwitch>3)
                {
                    Console.WriteLine("ERROR!!!!!");
                    continue;
                }
                switch (caseSwitch)
                {
                    case 0:
                        p = false;
                        Console.WriteLine("Exiting...Press Enter");
                        break;
                    case 1:
                        Console.Write("Enter radius: ");
                        f = double.TryParse(Console.ReadLine(), out k);
                        if (!f)
                        {
                            Console.WriteLine("ERROR!!!!!");
                            continue;
                        }
                        Console.WriteLine("Printing data...\n" +
                                          "============");
                        Circle a = new Circle(k);
                        a.print();
                        break;
                    case 2:
                        Console.Write("Enter height: ");
                        f = double.TryParse(Console.ReadLine(), out k);
                        if (!f)
                        {
                            Console.WriteLine("ERROR!!!!!");
                            continue;
                        }
                        Console.Write("Enter width: ");
                        f = double.TryParse(Console.ReadLine(), out l);
                        if (!f)
                        {
                            Console.WriteLine("ERROR!!!!!");
                            continue;
                        }
                        Rect b = new Rect(k, l);
                        b.print();
                        break;
                    case 3:
                        Console.Write("Enter side: ");
                        f = double.TryParse(Console.ReadLine(), out k);
                        if (!f)
                        {
                            Console.WriteLine("ERROR!!!!!");
                            continue;
                        }
                        Console.WriteLine("Printing data...");
                        Square c = new Square(k);
                        c.print();
                        break;
                }
                string s = Console.ReadLine();
            }
        }
    }
}
