using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauDAL;
using ChapeauModel;
using ChapeauService;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        public KitchenBar()
        {
            InitializeComponent();
        }

        private void ShowDashboardPanel()
        {
            KitchenPanel.Show();
        }

        private List<OrderDetail> GetOrder()
        {
            OrderDetailService orderDetaildb = new OrderDetailService();
            List<OrderDetail> orders = orderDetaildb.GetOrder();

            return orders;
        }

        private void DisplayOrder(List<OrderDetail> orders)
        {
            listViewOrder.Clear();
            listViewOrder.View = View.Details;
            listViewOrder.Columns.AddRange(new[] {
        new ColumnHeader { Text = "Student ID" },
        new ColumnHeader { Text = "First Name" },
        new ColumnHeader { Text = "Last Name" },
       // new ColumnHeader { Text = "Phone Number" },
    });

            
        }
    }
}

