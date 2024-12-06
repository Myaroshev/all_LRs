using Aspose.Cells;
using System.Linq.Expressions;

namespace ConsoleApp2
{
    internal class Program
    {
        static void menu()
        {
            Console.WriteLine();
            Console.WriteLine("#-----------Корректировка БД-----------#");
            Console.WriteLine("6. Просмотр содержимого БД");
            Console.WriteLine("7. Удалить элемент");
            Console.WriteLine("8. Добавить элемент");
            Console.WriteLine("13. Сортировка");

            Console.WriteLine("\n#-----------Запросы к БД-----------#");
            Console.WriteLine("9. Вывести все заказы, стоимость которых больше 1 000 000 руб.(2 таблицы, несколько значений)");
            Console.WriteLine("10. Вывести метод из примера(где ответ 308)[3 таблицы, 1 значение]");
            Console.WriteLine("11. Вывести наибольшую стоимость из листа 'Заказы'(1 таблица, 1 значение)");
            Console.WriteLine("12. Вывод PHP-программистов(3 таблицы, несколько значений)'");

        }
        static void selector()
        {
            Console.WriteLine();
            Console.WriteLine("#-----------Выбор действий-----------#");
            Console.WriteLine("4. Выбрать обычный файл");
            Console.WriteLine("5. Выбрать урезанный файл");
        }

        static void logs_audit() 
        {
            Console.WriteLine();
            Console.WriteLine("#-----------Выбор действий журнала аудита-----------#");
            Console.WriteLine("1. Очистить текущий файл и открыть для записи");
            Console.WriteLine("2. Записывать действия в текущий файл без удаления записей");
            Console.WriteLine("3. Не вести запись аудита");
        }

        static void sort_table() 
        {
            Console.WriteLine();
            Console.WriteLine("#-----------Выбор таблицы для сортировки-----------#");
            Console.WriteLine("14. Заказы");
            Console.WriteLine("15. Услуги");
            Console.WriteLine("16. Исполнители");
        }

        static string delete_table(int choice) 
        {
            if (choice == 0 || choice == 14) return "Заказы";
            if (choice == 1 || choice == 15) return "Услуги";
            if (choice == 2 || choice == 16) return "Исполнители";

            return "Таблица не найдена";
        }

        static string[] audit_options =
        [
            //выбор аудита из класса
            "Очистить текущий файл и открыть для записи", //0
            "Записывать действия в текущий файл без удаления записей", //1
            "Не вести запись аудита", //2


            //корректировка БД
            "Выбрать обычный файл",//3
            "Выбрать урезанный файл",//4


            //Выбор действий с файлом
            "Просмотр содержимого БД",//5
            "Удалить элемент",//6
            "Добавить элемент",//7


            //Выбор действий
            "Вывести все заказы, стоимость которых больше 1 000 000 руб.",//8
            "Вывести метод из примера(где ответ 30)",//9
            "Вывести наибольшую стоимость из листа 'Заказы'",//10
            "Вывод PHP-программистов(3 таблицы, несколько значений)",//11
            "Сортировка",//12

            //таблицы
            "Сортировать заказы",//13
            "Сортировать услуги",//14
            "Сортировать исполнители",//15

        ];

        static string file_selector(int select) 
        {
            if (select == 4) 
            {
                return "LR5-var6.xls";
            }
            else if(select == 5) 
            {
                return "LR5-var6_low.xls";
            }

            return "Выберите файл";
        }


        static void Main(string[] args)
        {
            while(true) 
            {
                logs_audit();
                Console.Write("\nВыберите, как использовать аудит: ");
                string choice3 = Console.ReadLine();

                int nnn;
                if (!int.TryParse(choice3, out nnn))
                {
                    Console.WriteLine("Введите число!");
                }

                ReaderXLS reader_log = new ReaderXLS(null);
                reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[nnn-1]}", 0);

                Console.WriteLine();


                Console.WriteLine();
                selector();

                Console.Write("\nВыберите, с каким файлом работать: ");
                string choice2 = Console.ReadLine();

                int nn;
                if (!int.TryParse(choice2, out nn))
                {
                    Console.WriteLine("Введите число!");
                    continue;
                }
                Console.WriteLine();

                reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[nn-1]}", 1);

                string file_path = file_selector(nn);

                while (true) 
                {
                    Console.Clear();

                    menu();

                    Console.Write("\nВыберите действие: ");
                    string choice = Console.ReadLine();

                    if (choice == "exit") 
                    {
                        break;
                    }

                    int n;
                    if (!int.TryParse(choice, out n))
                    {
                        Console.WriteLine("Введите число!");
                    }
                    Console.WriteLine();


                    switch (n)
                    {
                        case 6:
                            Console.Clear();

                            ReaderXLS reader = new ReaderXLS(file_path);

                            reader.LoadWB();
                            Console.WriteLine($"{reader.ToString()}");

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n-1]}", 1);

                            Console.ReadKey();

                            break;

                        case 7:
                            Console.Clear();

                            ReaderXLS reader3 = new ReaderXLS(file_path);

                            reader3.LoadWB();
                            Console.WriteLine($"{reader3.ToString()}");


                            Console.WriteLine("#------------------------------------------------------------------------#");

