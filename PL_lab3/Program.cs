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
            Console.WriteLine("5. Задание №5");
            Console.WriteLine("6. Задание №6");
            Console.WriteLine("7. Задание №7");
            Console.WriteLine("8. Задание №8");
        }

        static void Main(string[] args)
        {
            while(true) 
            {
                menu(); 

                Console.Write("\nВыберите действие: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
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
                                Console.WriteLine($"{matrix1.ToString()}");
                                Console.WriteLine();


                                Console.WriteLine("-----#Второй массив#-----");
                                Class1 matrix2 = new Class1(n);
                                Console.WriteLine($"{matrix2.ToString()}");
                                Console.WriteLine();

                                break;
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }

                        }

                        break;



                    case 3:
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
                                Int16 new_n = (Int16)n;
                                Int16 new_m = (Int16)m;

                                Class1 matrix_1 = new Class1(new_n, new_m);
                                Class1 matrix_2 = new Class1(new_n, new_m);
                                Class1 matrix_3 = new Class1(new_n, new_m);

                                Console.WriteLine($"\nматрица А:\n{matrix_1.ToString()}");
                                Console.WriteLine($"\nматрица В:\n{matrix_2.ToString()}");
                                Console.WriteLine($"\nматрица С:\n{matrix_3.ToString()}");

                                Console.WriteLine();


                                Console.WriteLine();

                                //A[t] - (B + C[t])
                                Class1 summ_matrix = matrix_2 + matrix_3.Transp();
                                Console.WriteLine($"\nСумма матриц:\n{summ_matrix.ToString()}");
                                Class1 answer = matrix_1.Transp() - summ_matrix;
                                Console.WriteLine($"\nПолученная матрица:\n{answer.ToString()}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;





                    case 4:
                        Console.Clear();

                        while (true)
                        {
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
                                string sourceFile = "file.bin";
                                string sourceFile_2 = "file2.bin";

                                //генерация бинарного файла
                                Class2.generateFile(sourceFile, n);
                                Console.WriteLine($"Файл '{sourceFile}' создан");
                                Console.WriteLine($"Файл '{sourceFile_2}' создан");

                                Console.WriteLine();

                                Console.WriteLine("/*");
                                //чтение из бинарного файла
                                using (BinaryReader reader = new BinaryReader(File.Open(sourceFile, FileMode.Open)))
                                {
                                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                                    {
                                        int number = reader.ReadInt32();//читаем целое число
                                        Console.Write($"{number} ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("*/");


                                Console.Write("Введите k:");
                                string input_k = Console.ReadLine();


                                int k;
                                if (!int.TryParse(input_k, out k))
                                {
                                    Console.WriteLine("Введите число!");
                                    continue;
                                }




                                Class2.read_k(sourceFile, sourceFile_2, k);

                                Console.WriteLine();
                                Console.WriteLine($"Готовый файл(числа, кратные {k}):");

                                //чтение из бинарного файла_#2
                                using (BinaryReader reader = new BinaryReader(File.Open(sourceFile_2, FileMode.Open)))
                                {
                                    while (reader.BaseStream.Position < reader.BaseStream.Length)
                                    {
                                        int number = reader.ReadInt32();//читаем целое число
                                        Console.Write($"{number} ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine("*/");



                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;







                    case 5:
                        Console.Clear();

                        while (true)
                        {
                            Console.Write("Введите количество игрушек: ");
                            string file_size = Console.ReadLine();
                            Console.WriteLine();

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
                                string sourceFile = "toys.xml";

                                Class2.toys_xml(sourceFile, n);
                                Console.WriteLine($"Данные сохранены в '{sourceFile}'");

                                Console.WriteLine($"Стоимость самого дорогого конструктора: {Class2.expensive_toy(sourceFile)} руб.");
                                Console.WriteLine();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;





                    case 6:
                        Console.Clear();

                        while (true)
                        {
                            Console.Write("Введите количество цифр на генерацию: ");
                            string file_size = Console.ReadLine();
                            Console.WriteLine();

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
                                string sourceFile = "numbers.txt";

                                Class2.fill_file(sourceFile, n);
                                Console.WriteLine($"Файл '{sourceFile}' заполнен {n} случайными числами");
                                Console.WriteLine();
                                Console.WriteLine("/*");
                                Class2.file_print(sourceFile);
                                Console.WriteLine("*/");
                                Console.WriteLine();
                                Console.WriteLine($"Сумма элементов, равных своим индексам: {Class2.sum_elements(sourceFile)}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;







                    case 7:
                        Console.Clear();

                        while (true)
                        {
                            Console.Write("Введите количество строк: ");
                            string file_size = Console.ReadLine();
                            Console.WriteLine();

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

                            Console.Write("Введите количество цифр в строке: ");
                            string line_size = Console.ReadLine();
                            Console.WriteLine();

                            int lines;
                            if (!int.TryParse(line_size, out lines))
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }




                            try
                            {
                                string sourceFile = "numbers2.txt";

                                Class2.fill_file_line(sourceFile, n, lines);
                                Console.WriteLine($"Файл '{sourceFile}' заполнен {n} случайными строками по {lines} чисел");

                                Class2.file_print_lines(sourceFile);

                                Console.Write("Введите k: ");
                                string k_size = Console.ReadLine();
                                Console.WriteLine();
                                int k;
                                if (!int.TryParse(k_size, out k))
                                {
                                    Console.WriteLine("Введите число!");
                                    continue;
                                }

                                Console.WriteLine($"Произведение элементов, кратных {k} ({Class2.calculate_numbers_k(sourceFile, k)}): {Class2.calculate_k(sourceFile, k)}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"{ex.Message}");
                            }
                        }
                        break;







                    case 8:
                        Console.Clear();

                        while (true)
                        {
                            Console.Write("Введите любое число(0 - для выхода): ");
                            string file_size = Console.ReadLine();
                            Console.WriteLine();

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
                                string sourceFile = "text_file.txt";
                                string sourceFile_2 = "text_file_output.txt";


                                Class2.lines_without_russian(sourceFile, sourceFile_2);

                                Console.WriteLine($"Строки, не содержащие русские буквы, были записаны в '{sourceFile_2}'");

                                Class2.file_print_lines(sourceFile_2);


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
