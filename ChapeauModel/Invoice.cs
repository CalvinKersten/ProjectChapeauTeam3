using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Invoice
    {
        public int InvoiceID { get; set; }
        public float Subtotal { get; set; }
        public int TaxRate { get; set; }
        public decimal Tip { get; set; }
        public decimal Total { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string Feedback { get; set; }
        public int OrderID { get; set; }

    }
}
