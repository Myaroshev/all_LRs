using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PL_lab3
{
    internal class Class1
    {
        int[,] array;

        //конструктор_1
        public Class1(int n, int m)
        {
            array = new int[n, m];

            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Размер матрицы должен быть больше нуля\n");
            }

            Console.WriteLine("Введите элементы матрицы по столбцам:");
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    Console.Write($"[{i},{j}]: ");
                    while (!int.TryParse(Console.ReadLine(), out array[i, j]))
                    {
                        Console.WriteLine("Неверный ввод! Введите число");
                        Console.Write($"[{i},{j}]: ");
                    }
                }
            }
        }

        //конструктор_2
        public Class1(int n)
        {
            array = new int[n, n];

            if (n <= 0)
            {
                Console.WriteLine("Размер матрицы должен быть больше нуля");
            }

            for (int j = 0; j < n; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    array[i, j] = Generator(n);
                }
            }
        }

        //конструктор_3
        public Class1(short n, short n1, short n2)
        {

            n = 5;
            if (n <= 0)
            {
                Console.WriteLine("Размер матрицы должен быть больше нуля");
            }

            array = new int[n, n];
            int k = 1;//счётчик для диагонали
            int current = n - 1;//для змейки

            //заполнение главной диагонали
            for (int i = 0; i < n; i++)
            {
                array[i, i] = k++;
            }

            for (int i = 0; i < n-1; i++) 
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (current >= 1)
                    {
                        array[i, j] = current--;
                    }
                }
                current = n - 1 - i - 1;
                if (current < 1)
                {
                    current = 1;
                }
            }
        }

        //заполнение конструктора_2
        public int Generator(int n) 
        {
            //n - заглушка
            Random random = new Random();
            int number = 0;

            number = random.Next(1, 5) * 2;

            for (int i = 1; i < 4; i++)
            {
                number = number * 10 + random.Next(0, 5) * 2;
            }

            return number;
        }


        //задание_3
        //конструктор_4
        public Class1(Int16 n, Int16 m)
        {
            Random random = new Random();
            array = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(1, 100);
                }
            }
        }

        public Class1(int[,] output_array)
        {
            this.array = output_array;
        }

        public Class1 Transp()
        {
            int[,] transposedArray = new int[array.GetLength(1), array.GetLength(0)];//меняем размеры для транспонированной матрицы

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    transposedArray[j, i] = array[i, j];//заполняем транспонированный массив
                }
            }

            //Console.WriteLine("Транспонированная матрица:");
            //for (int i = 0; i < transposedArray.GetLength(0); i++)
            //{
            //    for (int j = 0; j < transposedArray.GetLength(1); j++)
            //    {
            //        Console.Write(transposedArray[i, j] + "\t");
            //    }
            //    Console.WriteLine();
            //}

            return new Class1(transposedArray);//новый объект с трансп. матрицей
        }

        public static Class1 operator +(Class1 array_1, Class1 array_2) 
        {
            if (array_1.array.GetLength(0) != array_2.array.GetLength(0) || array_1.array.GetLength(1) != array_2.array.GetLength(1))
            {
                Console.WriteLine("Матрицы должны иметь одинаковую размерность");
            }

            int rows = array_1.array.GetLength(0);
            int cols = array_2.array.GetLength(1);
            Class1 result = new Class1(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.array[i, j] = array_1.array[i, j] + array_2.array[i, j];
                }
            }

            return result;
        }

        public static Class1 operator -(Class1 array_1, Class1 array_2)
        {
            if (array_1.array.GetLength(0) != array_2.array.GetLength(0) || array_1.array.GetLength(1) != array_2.array.GetLength(1))
            {
                Console.WriteLine("Матрицы должны иметь одинаковую размерность");
            }

            int rows = array_1.array.GetLength(0);
            int cols = array_2.array.GetLength(1);
            Class1 result = new Class1(rows, cols);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    result.array[i, j] = array_1.array[i, j] - array_2.array[i, j];
                }
            }

            return result;
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    result += array[i, j] + "\t";
                }
                result += "\n";
            }

            return result;
        }















    }
}
