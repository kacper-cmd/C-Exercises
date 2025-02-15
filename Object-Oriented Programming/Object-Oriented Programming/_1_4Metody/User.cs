namespace _1_4Metody
{
    internal class User
    {
        public string Name { get; set; }
        public Sex Sex { get; set; }
        public int Age { get; set; }
        public User(string name, Sex sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public static void Add5AndDisplayUsers(List<User> users, Action displayMethod)
        {
            users.Add(new User("Adam", Sex.Man, 6));
            users.Add(new User("Jan", Sex.Man, 6));
            users.Add(new User("Monika", Sex.Woman, 22));
            users.Add(new User("Jessica", Sex.Woman, 27));
            users.Add(new User("Joanna", Sex.Woman, 78));

            displayMethod();


        }
        public override string ToString()
        {
            return $"imie: {Name}, płeć: {Sex}, wiek: {Age}";
        }
    }
    public enum Sex
    {
        Man = 0,
        Woman = 1
    }
}
