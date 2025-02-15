using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    internal class Worker
    {
        public Worker(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }

        public string Name { get; }
        public string Surname { get; }
        public int WorkerId { get; }

        public override string? ToString()
        {
            return $"{WorkerId} |  {Name} | {WorkerId}";
        }
    }
}