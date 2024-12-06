using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ReaderXLS
    {
        private string file_path;
        private Workbook wb = null;

        //конструктор
        public ReaderXLS(string file_path)
        {
            this.file_path = file_path;
        }



        //загрузка таблицы
        public void LoadWB()
        {
            try
            {
                wb = new Workbook(file_path);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }

        public void SaveWB() 
        {
            wb.Save(file_path);
        }




        //удаление элемента по ключу
        public void delete_elements(string key, int index_sheets)
        {
            if (wb == null)
            {
                Console.WriteLine("Книга не загружена");
                return;
            }

            WorksheetCollection sheets = wb.Worksheets;//получение коллекции листов

            if (index_sheets < 0 || index_sheets >= sheets.Count)//проверка корректности индекса листа
            {
                Console.WriteLine("Неверный индекс листа");
                return;
            }

            Worksheet ws = sheets[index_sheets];//получение выбранного листа
            int rows = ws.Cells.MaxDataRow;//получение максимального количества строк

            bool is_deleted = false; //флаг для отслеживания удаления

            for (int i = rows; i >= 0; i--)//перебор строк в обратном порядке
            {
                var cell_value = ws.Cells[i, 0].StringValue;//ключ - 1 столбец

                if (cell_value == key)
                {
                    ws.Cells.DeleteRow(i); //удаляем строку
                    is_deleted = true;
                }
            }

            if (is_deleted)
            {
                Console.WriteLine($"Элементы с ключом '{key}' удалены с листа {ws.Name}");
            }
            else
            {
                Console.WriteLine($"Ключ '{key}' не найден на листе {ws.Name}");
            }
        }




        //добавление элементов
        public void add_elements(string[] values, int index_s, int target_row)
        {
            if (wb == null)
            {
                Console.WriteLine("Книга не загружена");
                return;
            }

            WorksheetCollection sheets = wb.Worksheets;

            if (index_s < 0 || index_s >= sheets.Count)
            {
                Console.WriteLine("Неверный индекс листа");
                return;
            }

            Worksheet ws = sheets[index_s];//лист
            int max_row = ws.Cells.MaxDataRow;//макс. строка

            //проверка корректности на вставляемое значение
            if (target_row < 2 || target_row > max_row + 2)//+2, чтобы позволить вставить за последней строкой
            {
                Console.WriteLine($"Неверный номер строки: {target_row}. Строка должна быть от 2 до {max_row + 2}");
                return;
            }

            string new_key = values[0];//(уникальный) primary key
            for (int i = 1; i <= max_row; i++)
            {
                var existing_key = ws.Cells[i, 0].StringValue;
                if (existing_key == new_key)
                {
                    Console.WriteLine($"Значение '{new_key}' уже существует в таблице");
                    return;
                }
            }

            //сдвигаем строки вниз, начиная с target_row
            if (target_row - 1 <= max_row) //если добавление не в конец
            {
                ws.Cells.InsertRows(target_row - 1, 1); //вставляем новую строку
            }

            //добавление данных
            for (int col = 0; col < values.Length; col++)
            {
                //попытка преобразовать в int | ФИКС ЗАПИСЕЙ В ТАБЛИЦЕ EXCEL УРА
                if (int.TryParse(values[col], out int int_value))
                {
                    ws.Cells[target_row - 1, col].Value = int_value;//запись как число
                }
                else
                {
                    ws.Cells[target_row - 1, col].Value = values[col];//запись как строка
                }
            }

            Console.WriteLine($"Добавлена новая строка на листе '{ws.Name}' в строку {target_row}");
        }



        public bool input_checker(string[] values, int sheet_index)
        {
            switch (sheet_index)
            {
                case 0://заказы
                    if (values.Length != 4)
                    {
                        Console.WriteLine("Ошибка: для листа 'Заказы' требуется 4 значения!");
                        return false;
                    }

                    return int.TryParse(values[0], out _) &&//код заказа
                           int.TryParse(values[1], out _) &&//код услуги
                           int.TryParse(values[2], out _) &&//код исполнителя
                           int.TryParse(values[3], out _);//price

                case 1://услуги
                    if (values.Length != 2)
                    {
                        Console.WriteLine("Ошибка: для листа 'Услуги' требуется 2 значения!");
                        return false;
                    }

                    return int.TryParse(values[0], out _) &&//Код
                           !string.IsNullOrEmpty(values[1]);//name (string)

                case 2://исполнители
                    if (values.Length != 3)
                    {
                        Console.WriteLine("Ошибка: для листа 'Исполнители' требуется 3 значения!");
                        return false;
                    }

                    return int.TryParse(values[0], out _) &&//Код
                           int.TryParse(values[1], out _) &&//age
                           !string.IsNullOrEmpty(values[2]);//nationality (string)

                default:
                    return false;
            }
        }










        public void Logs(int choice, string data, int passer)
        {
            if (choice == 1 && passer == 0) 
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("logs.txt", false))
                    {
                        DateTime time = DateTime.Now;
                        string form_time = time.ToString("dd.MM.yyyy HH:mm:ss");

                        writer.WriteLine($"[{form_time}] | {data}");
                    }
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (choice != 3 &&  (passer == 0 || passer == 1))
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter("logs.txt", true))
                    {
                        DateTime time = DateTime.Now;
                        string form_time = time.ToString("dd.MM.yyyy HH:mm:ss");

                        writer.WriteLine($"[{form_time}] | {data}");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            else if (choice == 3)
            {
                
            }
        }












        public void sort_by_key(int sorting)
        {
            if (wb == null)
            {
                Console.WriteLine("Книга не загружена");
                return;
            }

            Worksheet order_sheets = wb.Worksheets[0];//лист "заказы"
            Worksheet service_sheets = wb.Worksheets[1];//лист "услуги"
            Worksheet exe_sheets = wb.Worksheets[2];//лист "исполнители"

            //инициализация коллекций
            var orders = new List<(int order_code, int service_code, int exe_code, int price)>();
            var services = new List<(int service_code, string name)>();
            var executors = new List<(int exe_code, int age, string nationality)>();


            //заказы
            int order_rows = order_sheets.Cells.MaxDataRow;
            for (int row = 1; row <= order_rows; row++)
            {
                try
                {
                    int order_code = order_sheets.Cells[row, 0].IntValue;
                    int service_code = order_sheets.Cells[row, 1].IntValue;
                    int exe_code = order_sheets.Cells[row, 2].IntValue;
                    int price = order_sheets.Cells[row, 3].IntValue;

                    orders.Add((order_code, service_code, exe_code, price));
                }
                catch
                {
                    Console.WriteLine($"Ошибка обработки строки {row + 1} в листе 'Заказы'");
                }
            }

            //услуги
            int service_rows = service_sheets.Cells.MaxDataRow;
            for (int row = 1; row <= service_rows; row++)
            {
                try
                {
                    int service_code = service_sheets.Cells[row, 0].IntValue;
                    string name = service_sheets.Cells[row, 1].StringValue;

                    services.Add((service_code, name));
                }
                catch
                {
                    Console.WriteLine($"Ошибка обработки строки {row + 1} в листе 'Услуги'");
                }
            }

            //исполнители
            int executor_rows = exe_sheets.Cells.MaxDataRow;
            for (int row = 1; row <= executor_rows; row++)
            {
                try
                {
                    int exe_code = exe_sheets.Cells[row, 0].IntValue;
                    int age = exe_sheets.Cells[row, 1].IntValue;
                    string nationality = exe_sheets.Cells[row, 2].StringValue;

                    executors.Add((exe_code, age, nationality));
                }
                catch
                {
                    Console.WriteLine($"Ошибка обработки строки {row + 1} в листе 'Исполнители'");
                }
            }



            switch (sorting) 
            {
                case 14:
                    //запрос
                    var answer = (from order in orders
                                  orderby order.order_code ascending
                                  select new { order.order_code, order.service_code, order.exe_code, order.price }).ToList();

                    if (answer != null)
                    {
                        //заголовки
                        Console.WriteLine($"{"Код заказа",-15} {"Гражданство",-15} {"Услуга",-15} {"Стоимость",-15}");
                        Console.WriteLine(new string('-', 60));

                        foreach (var answerr in answer)
                        {
                            Console.WriteLine($"{answerr.order_code,-15} {answerr.service_code,-15} {answerr.exe_code,-15} {answerr.price,-15}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Данные не найдены");
                    }
                    break;

                case 15:
                    //запрос
                    var answer2 = (from service in services
                                  orderby service.service_code ascending
                                  select new { service.service_code, service.name }).ToList();

                    if (answer2 != null)
                    {
                        //заголовки
                        Console.WriteLine($"{"Код",-15} {"название",-15}");
                        Console.WriteLine(new string('-', 60));

                        foreach (var answerr in answer2)
                        {
                            Console.WriteLine($"{answerr.service_code,-15} {answerr.name,-15}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Данные не найдены");
                    }
                    break;

                case 16:
                    //запрос
                    var answer3 = (from executor in executors
                                  orderby executor.exe_code ascending
                                  select new { executor.exe_code, executor.age, executor.nationality, }).ToList();

                    if (answer3 != null)
                    {
                        //заголовки
                        Console.WriteLine($"{"Код",-15} {"Возраст",-15} {"гражданство",-15}");
                        Console.WriteLine(new string('-', 60));

                        foreach (var answerr in answer3)
                        {
                            Console.WriteLine($"{answerr.exe_code,-15} {answerr.age,-15} {answerr.nationality,-15}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Данные не найдены");
                    }
                    break;
            }
        }






























        //перегруженный метод ToString()
        public override string ToString()
        {
            if (wb == null)
            {
                return "Книга не загружена.";
            }

            WorksheetCollection sheets = wb.Worksheets;//коллекция листов

            string result = "";

            for (int i = 0; i < sheets.Count; i++)//перебор всех листов
            {
                Worksheet ws = sheets[i];//получение текущего листа
                result += $"Лист {i + 1}: {ws.Name}\n";//добавление имени листа в результат

                int rows = ws.Cells.MaxDataRow;//получение максимального количества строк
                int cols = ws.Cells.MaxDataColumn;//получение максимального количества столбцов

                for (int j = 0; j <= rows; j++)//перебор всех строк
                {
                    for (int k = 0; k <= cols; k++)//перебор всех столбцов
                    {
                        var cell_value = ws.Cells[j, k].Value;//получение значения ячейки
                        result += $"{cell_value,-20}";//добавление значения ячейки в результат
                    }
                    result += "\n";
                }

                result += new string('-', 50) + "\n";
            }

            return result;
        }

    }
}