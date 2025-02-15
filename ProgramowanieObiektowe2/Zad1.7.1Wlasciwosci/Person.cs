namespace Zad1._7._1Wlasciwosci;
public class Person
{
    #region Fields&Properties

    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string surname;
    public string Surname
    {
        get { return surname; }
        set { surname = value; }
    }

    private int age;
    public int Age
    {
        get { return age; }
        // private set
        set
        {
            if (value >= 1 && value <= 100)
            {
                age = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
            }
        }
    }

    private string gender;
    public string Gender
    {
        get { return gender; }
        //private set
        set
        {
            if (value == "female" || value == "male" || value == "other")
            {
                gender = value;
            }
            else
            {
                throw new ArgumentException("Gender must be:  female, male, other");
            }
        }
    }

    #endregion

    #region Constructors
    public Person(string name, string surname)
    {
        this.name = name;
        this.surname = surname;
    }
    #endregion

    #region Methods
    //zad 1
    public void SetAge(int age)
    {
        if (age >= 1 && age <= 100)
        {
            this.age = age;
        }
        else
        {
            throw new ArgumentOutOfRangeException("Age must be between 1 and 100.");
        }
    }
    //zad 1
    public void SetGender(string gender)
    {
        if (gender == "female" || gender == "male" || gender == "other" )
        {
            this.gender = gender;
        }
        else
        {
            throw new ArgumentException("Gender must be provided.");
        }
    }
    #endregion
}