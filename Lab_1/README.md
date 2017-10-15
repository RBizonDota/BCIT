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

### II. [Код программы](/Lab_1/Program.cs)

### III. Примеры работы программы 
```
A*x^2+B*x+C=0
Enter A (A<>0): 1
Enter B: -4
Enter C: 3
x1 = 1; x2 = 3;
```
```
A*x^2+B*x+C=0
Enter A (A<>0): 1
Enter B: 24
Enter C: 15556
x1= -12-124,145076422708*i; x2= -12+124,145076422708*i;
```
```
A*x^2+B*x+C=0
Enter A (A<>0): 2
Enter B: 14
Enter C: 2
x1 = -6,85410196624968; x2 = -0,145898033750315;
```