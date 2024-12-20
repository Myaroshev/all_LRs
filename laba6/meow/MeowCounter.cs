using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6.meow
{

    //декоратор
    class MeowCounter : IMeowable
    {
        private readonly Cat cat; //объект
        private int _meowCount; //подсчет кол-ва вызовов meow()


        //конструктор
        public MeowCounter(Cat cat)
        {
            this.cat = cat;
            _meowCount = 0;
        }


        //еще одна реализация метода meow()
        public void meow()
        {
            cat.meow();
            _meowCount++;
        }


        public int meow_counts()
        {
            return _meowCount;
        }

    }
}
