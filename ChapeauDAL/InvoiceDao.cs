using System;
using ChapeauModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ChapeauDAL
{
    public class InvoiceDao : BaseDao
    {
        public List<Invoice> GetAllInvoices()
        {
            string query = "SELECT InvoiceID, Subtotal, Tax_Rate, Tip, Total, Payment_Amount, Payment_Method, Feedback, OrderID FROM Employee";
            SqlParameter[] sqlParameters = new SqlParameter[0];
            return ReadTables(ExecuteSelectQuery(query, sqlParameters));
        }

        private List<Invoice> ReadTables(DataTable dataTable)
        {
            List<Invoice> invoices = new List<Invoice>();

            foreach (DataRow dr in dataTable.Rows)
            {
                Invoice invoice = new Invoice()
                {
                    InvoiceID = (int)dr["InvoiceID"],
                    Subtotal = (float)dr["Subtotal"],
                    TaxRate = (int)dr["Tax_Rate"],
                    Tip = (float)dr["Tip"],
                    Total = (float)dr["Total"],
                    PaymentAmount = (float)dr["Payment_Amount"],
                    PaymentMethod = dr["Payment_Method"].ToString(),
                    Feedback = dr["Feedback"].ToString(),
                    OrderID = (int)dr["OrderID"],
                };
                invoices.Add(invoice);
            }
            return invoices;
        }

        private void CalculateVAT()
        {
            //percentage of VAT over every individual product
        }
        private void SubTotal()
        {
            //Price of all ordered items 
        }
        private void Total()
        {
            //Price of all ordered items together + tip
        }

        private void CalculateTip()
        {
            //total - subtotal?
        }
    }
}
