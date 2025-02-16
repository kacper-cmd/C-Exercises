using System;

namespace classes_3_3
{
    class Test
    {
        static void Main(string[] args)
        {            
            numericImplicitConversions();
            otherImplicitConversions();

            explicitConversions();

            programmistConversions();

            Console.ReadLine();
        }

        static void numericImplicitConversions()
        {
         // numeric conversions examples
         // (valid if target type is wider)
            sbyte a = -128;
            short b = a;
            int c = b;
            long d = c;

            char e = 'A';
            decimal f = e;

            float g = 1.234f;
            double h = g;

         // implicit conversion with loss of information
            int x = 2123456789;
            float y = x;
            Console.WriteLine($"{y:f}");
         
         // constant conversion from int to byte
         // (valid if the value is in target type domain)
            const int i = 255;
            b = i;
            // a = i; // wrong, but for i = -128..127 will be OK
            
          // constant conversion from long to ulong
          // (valid if the value is in target type domain)
            const long j = 10;
            ulong k = j;
        }

        static void otherImplicitConversions() {
            
            // enumeration conversions (zero to any enumeration type)       
            DateLimit dl = 0;
            MaritalStatus ms = 0;
            Console.WriteLine(dl);
            Console.WriteLine(ms);

            // nullable conversion
            DateLimit? dl2 = dl;
            int? x = 5;
            long? y = x;

            // reference conversions
            Person somebody = new Person();
            object @object = somebody;

            Group students = new StudentGroup("First year");

            // boxing
            Double z = 3.4;
        }

        static void explicitConversions()
        {
           // numeric
            long @long = 50; // try 500, then 6
            byte @byte = (byte)@long;
            Console.WriteLine("long before conversion: {0}, and after conversion to byte: {1}", @long, @byte);

          // enumeration
            DateLimit dl = (DateLimit)@byte;
            MaritalStatus ms = (MaritalStatus)DateLimit.Quarter;
            Console.WriteLine("byte before conversion: {0}, and after conversion to DateLimit: {1}", @byte, dl);

          // nullable
            int? @int = (int?)@long;
            
          // reference
            object obj = null;
            Group g = (Group)obj;
         
          // unboxing
            object x = 50;
            int y = (int)x;

            Console.WriteLine();
        }

        public static void programmistConversions() {
            Person friend = new Person("Jan","Nowak",false,180,90);
            
            Group g = friend;
            g.Show();
            Console.WriteLine();

            Person boss = new Person("Janina", "Kloss", true, 175, 68.55f);
            Person girl = new Person("Agata", "Nowak", true, 170, 66.66f);            
            Group g2 = new Group(3);
            g2.add(boss, girl, friend);

            Person g2ToPerson = (Person)g2;
            g2ToPerson.Show();
        }
        
    }

    enum MaritalStatus : byte { Single = 1, Married, Divorced, Widowed };
    enum DateLimit { DayOfSale = 0, Month, Quarter = 3, HalfAYear = 6, Year = 12 };


    partial class Person {
        
        // Conversions defined by a programmist
        
        // Definition of conversion from a person to a group
        // implicit conversion, works also as explicit     
        ///*
        public static implicit operator Group(Person a)
        {
            Console.WriteLine("Implicit conversion from a person to a group");
            Group g = new Group(1);
            g.add(a);
            return g;
        }
        //*/

        /*
        public static explicit operator Group(Person a)
        {
            Console.WriteLine("Explicit conversion from a person to a group");
            Group g = new Group(1);
            g.add(a);
            return g;
        }
        */
        
        // Definition of conversion a group to a person
        // only explicit - attempt to use implicit conversion causes an compilation error     
        public static explicit operator Person(Group g)
        {
            Console.WriteLine("Explicit conversion from a group to a person");
            return g.Leader;
        }        

    }

}
