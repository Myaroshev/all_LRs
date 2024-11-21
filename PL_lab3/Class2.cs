using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PL_lab3
{
    [Serializable]
    public struct Toys
    {
        public string Name;//название
        public double Price;//стоимость в рублях
        public int min_age;//мин возраст
        public int max_age;//макс возраст
    }




    internal class Class2
    {


        //-----------------------------------4 задание-----------------------------------
        public static void read_k(string inputfile_path, string outputfile_path, int k)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(inputfile_path, FileMode.Open)))
            using (BinaryWriter writer = new BinaryWriter(new FileStream(outputfile_path, FileMode.Create)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();

                    //если число кратно k, записываем его
                    if (number % k == 0)
                    {
                        writer.Write(number);
                    }
                }
            }
        }


        public static void generateFile(string file_path, int n)
        {
            Random random = new Random();

            using (BinaryWriter writer = new BinaryWriter(new FileStream(file_path, FileMode.Create)))
            {
                for (int i = 0; i < n; i++)
                {
                    int randomNumber = random.Next(0, 500);
                    writer.Write(randomNumber);
                }
            }
        }
        //-------------------------------------------------------------------------------










        //-----------------------------------5 задание-----------------------------------
        public static void toys_xml(string file_path, int count)
        {
            List<Toys> Toyss = new List<Toys>();


            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите данные для игрушки {i + 1}:");

                Toys Toys = new Toys();

                Console.Write("Название: ");
                Toys.Name = Console.ReadLine();

                Console.Write("Цена: ");
                double price;
                while (!double.TryParse(Console.ReadLine(), out price))
                {
                    Console.Write("Неверный ввод. Введите цену: ");
                }
                Toys.Price = price;

                Console.Write("Минимальный возраст: ");
                while (!int.TryParse(Console.ReadLine(), out Toys.min_age))
                {
                    Console.Write("Неверный ввод. Введите минимальный возраст: ");
                }

                Console.Write("Максимальный возраст: ");
                while (!int.TryParse(Console.ReadLine(), out Toys.max_age))
                {
                    Console.Write("Неверный ввод. Введите максимальный возраст: ");
                }

                Toyss.Add(Toys);
            }

            //сериализация списка игрушек в XML файл
            XmlSerializer serializer = new XmlSerializer(Toyss.GetType());
            using (FileStream fs = new FileStream(file_path, FileMode.Create))
            {
                serializer.Serialize(fs, Toyss);
            }
        }


        public static double expensive_toy(string filePath)
        {
            List<Toys> Toyss = new List<Toys>();//создание пустого списка Toys

            XmlSerializer serializer = new XmlSerializer(Toyss.GetType());//создание экземпляра XmlSerializer для десериализации данных

            
            List<Toys> toys;//переменная для хранения списка игрушек после десериализации

            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    //десериализация содержимого xml в список объектов типа List<Toys>. Pезультат сохраняется в переменную toys
                    toys = (List<Toys>)serializer.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                return 0;
            }

            double max_price = 0;

            foreach (var toy in toys)
            {
                if (toy.Price > max_price)
                {
                    max_price = toy.Price;
                }
            }

            return max_price;
        }
        //-------------------------------------------------------------------------------









        //-----------------------------------6 задание-----------------------------------
        public static void fill_file(string file_path, int count)
        {
            Random random = new Random();

            using (StreamWriter writer = new StreamWriter(file_path))
            {
                for (int i = 0; i < count; i++)
                {
                    int randomNumber = random.Next(0, 10);
                    writer.WriteLine(randomNumber);
                }
            }
        }


        //сумма элементов равных индексам
        public static int sum_elements(string file_path)
        {
            int sum = 0;
            int index = 0;

            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    if (int.TryParse(line, out int number))
                    {
                        if (number == index) 
                        {
                            sum += number;
                        }
                    }
                    index++;
                }
            }

            return sum;
        }
        //-------------------------------------------------------------------------------











        //-----------------------------------7 задание-----------------------------------
        public static void fill_file_line(string file_path, int count, int numbers_in_line)
        {
            Random random = new Random();
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                for (int i = 0; i < count; i++)
                {
                    for (int j = 0; j < numbers_in_line; j++)
                    {
                        int randomNumber = random.Next(1, 15);
                        writer.Write(randomNumber + " ");
                    }
                    writer.WriteLine();
                }
            }
        }



        public static long calculate_k(string file_path, int k)
        {
            long mult = 1;

            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] numbers = line.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string str_number in numbers)
                    {
                        if (int.TryParse(str_number, out int number))
                        {
                            if (number % k == 0)
                            {
                                mult *= number;
                            }
                        }
                    }
                }
            }

            if (mult == 1) 
            {
                return 0;
            }
            else 
            {
                return mult;
            }
        }

        public static string calculate_numbers_k(string file_path, int k)
        {
            string numbers_in_mult = string.Empty;

            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {

                    string[] numbers = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string str_number in numbers)
                    {
                        if (int.TryParse(str_number, out int number))
                        {
                            if (number % k == 0)
                            {
                                numbers_in_mult += number + " ";
                            }
                        }
                    }
                }
            }

            if (numbers_in_mult == string.Empty)
            {
                return "Нет таких чисел";
            }
            else
            {
                return numbers_in_mult;
            }
        }
        //-------------------------------------------------------------------------------














        //-----------------------------------8 задание-----------------------------------
        public static void lines_without_russian(string file_path, string file_path_end)
        {
            using (StreamReader reader = new StreamReader(file_path))
            {
                using (StreamWriter writer = new StreamWriter(file_path_end, false))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!russian_alphabet(line) & !isDigits(line))
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
        }

        public static bool russian_alphabet(string input)
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            foreach (char c in input)
            {
                if (alphabet.Contains(c))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool isDigits(string input)
        {
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    return true;
                }
            }
            return false;
        }
        //-------------------------------------------------------------------------------












        public static void file_print(string file_path)
        {
            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.Write($"{line} ");
                }
            }
            Console.WriteLine();
        }

        public static void file_print_lines(string file_path)
        {
            using (StreamReader reader = new StreamReader(file_path))
            {
                string line;
                int lineNumber = 1;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine($"{line}");
                    lineNumber++;
                }
            }
            Console.WriteLine();
        }

    }
}
