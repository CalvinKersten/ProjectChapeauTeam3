using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class InvoiceService
    {
        private InvoiceDao invoicedb;

        public InvoiceService()
        {
            invoicedb = new InvoiceDao();
        }

        public List<Invoice> GetInvoices()
        {
            List<Invoice> invoices = invoicedb.GetAllInvoices();
            return invoices;
        }
    }
}
