using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Orders
    {
        private string file_path;
        private Workbook wb = null;

        //конструктор
        public Orders(string file_path)
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

        //-------------------------------------------______запросы_________----------------------------
        //вывод строк, у которых "price" > 1млн руб и гражданство у исполнителя "Китай"
        //это запрос к 2 таблицам, где ответом будет список
        public void check_price()
        {
            if (wb == null)
            {
                Console.WriteLine("Книга не загружена");
                return;
            }

            Worksheet order_sheets = wb.Worksheets[0];//лист "заказы"
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


            //запрос
            var answers = (from order in orders
                           join executor in executors on order.exe_code equals executor.exe_code //соединение по полю exe_code
                           where executor.nationality == "Китай"
                           orderby order.price >= 1000000 descending
                           select new { order.order_code, order.price }).ToList();

            if (answers != null)
            {
                foreach (var answer in answers)
                {
                    Console.WriteLine($"Код заказчика: {answer.order_code}, Цена: {answer.price}");
                }
            }
            else
            {
                Console.WriteLine("Данные не найдены");
            }
        }








        //вывод строки, у которой самая высокая стоимость
        //это запрос к 1 таблице, где ответом будет одно значение
        public void highest_price()
        {
            if (wb == null)
            {
                Console.WriteLine("Книга не загружена");
                return;
            }

            Worksheet order_sheets = wb.Worksheets[0];//лист "заказы"

            //инициализация коллекций
            var orders = new List<(int order_code, int service_code, int exe_code, int price)>();


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


            //запрос
            var answers = (from order in orders
                           where order.price > 1
                           orderby order.price descending
                           select new { order.price, order.order_code } ).FirstOrDefault();

            if (answers != null)
            {
                Console.WriteLine($"Стоимость: {answers.price} (Код исполнителя: {answers.order_code})");
            }
            else
            {
                Console.WriteLine("Данные не найдены");
            }
        }






        //вывод всех PHP-программист, старше 25 лет, у которых стоимость больше 1.000.000
        //это запрос к 3 таблицам, где ответом будет несколько значенимй
        public void all_programmers()
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


            //запрос
            var answer = (from order in orders
                          join service in services on order.service_code equals service.service_code//соединение по полю service_code
                          where service.name == "PHP-программист"//фильтрация по профессии
                          join executor in executors on order.exe_code equals executor.exe_code//соединение по полю exe_code
                          where executor.age > 25 && order.price >= 1000000//фильтрация по возрасту и цене
                          orderby order.price descending//сортировка по цене в порядке убывания
                          select new
                          {executor.age, executor.nationality, service.name, order.price}).ToList();

            if (answer != null)
            {
                foreach (var answerr in answer) 
                {
                    Console.WriteLine($"Возраст: {answerr.age}, гражданство: {answerr.nationality}, услуга: {answerr.name}, стоимость: {answerr.price}р");
                }
                
            }
            else
            {
                Console.WriteLine("Данные не найдены");
            }
        }









        //это запрос к 3 таблицам, где ответом будет одно значение - код человека
        public void example_method()
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
            var orders = new List<(int order_code, int service_code, int exe_code, int price)>();//список заказов
            var services = new List<(int service_code, string name)>();//список услуг
            var executors = new List<(int exe_code, int age, string nationality)>();//список исполнителей

            //заказы
            int order_rows = order_sheets.Cells.MaxDataRow;//максимальное количество строк в листе заказов
            for (int row = 1; row <= order_rows; row++)//перебор строк заказов
            {
                try
                {
                    int order_code = order_sheets.Cells[row, 0].IntValue;//код заказа
                    int service_code = order_sheets.Cells[row, 1].IntValue;//код услуги
                    int exe_code = order_sheets.Cells[row, 2].IntValue;//код исполнителя
                    int price = order_sheets.Cells[row, 3].IntValue;//цена заказа

                    orders.Add((order_code, service_code, exe_code, price));//добавление заказа в список
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

            //запрос
            var answer = (from order in orders //запрос на получение исполнителей
                          join service in services on order.service_code equals service.service_code//соединение с услугами
                          where service.name == "Python-программист"//фильтрация по имени услуги
                          join executor in executors on order.exe_code equals executor.exe_code//соединение с исполнителями
                          where executor.age > 30 && executor.nationality == "Китай"//фильтрация по возрасту и национальности
                          orderby order.price descending//сортировка по цене
                          select new { executor.exe_code }).FirstOrDefault();//выбор первого исполнителя

            if (answer != null)
            {
                Console.WriteLine($"Код исполнителя: {answer.exe_code}");
            }
            else
            {
                Console.WriteLine("Данные не найдены");
            }
        }

    }
}
