using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad23
{
    internal class BankAccount
    {
        private int AccountId { get; set; }
        public string AccountNumber { get; set; }
        private string Password { get; set; }

        private decimal Amount { get; set; }
        public class SavingsAccount
        {
            private int AccountId { get; set; }
            private string AccountNumber { get; set; }
            private decimal Amount { get; set; }
        }
        public class SplitPayment
        {
            private int SplitPaymentId { get; set; }
            private decimal VatAmount { get; set; }
            private decimal NetIncome { get; set; }
            private bool Mpp { get; set; }
        }
    }
}
