Федеральное государственное бюджетное образовательное учреждение высшего профессионального образования 
Московский государственный технический университет имени Н.Э. Баумана
(МГТУ им. Н.Э. Баумана)
 

# ОТЧЁТ ПО ЛАБОРАТОРНОЙ РАБОТЕ №1
## ПО ДИСЦИПЛИНЕ «БАЗОВЫЕ КОМПОНЕНТЫ ИНТЕРНЕТ ТЕХНОЛОГИЙ»
 





<p align="right">Выполнил(а): Байбарин Р. Г.</p>

<p align="right">Проверил(а): Гапанюк Ю.Е.</p>




<p align="center">Москва, 2017</p>

---

### I.	Описание задания
Разработать программу для решения квадратного уравнения.
1.	Программа должна быть разработана в виде консольного приложения на языке C#.
2.	Программа осуществляет ввод с клавиатуры коэффициентов А, В, С, вычисляет дискриминант и корни уравнения (в зависимости от дискриминанта).
3.	Если коэффициент А, В, С введен некорректно, то необходимо проигнорировать некорректное значение и ввести коэффициент повторно.

Квадратное уравнение вида A*x^2+B*x+C=0 имеет всегда два корня. В зависимости от дискриминанта они могут быть 2 различных действительных (D>0), 2 действительных одинаковых (D=0) или 2 различных комплексных (D<0).
Все 3 варианта реализованы.

### II. Код программы

[Текст программы](Lab_1/Program.cs)

[Text link][ref]
[ref]: link

```cs
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
                    Console.Write("x1 = " + ((-1)*b - Math.Sqrt(d)) / 2 / a + "; x2= " + ((-1)*b + Math.Sqrt(d)) / 2 / a + ";\n");
                }
                else if (d == 0)
                {
                    Console.Write("x1=x2= " + (-1)*b / 2 / a + ";\n");
                }
                else
                {
                    Console.Write("x1= " + (-1)*b / 2 / a + "-" + Math.Sqrt(-1*d) / 2 / a + "*i; x2= " + (-1)*b / 2 / a + "-" + Math.Sqrt(-1 * d) / 2 / a + "*i;\n");
                }
                s = Console.ReadLine();
            }
        }
    }
}
```
