using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Lab_1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                double a, b, c;
                string s;
                bool f;
                Console.Clear();
                Console.Write("A*x^2+B*x+C=0\nEnter A (A<>0): ");
                f = double.TryParse(Console.ReadLine(), out a);
                if ((!f)||(a==0))
                {
                    Console.WriteLine("ERROR!!!!!");
                    s = Console.ReadLine();
                    continue;
                }
                Console.Write("Enter B: ");
                f = double.TryParse(Console.ReadLine(), out b);
                if (!f)
                {
                    Console.WriteLine("ERROR!!!!!");
                    s = Console.ReadLine();
                    continue;
                }
                Console.Write("Enter C: ");
                f = double.TryParse(Console.ReadLine(), out c);
                if (!f)
                {
                    Console.WriteLine("ERROR!!!!!");
                    s = Console.ReadLine();
                    continue;
                }
                double d = b * b - 4 * a * c;
                if (d > 0)
                {
                    Console.Write("x1 = " + ((-1)*b - Math.Sqrt(d)) / 2 / a + "; x2 = " + ((-1)*b + Math.Sqrt(d)) / 2 / a + ";\n");
                }
                else if (d == 0)
                {
                    Console.Write("x1 = x2 = " + (-1)*b / 2 / a + ";\n");
                }
                else
                {
                    Console.Write("x1= " + (-1)*b / 2 / a + "-" + Math.Sqrt(-1*d) / 2 / a + "*i; x2= " + (-1)*b / 2 / a + "+" + Math.Sqrt(-1 * d) / 2 / a + "*i;\n");
                }
                s = Console.ReadLine();
            }
        }
    }
}
