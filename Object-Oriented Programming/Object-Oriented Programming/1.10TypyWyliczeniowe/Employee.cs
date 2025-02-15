namespace _1._10TypyWyliczeniowe
{
    public enum ContractType
    {
        Trial, Intership, Temporaty, Other
    }

    public class Employee
    {
        public ContractType ContractType { get; set; }
        public string Name { get; set; }
    }
}