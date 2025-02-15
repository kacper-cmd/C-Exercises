namespace BazaDanych.Model
{
    internal class Book
    {
        public Book(string name, int departmentId)
        {
            Name = name;
            DepartmentId = departmentId;
        }

        public int BookId { get; }
        public int DepartmentId { get; }
        public string Name { get; }

        public override string? ToString()
        {
            return $"{BookId} | {DepartmentId} |  {Name}";
        }
    }
}