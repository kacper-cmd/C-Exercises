using System;

    struct Salary
    {
        decimal basic; // = 0; // initialization not allowed
        decimal bonus;
        decimal hourlyRate;
        int overtimeCount;

        public Salary(decimal b, decimal bs, decimal hr, int oc)
        {
            basic = b;
            bonus = bs;
            hourlyRate = hr;
            overtimeCount = oc;
        }

        decimal Calculate()
        {
            return basic + bonus + overtimeCount * hourlyRate;
        }

        public void Show()
        {
            Console.WriteLine("Earns {0:c}", Calculate());
        }
    }

    // a class derived (inheriting) from Person 
    class Employee : Person
    {
        string function;
        DateTime employeeDate;
        //public new string surname;              

        Salary salary;                                        

        // default constructor
        public Employee()
        {
            Console.WriteLine("Default employee created");
        }

        public Employee(string name, string surname, bool female, string function)
            : base(name, surname, female, null, null)
        {
            this.function = function;
            employeeDate = new DateTime();            
            //this.surname = "XXX"; 
        }
                
        public new void Show()
        {
            Console.WriteLine("Employee: {2}, {0} {1}", name, surname, function);
        }
        
        public override void Show2()
        {
            Console.WriteLine("Employee is {2}, {0} {1}", name, surname, function);
        }

        public int Seniority()
        {
            return DateTime.Now.Year - employeeDate.Year;
        }

        public void ShowWithSalary()
        {
            Show2();
            salary.Show();
        }

        public void SetSalary(decimal b, decimal bs, decimal hr, int oc)
        {
            salary = new Salary(b, bs, hr, oc);
        }

    }

