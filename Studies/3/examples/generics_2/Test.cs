using System;

    class Test
    {
        static void Main(string[] args)
        {
            Person friend = new Person("Jan", "Nowak", false, 180, 90);
            Person boss = new Person("Janina", "Kloss", true, 175, 68.55f);
            Person colleague = new Person("Agata", "Nowak", true, 170, 66.66f);

            Group<Person> persons = new Group<Person>("Team", friend, boss, colleague);
            persons.Show();

            Student veryGoodStudent = new Student("Jan", "Nowak", false);
            Student goodStudent = new Student("Janina", "Kloss", true);
            Student normalStudent = new Student("Agata", "Nowak", true);

            Group<Student> GroupOfStudents = new Group<Student>("Year IV", veryGoodStudent, goodStudent, normalStudent);
            GroupOfStudents.Show();

            // what to do to make below correct and working?
            /*
            Product[] products = new Product[] { new Product("Wardrobe", 3000, 0.22f),
                                           new Product("Table", 1000, 0.22f),
                                           new Product("Chair", 700, 0.22f)
                                         };
            Group<Product> productsGroup = new Group<Product>("Warehouse", products);
            productsGroup.Show();
            */

            Console.ReadLine();
        }
    }

