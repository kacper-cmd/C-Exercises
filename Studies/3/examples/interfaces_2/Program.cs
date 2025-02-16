using System;

/*
 * A short history, how and why this example was created:
 * 
 * 1. I need a class to manage of a list of various things
 * 
 * 2. I had general concept as "menu loop", so I wrote a code using general business commands executed in a loop.
 *    These executions should be responsibility of general "manager" object (the same object stores my list of things).
 *    
 * 3. How to compile such code (or draft of a code) without any concrete classes nor implementation (commands code)?
 *    So I created an interface with declarations of needed methods (coresponding commands) and I used this interface 
 *    as type of my "manager" object (I passed it as a parameter of Manage() method - main method of my program)
 *    
 * 4. Now, I can build any class which implements my interface (ICRUDable)
 *    and a general algorithm works!
 *    Of course, I should pass an object of this class as a parameter of Manage() method.
 *    In below example I did it for Dictionary class (manages a list of words) 
 *    and Warehouse class (manages a list of products)
 *    
 * 5. To make Manage() method more readable I defined Commands enumeration 
 * 
*/


/*
 * Historia powstania tego przykładu:
 * 
 * 1. Potrzebowałem klasy do zarządzania listą jakichś różnych rzeczy
 * 
 * 2. Miałem ogólną koncepcję na algorytm pętli obsługi menu, zatem naszkicowałem ją 
 *    w języku niemal naturalnym, zakładając jakich metod potrzebowałbym w klasie
 *    reprezentującej listę rzeczy (obiekt "meneger").
 *    
 * 3. Jak zrobić, żeby nie mając konkretnych klas reprezentujących listy skompilować taki szkic?
 *    Potrzebne wg mnie metody umieściłem w interfejsie, którego użyłem do typowania obiektu
 *    "meneger" (zdecydowałem się przekazać go przez parametr do metody ObslugaCRUD()).
 *    
 * 4. Teraz wystarczy, że zbuduję dowolną klasę implementującą interfejs, aby ogólny algorytm
 *    obsługi menu działał! Muszę tylko podać jej obiekt jako parametr metody ObslugaCRUD().
 *    W przykładzie klasa Slownik (zarządza listą słów).
 *    
 * 5. Dla wygody dodałem enumerację     
 * 
*/

namespace interfaces_2
{    
    class ManagementOfEverything
    {
        enum Commands { list=1, add, edit, remove, show, select, exit = 10 };
       
        public static void Manage(ICRUDable manager)
        {
            Commands command = 0;
            do
            {
                command = (Commands)manager.SelectFromMenu();
                switch (command)
                {
                    case Commands.list: manager.ShowElementsList(); break;
                    case Commands.add: manager.NewElement(); break;
                    case Commands.edit: manager.EditElement(); break;
                    case Commands.remove: manager.RemoveElement(); break;
                    case Commands.show: manager.ShowElement(); break;
                    case Commands.select: manager.SelectElement(); break;
                }

            } while (command != Commands.exit);
        }


        static void Main(string[] args)
        {

            Manage(new Dictionary());
            //Manage(new Warehouse());
        }
    }
}
