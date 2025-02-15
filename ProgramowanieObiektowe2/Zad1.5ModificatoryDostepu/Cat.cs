using ClassLibraryZad1._5._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad1._5ModificatoryDostepu
{
    public class Cat : Animal
    {
        public new void MakeSound()
        {
            Console.WriteLine("Cat -> mau!");
        }
        public void SetAge(int age)
        {
            Age = age;
        }
        
    }
}
