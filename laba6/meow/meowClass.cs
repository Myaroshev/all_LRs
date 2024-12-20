using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6.meow
{
    class meowClass
    {
        /// <summary>
        /// 1. Метод принимает в себя коллекцию которая реализует интерфейс IMeowable
        /// 2. преобразует коллекцию meowables в список List<IMeowable>
        /// 3. ForEach(как аналог нашего foreach()) - перебирает элементы из списка
        /// </summary>
        public static void make_meows(IEnumerable<IMeowable> meowables)
        {
            meowables.ToList().ForEach(meowable => meowable.meow());
        }



        /*
        (чтоб не забыть, она по идее с питоном схожа)
        краткий способ записать анонимный метод 
        Лямбда-выражение:
            1. параметр(в данном случае элемент из коллекции meowable)
            2. код, который выполняется для каждого переданного параметра
        */
    }
}
