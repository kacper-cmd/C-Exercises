using System;

namespace interfaces_1a
{
 // an interface declaration
 // members have no modifiers
    interface IEngineable
    {
        void switchOn();
        void switchOff();
        void changeSpeed(int speed);
    }

  // definition of a class, which implements IEngineable interface
  // all members are public
    class Drill : IEngineable { // inPolish wiertarka
        public void switchOn() { Console.WriteLine("Drill is switching on"); }
        public void switchOff() { Console.WriteLine("Drill is switching off"); }
        public void changeSpeed(int speed) { Console.WriteLine("Change of speed to: " + speed); }
    }

    /*
    class Car : IEngineable
    {
        // complete in order to the program compile successfully
    }
    */

    class Test
    {
        static void Main(string[] args)
        {

            Drill w = new Drill();
         // uses methods declared in interface and implemented in a class
            w.switchOn();
            w.changeSpeed(2000);
            w.changeSpeed(1000);
            w.switchOff();

            Console.ReadLine();
        }
    }
}
