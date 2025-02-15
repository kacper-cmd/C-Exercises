namespace _1_7Wlasciwosci
{
    internal class Person
    {
        private int? _age;
        private string? _sex;

        public string Name { get; set; }
        public string Surname { get; set; }
        private int? Age
        {
            get { return _age; }
            set
            {
                if (value < 101 && value > 0)
                    _age = value;
                else
                    _age = null;
            }
        }
        private string? Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                if (value.Contains("kobieta") || value.Contains("mężczyzna") || value.Contains("inna"))
                {
                    _sex = value;
                }
                else
                    _sex = null;
            }
        }
    }
}
