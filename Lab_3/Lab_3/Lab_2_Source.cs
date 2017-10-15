using System;

namespace Lab_3
{
    interface IPrint
    {
        void print();
    }
    abstract class Figure : IComparable, IPrint
    {
        virtual public double square() { return 0; }
        public int CompareTo(object obj)
        {
            Figure f1 = obj as Figure;
            if (f1 == null)
                throw new ArgumentException("obj is not Figure!!!");
            //if (this.square() > f1.square()) return 1;
            //else if (this.square() == f1.square()) return 0;
            //else return -1;
            return this.square().CompareTo(f1.square());
        }
        abstract public void print();

    }
    class Circle : Figure
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
                if (value < 0)
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
            res = "Class: Circle," +
               $" Area: {Math.Round(square(), 3)}";
            return res;
        }
        public override double square()
        {
            return Math.PI * r * r;
        }
        public override void print()
        {
            Console.WriteLine(this.ToString());
        }

    }
    class Rect : Figure
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
        public Rect(double a1, double b1)
        {
            A = a1;
            B = b1;
        }
        public override string ToString()
        {
            string res;
            res = "Class: Rectangle," +
               $" Area: {Math.Round(square(),3)}";
            return res;
        }
        public override double square()
        {
            return A * B;
        }
        public override void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class Square : Rect
    {
        private double a;
        //public override double A
        //{
        //    get
        //    {
        //        return a;
        //    }
        //    set
        //    {
        //        if (value < 0)
        //            throw new ArgumentOutOfRangeException($"{nameof(value)} должно быть положительным!");
        //        a = value;
        //    }
        //}
        public override string ToString()
        {
            string res;
            res = "Class: Square," +
               $" Area: {Math.Round(square(), 3)}";
            return res;
        }
        //public override double square()
        //{
        //    return A * A;
        //}
        public Square(double a1) : base(a1,a1)
        {
        }
    }
}
