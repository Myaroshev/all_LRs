using System;
using System.Collections.Generic;

namespace PL_lab4
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
        }






        static void Main(string[] args)
        {
            while (true)
            {
                menu();

                Console.Write("\nВыберите действие: ");
                string choice = Console.ReadLine();

                int n;
                if (!int.TryParse(choice, out n))
                {
                    Console.WriteLine("Введите число!");
                }
                Console.WriteLine();



                switch (n)
                {
                    case 1:
                        Console.Clear();

                        try 
                        {
                            //список типа int
                            List<int> numbers = new List<int> { };
                            Console.Write("Список типа 'int' (end - для завершения): ");
                            while (true)
                            {
                                string input = Console.ReadLine();
                                if (input.ToLower() == "end")
                                {
                                    break;
                                }

                                if (int.TryParse(input, out int number))
                                {
                                    numbers.Add(number);
                                }
                                else
                                {
                                    Console.WriteLine("Введите число/'end' для завершения");
                                }
                            }
                            bool duplicates = Class1<int>.isElements(numbers);

                            foreach (int i in numbers)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.Write($"- Дублирующиеся элементы есть? - {duplicates}");

                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");




                            //список типа string
                            List<string> strings = new List<string> { };
                            Console.Write("Список типа 'string' (end - для завершения): ");
                            while (true)
                            {
                                string input = Console.ReadLine();
                                if (input.ToLower() == "end")
                                {
                                    break;
                                }

                                strings.Add(input);
                            }


                            bool duplicates_string = Class1<string>.isElements(strings);
                            foreach (string i in strings)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.Write($"- Дублирующиеся элементы есть? - {duplicates_string}");

                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");




                            //список типа double
                            List<double> numbers_two = new List<double> { };
                            Console.Write("Список типа 'double' (end - для завершения): ");
                            while (true)
                            {
                                string input = Console.ReadLine();
                                if (input.ToLower() == "end")
                                {
                                    break;
                                }

                                if (double.TryParse(input, out double number))
                                {
                                    numbers_two.Add(number);
                                }
                                else
                                {
                                    Console.WriteLine("Введите число/'end' для завершения");
                                }
                            }

                            bool duplicates_two = Class1<double>.isElements(numbers_two);
                            foreach (double i in numbers_two)
                            {
                                Console.Write($"{i} ");
                            }
                            Console.Write($"- Дублирующиеся элементы есть? - {duplicates_two}");

                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        catch(Exception e) 
                        {
                            Console.WriteLine(e.Message);
                        }
                        

                        break;





                    case 2:
                        Console.Clear();

                        try 
                        {

                            LinkedList<double> L = new LinkedList<double>();

                            while (true) 
                            {
                                Console.WriteLine("Введите число для добавления в список или 'end' для завершения:");
                                string input = Console.ReadLine();

                                if (input.ToLower() == "end")
                                {
                                    break;
                                }

                                if (double.TryParse(input, out double number))
                                {
                                    Console.WriteLine("Добавить в f/F(начало) или l/L(конец) списка?");
                                    string position = Console.ReadLine();

                                    if (position == "f" || position == "F")
                                    {
                                        L.AddFirst(number);
                                    }
                                    else if (position == "l" || position == "L")
                                    {
                                        L.AddLast(number);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ошибка ввода. Число добавлено в конец");
                                        L.AddLast(number);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Вводите только числа или 'end' для выхода");
                                }

                            }

                            Console.WriteLine();
                            Console.WriteLine("Список:");
                            foreach (var item in L)
                            {
                                Console.Write($"{item} ");
                            }

                            Console.WriteLine();
                            Console.WriteLine();
                            Console.Write("Введите элемент, который хотите удалить:");
                            string n_input = Console.ReadLine();
                            double n2;
                            if (!double.TryParse(n_input, out n2))
                            {
                                Console.WriteLine("Введите число!");
                                continue;
                            }

                            Console.WriteLine();

                            Console.Write("Введите направление списка:");
                            string direction = Console.ReadLine();

                            Class1<double>.remove_items(L, n2, direction);

                            Console.WriteLine();
                            Console.WriteLine("Новый список:");
                            foreach (var item in L)
                            {
                                Console.Write($"{item} ");
                            }


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        Console.WriteLine();
                        Console.WriteLine();

                        break;





                    case 3:
                        Console.Clear();

                        try
                        {
                            //все произведения
                            HashSet<string> musics = new HashSet<string>
                            {
                                "Произведение 1",
                                "Произведение 2",
                                "Произведение 3",
                                "Произведение 4",
                                "Произведение 5"
                            };

                            //музыка у меломанов
                            HashSet<string> meloman_1 = new HashSet<string> { "Произведение 1", "Произведение 2", "Произведение 3", "Произведение 4" };
                            HashSet<string> meloman_2 = new HashSet<string> { "Произведение 2", "Произведение 3" };
                            HashSet<string> meloman_3 = new HashSet<string> { "Произведение 1", "Произведение 3", "Произведение 4" };

                            //нравятся всем
                            HashSet<string> all_music_liked = Class1<string>.all_likes(musics, meloman_1, meloman_2, meloman_3);

                            //нравятся некоторым
                            HashSet<string> someone_liked = Class1<string>.someone_likes(meloman_1, meloman_2, meloman_3);

                            //никому не нравятся
                            HashSet<string> none_liked = Class1<string>.none_likes(musics, someone_liked);

                            Console.WriteLine($"Нравятся всем: {string.Join(", ", all_music_liked)}");
                            Console.WriteLine($"Нравятся некоторым: {string.Join(", ", someone_liked)}");
                            Console.WriteLine($"Никому не нравятся: {string.Join(", ", none_liked)}");



                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);


                        }

                        Console.WriteLine();
                        Console.WriteLine();

                        break;










                    case 4:
                        Console.Clear();

                        try
                        {
                            string source_file = "source_file3.txt";
                            //string source_file = "source_file.txt";

                            HashSet<char> unique_letters = Class1<string>.unique_letters(source_file);

                            Dictionary<char, int> letters_dict = new Dictionary<char, int>
                            {
                                { 'а', 1 },
                                { 'е', 2 },
                                { 'ё', 3 },
                                { 'и', 4 },
                                { 'о', 5 },
                                { 'у', 6 },
                                { 'ы', 7 },
                                { 'э', 8 },
                                { 'ю', 9 },
                                { 'я', 10 }
                            };


                            
                            var sorted_letters = new List<char>();
                                                                   
                            foreach (var letter in unique_letters)
                            {
                                if (letters_dict.ContainsKey(letter))
                                {
                                    sorted_letters.Add(letter);
                                }
                            }


                            sorted_letters.Sort();

                            Console.WriteLine("Гласные буквы, которые не входят более чем в одно слово:");
                            foreach (var letter in sorted_letters)
                            {
                                Console.WriteLine(letter);
                            }



                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);


                        }

                        Console.WriteLine();
                        Console.WriteLine();

                        break;


                }



            }

        }
    }
}
