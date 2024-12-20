using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6.meow
{
    //интерфейс
    public interface IMeowable
    {
        void meow();//метод мяуканья
    }

    public class Cat : IMeowable
    {
        private string Name { get; set; } //имя

        //конструктор инициализации
        public Cat(string name)
        {
            Name = name;
        }

        //мяуканье n раз
        public void meow(int n)
        {
            string meows = "";
            for (int i = 1; i <= n; i++) 
            {
                if (i != n)
                {
                    meows += "мяу-";
                }
                else 
                {
                    meows += "мяу!";
                }
            }
            

            Console.WriteLine($"{Name}: {meows}");
        }

        //1 мяу
        public void meow()
        {
            Console.WriteLine($"{Name}: мяу!");
        }


        public override string ToString()
        {
            return $"кот: {Name}";
        }
    }
}
