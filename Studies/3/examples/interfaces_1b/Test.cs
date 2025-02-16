using System;

namespace interfaces_1b
{

    interface IDevice
    {
        void switchOn();
        void switchOff();
        void changeProgramm(int programNumber);       
    }

    interface IClock
    {
        void setTime();
        void switchOnAlarm();
        void switchOff();
    }

    class Mixer { }

    class Radio { }

    // below class implements two interfaces (so should implement all their members)
    class ClockRadio : IDevice, IClock {
        public void switchOn() { Console.WriteLine("Switching radio on"); }
        public void switchOff() { Console.WriteLine("Switching radio off"); }
        public void changeProgramm(int programNumber) { Console.WriteLine("A change of programm to: "+programNumber); }
        public void setTime() { Console.WriteLine("Setting an alarm time"); }
        public void switchOnAlarm() { Console.WriteLine("Switching a clock on"); }

    // both interfaces have switchOff() method
    // to implement it for each interface separately we have to use explicit interface implementation (like below)
    // otherwise it will be common implementation for both interfaces
        void IClock.switchOff() { Console.WriteLine("Switching a clock off"); }
    }

    class Test
    {
        static void Main(string[] args)
        {
            ClockRadio ClockRadio = new ClockRadio();
            ClockRadio.switchOn();
            ClockRadio.changeProgramm(2);
            ClockRadio.changeProgramm(3);
            ClockRadio.switchOff();
            ClockRadio.setTime();
            ClockRadio.switchOnAlarm();

            // to use explicit interface implementation 
            // an object should be typed as appropriate interface
            ((IClock)ClockRadio).switchOff();            

            Console.ReadLine();
        }
    }
}
