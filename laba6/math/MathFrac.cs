using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6.math
{
    public abstract class Prototype
    {
        //абстрактный Прототип
        public abstract Prototype Clone();
    }


    public class MathFrac : Prototype
        //ICloneable
    {
        private int numerator_frac;//числитель
        private int denominator_frac;//знаменатель

        public int Numerator
        {
            get { return numerator_frac; }
            set { numerator_frac = value; }
        }

        public int Denominator
        {
            get { return denominator_frac; }
            set { denominator_frac = value; }
        }

        // Конструктор
        public MathFrac(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен нулю!");
            }
            if (denominator < 0)//проверка на отрицание
            {
                numerator = -numerator;
                denominator = -denominator;
                /*
                 2 -3
                2 = -2
                -3 = 3
                -2 3
                 */
                
            }

            numerator_frac = numerator;
            denominator_frac = denominator;
        }

        //перегрузка
        public override string ToString()
        {
            return $"{numerator_frac}/{denominator_frac}";
        }

        //перегрузка сложения
        public static MathFrac operator +(MathFrac a, MathFrac b)
        {
            int new_numerator = a.numerator_frac * b.denominator_frac + b.numerator_frac * a.denominator_frac;
            int new_denominator = a.denominator_frac * b.denominator_frac;

            return new (new_numerator, new_denominator);
        }

        //перегрузка вычитания
        public static MathFrac operator -(MathFrac a, MathFrac b)
        {
            int new_numerator = a.numerator_frac * b.denominator_frac - b.numerator_frac * a.denominator_frac;
            int new_denominator = a.denominator_frac * b.denominator_frac;

            return new(new_numerator, new_denominator);
        }

        //перегрузка умножения
        public static MathFrac operator *(MathFrac a, MathFrac b)
        {
            int new_numerator = a.numerator_frac * b.numerator_frac;
            int new_denominator = a.denominator_frac * b.denominator_frac;

            return new(new_numerator, new_denominator);
        }

        //перегрузка деления
        public static MathFrac operator /(MathFrac a, MathFrac b)
        {
            if (b.numerator_frac == 0) 
            {
                throw new DivideByZeroException("Нельзя делить на 0!");
            }                

            int new_numerator = a.numerator_frac * b.denominator_frac;
            int new_denominator = a.denominator_frac * b.numerator_frac;

            return new(new_numerator, new_denominator);
        }




        //перегрузка для работы с целыми числами
        public static MathFrac operator +(MathFrac a, int b)
        {
            return a + new MathFrac(b, 1);
        }
        public static MathFrac operator +(int a, MathFrac b)
        {
            return b + a;
        }



        //вычитание целого числа из дроби
        public static MathFrac operator -(MathFrac a, int b)
        {
            int newNumerator = a.numerator_frac - b * a.denominator_frac;
            return new MathFrac(newNumerator, a.denominator_frac);
        }

        //вычитание дроби из целого числа
        public static MathFrac operator -(int a, MathFrac b)
        {
            int newNumerator = a * b.denominator_frac - b.numerator_frac;
            return new MathFrac(newNumerator, b.denominator_frac);
        }


        //перегрузка умножения между числом и дробью и наоборот
        public static MathFrac operator *(MathFrac a, int b)
        {
            return new MathFrac(a.numerator_frac * b, a.denominator_frac);
        }
        public static MathFrac operator *(int a, MathFrac b)
        {
            return new MathFrac(a * b.numerator_frac, b.denominator_frac);
        }



        public static MathFrac operator /(MathFrac a, int b)
        {
            if (b == 0) 
            {
                throw new DivideByZeroException("Нельзя делить на 0!");
            }
               
            return a / new MathFrac(b, 1);
        }
        public static MathFrac operator /(int a, MathFrac b)
        {
            if (b.numerator_frac == 0)
            {
                throw new DivideByZeroException("Нельзя делить на ноль!");
            }

            return new MathFrac(a * b.denominator_frac, b.numerator_frac);
        }



        //#________________________1_____дополнение
        //метод сложения
        public MathFrac sum(MathFrac other)
        {
            int new_numerator = this.numerator_frac * other.denominator_frac + other.numerator_frac * this.denominator_frac;
            int new_denominator = this.denominator_frac * other.denominator_frac;

            return new MathFrac(new_numerator, new_denominator);
        }

        //метод деления
        public MathFrac div(MathFrac other)
        {
            if (other.numerator_frac == 0) 
            {
                throw new DivideByZeroException("Нельзя делить на 0!");
            }
                

            int new_numerator = this.numerator_frac * other.denominator_frac;
            int new_denominator = this.denominator_frac * other.numerator_frac;

            return new MathFrac(new_numerator, new_denominator);
        }

        //метод вычитания
        public MathFrac minus(int number)
        {
            int new_numerator = this.numerator_frac - number * this.denominator_frac;
            int new_denominator = this.denominator_frac;

            return new MathFrac(new_numerator, new_denominator);
        }








        //#____2 - сравнение
        //метод Equals
        public bool Equals(MathFrac other)
        {
            if (other == null) 
            {
                return false;
            }

            return numerator_frac == other.numerator_frac && denominator_frac == other.denominator_frac;
        }

        //оператор ==
        public static bool operator ==(MathFrac a, MathFrac b)
        {
            return a.numerator_frac == b.numerator_frac && a.denominator_frac == b.denominator_frac;
        }

        //оператор !=
        public static bool operator !=(MathFrac a, MathFrac b)
        {
            return a.numerator_frac != b.numerator_frac && a.denominator_frac != b.denominator_frac;
        }







        //#_______3 - ICloneable
        public override Prototype Clone()
        {
            return new MathFrac(numerator_frac, denominator_frac);
        }



        //public object Clone()
        //{
        //    return new MathFrac(numerator_frac, denominator_frac);//новый объект MathFrac с теми же значениями
        //}
    }


}
