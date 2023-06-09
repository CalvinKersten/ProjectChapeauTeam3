using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauDAL;
using ChapeauService;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        public KitchenBar()
        {
            InitializeComponent();
        }

        private List<OrderDetail> GetAllOrderDetails()
        {
            return new OrderDetailService().GetAllOrderDetails();
        }


        private void DisplayOrderDetails(List<OrderDetail> orderDetails)
        {
            listViewOrder.Clear();
            listViewOrder.View = View.Details;
            foreach (OrderDetail item in orderDetails)
            {
                ListViewItem li = new ListViewItem(item.OrderDetailID.ToString());
                li.SubItems.Add(item.Comment);
                li.SubItems.Add(item.ItemQuantity.ToString());
                li.Tag = item;
                listViewOrder.Items.Add(li);

            }
        }

        private void ShowOrderDetailPanel()
        {
            KitchenPanel.Show();

            List<OrderDetail> orderDetails = GetAllOrderDetails();
            DisplayOrderDetails(orderDetails);
        }
    }
}
