using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Addition;

namespace HomeWork4
{
    class Program
    {
        public static void Task1()
        {
            int sum = 0;
            int[] a=new int[20];
            Random r = new Random();
            for(int i = 0; i < 20; i++)
            {
                r.Next(-10_000, 10_000);
                a[i] = r.Next(-10_000, 10_000);
            }
            for(int i = 0; i < 19; i++)
            {
                if ((a[i] % 3 == 0) || a[i + 1] % 3 == 0) sum++;
            }
            for(int i = 0; i < 20; i++)
            {
                Console.Write($"{a[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine($"Из этих чисел {sum} последовательных пар");
        }

        static void Main(string[] args)
        {
            Task1();
            Console.WriteLine();
            Console.WriteLine("Создаем массив с начальным элементом и шагом");
            OD_Array od_array = new OD_Array(10, 1);
            Console.WriteLine(od_array.ToString());
            Console.WriteLine("Создаем массив через файл");
            od_array = new OD_Array("input file for od.txt");
            Console.WriteLine(od_array.ToString());
            Console.WriteLine("Сумма элементов: {0}",od_array.Sum);
            Console.WriteLine("Меняем знак в массиве");
            od_array.Inverse();
            Console.WriteLine("Вышло");
            Console.WriteLine(od_array.ToString());
            Console.WriteLine("Вернем обратно, но через умножение");
            od_array.Multi(-1);
            Console.WriteLine("Вышло");
            Console.WriteLine(od_array.ToString());
            Console.WriteLine("MaxCount: {0}", od_array.MaxCount);
            Console.WriteLine("Запишем массив, умноженный на 5 в файл");
            od_array.Multi(5);
            od_array.WriteToFile("output file for od.txt");
            Console.WriteLine("Создаем двумерный массив, сразу считывая из файла");
            TD_Array td_array = new TD_Array("input file for td.txt");
            Console.WriteLine(td_array.ToString());
            Console.WriteLine("Сумма всех чисел в массиве: "+ td_array.Sum());
            Console.WriteLine("Сумма всех чисел в массиве больше 4: " + td_array.Sum(4));
            Console.WriteLine("Самый большой элемет массива: " + td_array.Max);
            int i, j;
            td_array.IndexOfMax(out i,out j);
            Console.WriteLine($"Индекс самого большого элемета массива: {i},{j}");
            Console.WriteLine("Самый маленький элемет массива: " + td_array.Min);
            Console.WriteLine("Запишем случайно созданный двумерный массив в файл");
            td_array = new TD_Array(5, 5);
            Console.WriteLine(td_array.ToString());
            td_array.WriteToFile("output file for td.txt");
            Console.ReadKey();
        }
    }
}
