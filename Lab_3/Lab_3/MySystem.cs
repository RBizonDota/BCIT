using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class MySystem
    {
        public void pause()
        {
            Console.WriteLine("Press any button...");
            Console.ReadKey();
        }
        public void printPalka(int l)
        {
            for (int i = 0; i < l; i++)
            {
                Console.Write("=");
            }
            Console.Write("\n");
        }
        public Figure GenerFigure(int param, Random rand)
        {
            Figure res = null;
            int a = rand.Next(3);
            switch (a)
            {
                case 0:
                    res = new Circle(rand.Next(param));
                    break;
                case 1:
                    res = new Rect(rand.Next(param), rand.Next(param));
                    break;
                case 2:
                    res = new Square(rand.Next(param));
                    break;
            }
            return res;
        }
    }
}
