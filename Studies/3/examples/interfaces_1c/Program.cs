using System;

namespace interfaces_1c
{
    interface I1 { void f1(); void f2(); }
    interface I2 { void f1(); void f2(); }

    class C : I1, I2 {

	    void I1.f1() { Console.WriteLine("Explicit interface implementation of f1() method for I1 interface"); }
	    void I2.f2() { Console.WriteLine("Explicit interface implementation of f2() method for I2 interface"); }
        public void f1() { Console.WriteLine("Implementation of f1() method"); }
        public void f2() { Console.WriteLine("Implementation of f2() method"); }
    }

    class Program
    {
        static void Main(string[] args)
        {
            C obj = new C();

            obj.f1();		// error
            
            I1 x = obj;	// implicit conversion to interface type 
            x.f1();		// and OK

            Console.ReadLine();
        }
    }
}
