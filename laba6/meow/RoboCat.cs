using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba6.meow
{
    public class RoboCat
    {
        //метод, который подлежит адаптации
        public void MechMeow()
        {
            Console.WriteLine("Робо-кот: *механическое мяу*");
        }
    }


    public class RobotAdapter : IMeowable
    {
        private readonly RoboCat _robot;

        public RobotAdapter(RoboCat robot)
        {
            _robot = robot;//присваиваем RoboCat
        }
        /// <summary>
        ///реализация метода meow(), который вызывает MechMeow() у RoboCat
        /// </summary>
        public void meow()
        {
            _robot.MechMeow();
        }
    }
}
