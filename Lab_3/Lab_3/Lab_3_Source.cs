using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    
    
    public interface IMatrAdapter<T>
    {
       T getEmptyElement();
       bool checkEmptyElement(T element);
        T Gener(int param, Random rand);
    }
    public class FigureMatrixCheckEmpty : IMatrAdapter<Figure>
    {
        Figure IMatrAdapter<Figure>.getEmptyElement()
        {
            return null;
        }
        bool IMatrAdapter<Figure>.checkEmptyElement(Figure element)
        {
            bool res = false;
            if (element == null)
                res = true;
            return res;
        }
        Figure IMatrAdapter<Figure>.Gener(int param, Random rand)
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
    class Matrix<T>:IPrint
    {
        int xmax, ymax, zmax;
        public IMatrAdapter<T> Adap;
        Dictionary<string, T> _matr = new Dictionary<string, T>();
        public Matrix(int _xmax, int _ymax, int _zmax, IMatrAdapter<T> IMCE)
        {
            xmax = _xmax;
            ymax = _ymax;
            zmax = _zmax;
            Adap = IMCE;
        }
        public T this[int x, int y, int z]
        {
            set
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matr.ContainsKey(key))
                {
                    this._matr[key] = value;
                }
                else
                {
                    this._matr.Add(key, value);
                }
            }
            get
            {
                CheckBounds(x, y, z);
                string key = DictKey(x, y, z);
                if (this._matr.ContainsKey(key))
                {
                    return this._matr[key];
                }
                else
                {
                    return this.Adap.getEmptyElement();
                }
            }
        }
        void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= xmax)
                throw new ArgumentOutOfRangeException("WRONG x");
            if (y < 0 || y >= ymax)
                throw new ArgumentOutOfRangeException("WRONG y");
            if (z < 0 || z >= zmax)
                throw new ArgumentOutOfRangeException("WRONG z");

        }
        string DictKey(int x, int y, int z)
        {
            return x.ToString() + "_" + y.ToString()+"_"+ z.ToString();
        }
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            res.Append("x | y | z | value\n");
            for (int i = 0; i < xmax; i++)
            {
                for (int j = 0; j < ymax; j++)
                {
                    for (int k = 0; k < zmax; k++)
                    {
                        if (!Adap.checkEmptyElement(this[i, j, k]))
                        {
                            res.Append(i.ToString()+" | "+j.ToString() + " | "+k.ToString() + " | "+this[i, j, k].ToString()+"\n");
                        }
                    }
                }
            }
            res.Append("All other elements are empty\n");
            return res.ToString();
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class SimpleList<T>:IPrint
        where T:IComparable
    {
        protected SimpleListItem<T> first = null;
        protected SimpleListItem<T> last = null;
        int _count;
        public int count
        {
            get
            {
                return _count;
            }
            protected set
            {
                _count = value;
            }
        }
        public void Add(T element)
        {
            SimpleListItem<T> a = new SimpleListItem<T>(element);
            if (this.last == null)
            {
                first = a;
                last = a;
            }
            else
            {
                last.next = a;
                last = a;
            }
            count++;
        }
        public SimpleListItem<T> getItem(int number)
        {
            if (number < 0 || number >= count)
            {
                throw new ArgumentException("WRONG INDEX");
            }
            else
            {
                int i = 0;
                SimpleListItem<T> buf = this.first;
                while (i<number)
                {
                    i++;
                    buf = buf.next;
                }
                return buf;
            }
        }
        public T Get(int number)
        {
            return getItem(number).data;
        }
        public void print()
        {
            Console.WriteLine(this.ToString());
        }
    }
    class SimpleListItem<T>
        where T : IComparable
    {
        public SimpleListItem(T param)
        {
            data = param;
        }
        public T data
        {
            get
            {
                return _data;
            }
            set
            {
                _data = value;
            }
        }
        T _data;
        public SimpleListItem<T> next
        {
            get
            {
                return _next;
            }
            set
            {
                _next = value;
            }
        }
        SimpleListItem<T> _next = null;
    }
    class Menu
    {
        MySystem mySys = new MySystem();
        int intReadKey()
        {
            int res;
            bool f = int.TryParse(Console.ReadLine(), out res);
            if (!f)
                throw new Exception("Wrong input");
            return res;
        }
        void case1()
        {
            Console.Clear();
            Console.Write("Enter number of elements. Array will be filled by randomly generated figures: ");
            TestArray a = new TestArray();
            a.Gener(10, intReadKey());
            mySys.printPalka(20);
            a.print();
            mySys.printPalka(20);
            Console.WriteLine("Sorting...");
            mySys.printPalka(20);
            a.Sort();
            a.print();
        }
        void case2()
        {
            Console.Clear();
            Console.Write("Enter maximum size: ");
            int rmax= intReadKey();
            Console.Write("Enter number of elements generated: ");
            int times = intReadKey();
            mySys.printPalka(20);
            Random rand = new Random();
            Matrix<Figure> matr = new Matrix<Figure>(rmax,rmax,rmax,new FigureMatrixCheckEmpty());
            for (int i = 0; i < times; i++)
            {
                int i0 = rand.Next(rmax), i1 = rand.Next(rmax), i2 = rand.Next(rmax);
                matr[i0, i1, i2] = matr.Adap.Gener(10, rand);
            }
            Console.WriteLine("Printing existing elements...");
            mySys.printPalka(20);
            matr.print();
        }
        void case3()
        {

        }
        public void run()
        {
            bool t = true;
            bool p = true;
            while (p)
            {
                Console.Clear();
                if (t) Console.WriteLine("Lab_3 by Baybarin R.\n");
                t = false;
                Console.Write("============\n" +
                              "Menu\n" +
                              "============\n" +
                              "1) Testing ArrayList.Sort()\n" +
                              "2) Testing Sparse Matrix\n" +
                              "3) Testing SimpleList\n" +
                              "0) Exit\n" +
                              "============\n" +
                              "Your choice: ");
                int caseSwitch;
                bool f;
                f = int.TryParse(Console.ReadLine(), out caseSwitch);
                if (!f || caseSwitch < 0 || caseSwitch > 3)
                {
                    Console.WriteLine("ERROR!!!!! WRONG INPUT");
                    Console.ReadLine();
                    continue;
                }
                switch (caseSwitch)
                {
                    case 0:
                        p = false;
                        Console.WriteLine("Exiting...Press Enter");
                        break;
                    case 1: case1();
                        break;
                    case 2: case2();
                        break;
                    case 3: case3();
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
