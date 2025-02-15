namespace BazaDanych.Model
{
    internal class Author
    {
        public Author(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public Author()
        {
        }

        public int AuthorId { get; }
        public string Name { get; }
        public string Surname { get; }

        public override string? ToString()
        {
            return $"{AuthorId} | {Name} |  {Surname}";
        }
    }
}