using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class Program
    {
        
        static void Main()
        {
            TestArray a = new TestArray();
            Random c = new Random();
            a.Gener(10, 6);
            a.print();
            Console.ReadKey();
            Console.Clear();
            Square s1 = new Square(2), s2 = new Square(1);
            a.Sort();
            a.print();
            Console.ReadKey();
        }
    }
}
