using System;

namespace classes_3_2
{
    class Invoice
    {
        private DateTime submitDate;
        private PaymentPeriod maturity;

        public Invoice(DateTime sD, PaymentPeriod m)
        {
            submitDate = sD;
            maturity = m;
        }

        public DateTime DateOfPayment()
        {
            DateTime result = submitDate;
            result = result.AddMonths((int)maturity);
            return result;
        } // make property rather than method
    }
}
