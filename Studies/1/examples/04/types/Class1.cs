using System; // namespace including Console class, among others

	class Test {
				
		static void Main(string[] args)
		{
    // 1. local variables ---------------------------------------------------------------------
            int x;  
            x = 2;   // you can't use a variable without initialization - commenting of this line causes an error
            var five = 5; // var instead of type, only if initializer exists
           
    // 2. writing to the console --------------------------------------------------------------
            Console.WriteLine("Example 1.\n=== Printing on the console ===\n");
			Console.WriteLine("Result: " + x);
			Console.WriteLine("Result: {0}\n\n", x);
            Console.ReadLine();
            Console.Clear();

    // 3. test of floating-point types ------------------------------------------------------
            Console.WriteLine("Example 2.\n=== Floating-point types ===\n");
            float f_pi = (float)System.Math.PI;
            decimal dec_pi = (decimal)System.Math.PI;
            Console.WriteLine("(float)PI: {0}\n(double)PI: {1}\n(decimal)PI: {2}\n\n",
                                f_pi, System.Math.PI, dec_pi);

            decimal large_number = 8.12345678901234567890123456789012345678901234567890m;
            float f_large = (float)large_number;
            decimal dec_large = large_number;
            double double_large = (double)large_number;
            Console.WriteLine("(float): {0}\n(double): {1}\n(decimal): {2}\n\n",
                                f_large, double_large, dec_large);


            decimal very_large_number = 123456789012345678901234567.899123456789m;
            Console.WriteLine(very_large_number);

            Console.ReadLine();
            Console.Clear();

    // 4. string and chars literals ------------------------------------------------------
            Console.WriteLine("Example 3.\n=== String and chars literals ===\n");
            string s1 = @"\t\\\\\\\\\\";
            string s2 = "\t\\\\\\\\\\";
            Console.WriteLine("s1: {0}\ns2: {1}\n\n", s1, s2);

            Console.WriteLine("{0}{1}{2}{3}{4}{5}{6}{7}{8} cats",
                                'J', 'o', 'e', ' ', 'h', 'a', 's', ' ', '3');
            Console.ReadLine();
            Console.Clear();
	
    // 5. Test of checked operator (for unchecked the loop is infinite)
            Console.WriteLine("Example 4.\n=== Test of checked and unchecked operators ===\n");
            byte
            //sbyte
            //short 
            //ushort
            //uint
            y = 0;
            try
            {
                while (y < 1000000) checked { y++; Console.WriteLine("Result: {0}", y); }
                //while (y < 1000000) unchecked { y++; Console.WriteLine("Result: {0}", y); }
                //while (y < 1000000) { y++; Console.WriteLine("Result: {0}", y); }
            }
            catch (Exception e) { Console.WriteLine("Enough. Maximum acceptable value is: {0}\n",y ,e); }
	
    // reading from a console, convertion and printing
            Console.Write("Enter a value to convert to double: ");
			string s = Console.ReadLine();
            double d;
            // simple way to convert
            d = Convert.ToDouble(s);
            // other way, with conversion failure under control
            //s = (Double.TryParse(s, out d)==true)? d.ToString(): "Conversion failed";
            Console.WriteLine(s);

    // reading from a console, here in order to stop a console
            Console.ReadLine();

		} // end of method

	} // end of class
