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
    }
}
