using laba6.math;

namespace laba6.meow
{
    internal class Program
    {
        static void MainMenu() 
        {
            Console.WriteLine(
                "1. Котик\n" +
                "2. Дроби\n"
                );
        }
        static void CatMenu() 
        {
            Console.WriteLine(
                "1. Кот мяукает\n" +
                "2. Интерфейс Мяуканье\n" +
                "3. Количество мяуканий\n"
                );
        }
        static void MathMenu()
        {
            Console.WriteLine(
                "1. Дроби\n" +
                "2. Равенство\n" +
                "3. Клонирование дроби\n"
                );
        }


        static void Main(string[] args)
        {
            while (true) 
            {
                MainMenu();

                Console.Write("\nВыберите действие: ");
                string choice_main = Console.ReadLine();

                if (choice_main == "0")
                {
                    return;
                }

                int n4;
                if (!int.TryParse(choice_main, out n4))
                {
                    Console.WriteLine("Введите число!");
                    continue;   
                }

                switch (n4) 
                {
                    case 1:
                        Console.Clear();


                        while (true)
                        {
                            CatMenu();

                            Console.Write("\nВыберите действие: ");
                            string choice3 = Console.ReadLine();

                            int nnn;
                            if (!int.TryParse(choice3, out nnn))
                            {
                                Console.WriteLine("Введите число!");
                            }

                            switch (nnn)
                            {
                                case 1:
                                    Console.Clear();

                                    Console.Write("Введите кличку кота: ");
                                    string cat_name = Console.ReadLine();

                                    //кол-во мяуканий
                                    Console.Write("Введите количество мяуканий: ");
                                    int meow_count;


                                    while (!int.TryParse(Console.ReadLine(), out meow_count) || meow_count <= 0)
                                    {
                                        Console.Write("Введите положительное целое число для количества мяуканий: ");
                                    }

                                    Console.WriteLine();

                                    Cat barsik = new Cat(cat_name);
                                    barsik.meow();//1 мяу
                                    barsik.meow(meow_count);//задаём сами кол-во мяу

                                    Console.WriteLine();

                                    break;



                                case 2:
                                    Console.Clear();

                                    Console.Write("Введите кличку ПЕРВОГО кота: ");
                                    string cat_name2 = Console.ReadLine();
                                    Console.Write("Введите кличку ВТОРОГО кота: ");
                                    string cat_name3 = Console.ReadLine();

                                    Console.WriteLine();

                                    Cat barsik_2 = new Cat(cat_name2);
                                    Cat murzik_1 = new Cat(cat_name3);
                                    RoboCat robot = new RoboCat();
                                    IMeowable robot_adapter = new RobotAdapter(robot);

                                    meowClass.make_meows(new List<IMeowable> { barsik_2, murzik_1, robot_adapter });
                                    //Барсик: мяу! | Мурзик: мяу! | Робо-кот: *механическое мяу*

                                    Console.WriteLine();

                                    break;




                                case 3:
                                    Console.Clear();

                                    Console.Write("Введите кличку кота: ");
                                    string cat_name4 = Console.ReadLine();

                                    Cat barsik_3 = new Cat(cat_name4);
                                    MeowCounter counter = new MeowCounter(barsik_3);

                                    meowClass.make_meows(new List<IMeowable> { counter });

                                    Console.WriteLine($"Количество мяуканий кота: {counter.meow_counts()}");

                                    Console.WriteLine();

                                    break;

                            }
                        }



                    case 2:
                        Console.Clear();


                        while (true)
                        {
                            Console.WriteLine();
                            MathMenu();


                            Console.Write("\nВыберите действие: ");
                            string choice3 = Console.ReadLine();

                            if (choice3 == "0")
                            {
                                return;
                            }

                            int nnn;
                            if (!int.TryParse(choice3, out nnn))
                            {
                                Console.WriteLine("Введите число!");
                            }

                            Console.WriteLine();

                            switch (nnn)
                            {
                                case 1:
                                    Console.Clear();

                                    MathFrac f1 = new MathFrac(1, 2);
                                    MathFrac f2 = new MathFrac(2, 3);

                                    //сложение дробей и целых чисел
                                    MathFrac sum1 = f1 + f2;     
                                    MathFrac sum2 = f1 + 3;      
                                    MathFrac sum3 = 3 + f1;      

                                    //вычитание дробей и целых чисел
                                    MathFrac diff1 = f1 - f2;     
                                    MathFrac diff2 = f1 - 3;    
                                    MathFrac diff3 = 3 - f1;     

                                    //умножение дробей и целых чисел
                                    MathFrac muilt_frac = f1 * f2;
                                    MathFrac muilt_frac2 = f1 * 3;
                                    MathFrac muilt_frac3 = 3 * f1;

                                    //деление дробей и целых чисел
                                    MathFrac div_frac = f1 / f2;
                                    MathFrac div_frac2 = f1 / 3;
                                    MathFrac div_frac3 = 3 / f1;

                                    Console.WriteLine("Сложение дробей и целых чисел");
                                    Console.WriteLine($"{f1} + {f2} = {sum1}");  
                                    Console.WriteLine($"{f1} + 3 = {sum2}");    
                                    Console.WriteLine($"3 + {f1} = {sum3}");   

                                    Console.WriteLine();

                                    Console.WriteLine("Вычитание дробей и целых чисел");
                                    Console.WriteLine($"{f1} - {f2} = {diff1}"); 
                                    Console.WriteLine($"{f1} - 3 = {diff2}"); 
                                    Console.WriteLine($"3 - {f1} = {diff3}"); 

                                    Console.WriteLine();

                                    Console.WriteLine("Умножение дробей и целых чисел");
                                    Console.WriteLine($"{f1} * {f2} = {muilt_frac}");
                                    Console.WriteLine($"{f1} * 3 = {muilt_frac2}");
                                    Console.WriteLine($"3 * {f1} = {muilt_frac3}");

                                    Console.WriteLine();

                                    Console.WriteLine("Деление дробей и целых чисел");
                                    Console.WriteLine($"{f1} / {f2} = {div_frac}");
                                    Console.WriteLine($"{f1} / 3 = {div_frac2}");
                                    Console.WriteLine($"3 / {f1} = {div_frac3}");

                                    MathFrac f11 = new MathFrac(1, 2);
                                    MathFrac f21 = new MathFrac(2, 3);
                                    MathFrac f3 = new MathFrac(3, 4);

                                    Console.WriteLine();

                                    Console.WriteLine($"Результат: {f11.sum(f21).div(f3).minus(5)}");


                                    break;



                                case 2:
                                    Console.Clear();

                                    MathFrac frac1 = new MathFrac(1, 2);
                                    MathFrac frac2 = new MathFrac(1, 2);
                                    MathFrac frac3 = new MathFrac(3, 5);

                                    Console.WriteLine(frac1 == frac2);//True, так как 1/2 == 1/2
                                    Console.WriteLine(frac1 == frac3);//False, так как 1/2 != 3/5

                                    //а вот тут проблема, я так и не понял почему
                                    Console.WriteLine(frac1.Equals(frac2));//True
                                    Console.WriteLine(frac1.Equals(frac3));//False

                                    //почитал - по идее ReferenceEquals может помочь, чтоб проверить, ссылаются ли объекты на одну и ту же память
                                    //но не понимаю как именно и надо ли вообще его использовать

                                    Console.WriteLine();

                                    break;




                                case 3:
                                    Console.Clear();

                                    //------------Это IClonable---------------------------
                                    //MathFrac frac11 = new MathFrac(3, 4);
                                    //MathFrac cl_frac = (MathFrac)frac11.Clone();

                                    //Console.WriteLine($"Оригинальная дробь: {frac11}");
                                    //Console.WriteLine($"Клонированная дробь: {cl_frac}");

                                    //cl_frac = new MathFrac(5, 6);

                                    //Console.WriteLine($"Измененная клонированная дробь: {cl_frac}");

                                    //Console.WriteLine($"{ReferenceEquals(frac11, cl_frac)}");//false






                                    ////------------Это Prototype---------------------------
                                    MathFrac original = new MathFrac(1, 2);
                                    Console.WriteLine($"Оригинальная дробь: {original}");

                                    MathFrac clone = (MathFrac)original.Clone();
                                    Console.WriteLine($"Клонированная дробь: {clone}");

                                    //ставим новые значения клону
                                    clone.Numerator = 3;
                                    clone.Denominator = 4;

                                    //вывод после изменений
                                    Console.WriteLine($"Оригинальная дробь после изменений клона: {original}");//1/2
                                    Console.WriteLine($"Клонированная дробь после изменений: {clone}");//3/4

                                    ////проверка на разность объектов
                                    //Console.WriteLine($"{ReferenceEquals(original, clone)}");//false
                                    //если взять обе дроби, то выведет false

                                    break;

                            }
                        }

                }
            }






        }
    }
}
