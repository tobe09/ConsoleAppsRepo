using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TobeConsolePractise
{
    class DiPractise
    {
        public static void Run()
        {
            Cat cat = new Cat();
            cat.Sound();
        }

        interface IAnimal
        {
            void Sound();
        }

        class Animal
        {
            public virtual void Sound()
            {
                Console.WriteLine("Sounding");
            }
        }

        class Dog : Animal, IAnimal
        {
            public override void Sound()
            {
                Console.WriteLine("Barking");
            }
        }

        class Cat : Animal, IAnimal
        {
        }
    }
}