                            while (true)
                            {
                                Console.Write("\nВведите лист(0 - заказы, 1 - услуги, 2 - исполнители): ");
                                string input_sheet = Console.ReadLine();

                                int sheet_n;
                                if (!int.TryParse(input_sheet, out sheet_n))
                                {
                                    Console.WriteLine("Введите число!");
                                    continue;
                                }

                                Console.Write("\nВведите код(1 столбик)[для выхода введите exit]: ");
                                string input_key = Console.ReadLine();

                                if (input_key.ToLower() == "exit")
                                {
                                    reader_log.Logs(nnn, $"Пользователь выбрал: прервать работу с данными", 1);
                                    break;
                                }

                                int key_n;
                                if (!int.TryParse(input_key, out key_n))
                                {
                                    Console.WriteLine("Введите число!");
                                    continue;
                                }
                                reader_log.Logs(nnn, $"Пользователь выбрал: продолжить работу с данными", 1);

                                reader3.delete_elements(input_key.ToString(), sheet_n);

                                reader_log.Logs(nnn, $"Пользователь выбрал: удалить строку ['{input_key}'] из стаблицы ['{delete_table(sheet_n)}']", 1);
                            }
                            Console.WriteLine("#------------------------------------------------------------------------#");
                            Console.WriteLine();

                            reader3.SaveWB();//сохраняем в Excel

                            Console.WriteLine($"{reader3.ToString()}");

                            Console.WriteLine();
                            Console.WriteLine();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);


                            Console.ReadKey();

                            break;



                        case 8:
                            Console.Clear();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            ReaderXLS reader4 = new ReaderXLS(file_path);
                            reader4.LoadWB();

                            Console.WriteLine($"{reader4.ToString()}");
                            Console.WriteLine();

                            while (true)
                            {
                                Console.Write("\nВведите лист (0 - заказы, 1 - услуги, 2 - исполнители): ");
                                string inputSheet = Console.ReadLine();

                                if (!int.TryParse(inputSheet, out int index_sheet) || index_sheet < 0 || index_sheet > 2)
                                {
                                    Console.WriteLine("Введите корректный номер листа (0, 1 или 2)!");
                                    continue;
                                }

                                Console.Write("Введите строку, в которую хотите добавить данные (начиная с 1): ");
                                string row_input = Console.ReadLine();

                                if (!int.TryParse(row_input, out int row_index) || row_index < 1)
                                {
                                    Console.WriteLine("Введите корректный номер строки (начиная с 1)");
                                    continue;
                                }

                                Console.Write("Введите данные через запятую: ");
                                string input_data = Console.ReadLine();

                                if (string.IsNullOrEmpty(input_data))
                                {
                                    Console.WriteLine("Данные не могут быть пустыми!");
                                    continue;
                                }

                                string[] values = input_data.Split(',');

                                if (!reader4.input_checker(values, index_sheet))//проверяем ввод
                                {
                                    Console.WriteLine("Проверьте формат ввода. Данные введены неверно");
                                    continue;
                                }

                                reader_log.Logs(nnn, $"Пользователь выбрал: добавить в таблицу следующее значение [{string.Join(", ", values)}]", 1);
                                reader4.add_elements(values, index_sheet, row_index);//добавляем элемент

                                Console.Write("\nДобавить ещё данные? (да/нет): ");
                                string input_cont = Console.ReadLine()?.ToLower();

                                if (input_cont != "да")
                                {
                                    reader_log.Logs(nnn, $"Пользователь выбрал: прервать работу с данными", 1);
                                    break;
                                }
                                reader_log.Logs(nnn, $"Пользователь выбрал: продолжить работу с данными", 1);
                            }

                            reader4.SaveWB();//сохраняем в Excel

                            Console.WriteLine();

                            Console.WriteLine($"{reader4.ToString()}");

                            Console.ReadKey();

                            break;


                        case 9:
                            Console.Clear();

                            Orders orders = new Orders(file_path);

                            orders.LoadWB();
                            orders.check_price();

                            Console.WriteLine();
                            Console.WriteLine();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            Console.ReadKey();

                            break;



                        case 10:
                            Console.Clear();

                            Orders orders2 = new Orders(file_path);

                            orders2.LoadWB();

                            Console.WriteLine();

                            orders2.example_method();

                            Console.WriteLine();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            Console.ReadKey();

                            break;


                        case 11:
                            Console.Clear();

                            Orders orders3 = new Orders(file_path);

                            orders3.LoadWB();

                            Console.WriteLine();

                            orders3.highest_price();

                            Console.WriteLine();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            Console.ReadKey();

                            break;


                        case 12:
                            Console.Clear();

                            Orders orders4 = new Orders(file_path);

                            orders4.LoadWB();

                            Console.WriteLine();

                            orders4.all_programmers();

                            Console.WriteLine();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            Console.ReadKey();

                            break;


                        case 13:
                            Console.Clear();

                            reader_log.Logs(nnn, $"Пользователь выбрал: {audit_options[n - 1]}", 1);

                            ReaderXLS reader_sort = new ReaderXLS(file_path);

                            reader_sort.LoadWB();

                            Console.WriteLine();

                            while (true)
                            {

                                sort_table();

                                Console.Write("\nВыберите таблицу: ");
                                string choice4 = Console.ReadLine();

                                int n4;
                                if (!int.TryParse(choice4, out n4))
                                {
                                    Console.WriteLine("Введите число!");
                                }
                                reader_log.Logs(nnn, $"Пользователь выбрал: отсортировать по primary key таблицу ['{delete_table(n4)}']", 1);
                                reader_sort.sort_by_key(n4);

                                Console.Write("\nПродолжить работу с данными? (да/нет): ");
                                string input_cont = Console.ReadLine()?.ToLower();

                                if (input_cont != "да")
                                {
                                    reader_log.Logs(nnn, $"Пользователь выбрал: прервать работу с данными", 1);
                                    break;
                                }

                                reader_log.Logs(nnn, $"Пользователь выбрал: продолжить работу с данными", 1);
                            }

                            Console.WriteLine();

                            Console.ReadKey();

                            break;
                    }
                }                
            }

 








        }
    }
}
