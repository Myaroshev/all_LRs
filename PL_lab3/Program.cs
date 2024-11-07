using System.ComponentModel.Design;

namespace PL_lab3
{
    internal class Program
    {
        static void menu() 
        {
            Console.WriteLine("1. Задание №1");
            Console.WriteLine("2. Задание №2");
            Console.WriteLine("3. Задание №3");
            Console.WriteLine("4. Задание №4");
        }

        static void Main(string[] args)
        {
            while(true) 
            {
                menu(); 

                Console.Write("\nВыберите действие: ");
                int choice = int.Parse(Console.ReadLine());

                switch(choice) 
                {
                    case 1:
                        Console.Clear();

                        while (true) 
                        {
                            Console.Write("Введите число строк (n):");
                            string n_input = Console.ReadLine();

                            if (n_input == "0")
                            {
                                Console.Clear();
                                break;
                            }

                            Console.Write("Введите число столбцов (m):");
                            string m_input = Console.ReadLine();



                            int n;
                            if (!int.TryParse(n_input, out n))
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }
                            int m;
                            if (!int.TryParse(m_input, out m))
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }



                            try
                            {
                                Console.WriteLine();
                                Console.WriteLine("-----#Первый массив#-----");
                                Class1 matrix1 = new Class1(n, m);
                                matrix1.Print();
                                Console.WriteLine();


                                Console.WriteLine("-----#Второй массив#-----");
                                Class1 matrix2 = new Class1(n);
                                matrix2.Print();
                                Console.WriteLine();

                                short new_n = (short)n;
                                Console.WriteLine("-----#Третий массив#-----");
                                Class1 matrix3 = new Class1(new_n, new_n, new_n);
                                matrix3.Print();
                                Console.WriteLine();



                                break;
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }

                        }

                        break;


                    case 2:
                        Console.Clear();

                        while (true)
                        {
                            string sourceFile = "source.bin";

                            Console.Write("Введите размер файла:");
                            string file_size = Console.ReadLine();

                            if (file_size == "0")
                            {
                                Console.Clear();
                                break;
                            }


                            int n;
                            if (!int.TryParse(file_size, out n))
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }

                            try
                            {
                                //генерация бинарного файла
                                Class1.generateFile(sourceFile, n);
                                Console.WriteLine($"Исходный файл '{sourceFile}' создан");

                                Console.WriteLine();

                                using (BinaryReader reader = new BinaryReader(File.Open(sourceFile, FileMode.Open)))
                                {
                                    while (reader.PeekChar() != -1) 
                                    {
                                        int number = reader.ReadInt32(); 
                                        Console.Write($"{number} ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }


                        break;

                }










            }












        }
    }
}
