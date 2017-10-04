using System;

namespace Lab_3
{
    interface IPrint
    {
        void print();
    }
    interface IComparable
    {
        double getS();
    }
    abstract class Figure : IComparable
    {
        public double getS() => square();
        virtual public double square() { return 0; }
    }
    class Circle : Figure, IPrint
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
            res = "Class: Circle \n" +
               $"radius: {radius}\n" +
               $"Square: {square()}";
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
        public Rect(double a1, double b1)
        {
            A = a1;
            B = b1;
        }
        public override string ToString()
        {
            string res;
            res = "Class: Rectangle \n" +
               $"Height: {A}\n" +
               $"Width: {B}\n" +
               $"Square: {square()}";
            return res;
        }
        public override double square()
        {
            return A * B;
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
               $"Square: {square()}";
            return res;
        }
        public override double square()
        {
            return A * A;
        }
        public Square(double a1) : base(a1)
        {
        }
    }
}
