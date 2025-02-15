using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazaDanych.Model
{
    internal class Wage
    {
        public Wage(decimal amount, int workerId)
        {
            Amount = amount;
            WorkerId = workerId;
        }

        public decimal Amount { get; }
        public int WageId { get; }
        public int WorkerId { get; }

        public override string? ToString()
        {
            return $"{WageId} | {WorkerId} |  {Amount}";
        }
    }
}