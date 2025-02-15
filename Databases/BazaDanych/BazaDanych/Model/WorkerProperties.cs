using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    internal class WorkerProperties
    {
        public decimal Amount { get; }
        public string Name { get; }
        public string Surname { get; }
        public int WorkerId { get; }

        public override string? ToString()
        {
            return $"{WorkerId} |  {Name} |  {Surname} | {Amount}";
        }
    }
}