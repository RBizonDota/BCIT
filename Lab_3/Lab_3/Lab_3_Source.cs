using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    class TestArray :IPrint
    {
        ArrayList arr1;
        Random rand;
        public TestArray()
        {
            arr1 = new ArrayList();
            rand = new Random();
        }
        public void Gener(int rmax, int times)
        {
            for (int i = 0; i < times; i++)
            {
                Figure res = null;
                int a = rand.Next(3);
                switch (a)
                {
                    case 0:
                        res = new Circle(rand.Next(rmax));
                        break;
                    case 1:
                        res = new Rect(rand.Next(rmax), rand.Next(rmax));
                        break;
                    case 2:
                        res = new Square(rand.Next(rmax));
                        break;
                }
                arr1.Add(res);
            }
        }
        public void print()
        {
            foreach (Figure f in arr1)
            {
                f.print();
            }
        }
        public void Sort()
        {
            arr1.Sort();
        }
    }
}
