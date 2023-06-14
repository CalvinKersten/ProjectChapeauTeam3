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
using System.Windows.Forms.VisualStyles;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        public KitchenBar()
        {
            InitializeComponent();

            ShowOrderDetailPanel();
        }

        private List<OrderDetail> GetOrderDetails()
        {
            return new OrderDetailService().GetOrderDetails();
        }

        private void DisplayOrderDetails(List<OrderDetail> orderDetails)
        {
            listViewKitchen.Clear();
            listViewKitchen.View = View.Details;
            listViewKitchen.Columns.Add("Order ID", 100);
            listViewKitchen.Columns.Add("Order number");
            listViewKitchen.Columns.Add("Count");
            listViewKitchen.Columns.Add("Description");

            foreach (OrderDetail item in orderDetails)
            {
                ListViewItem li = new ListViewItem(item.Order_DetailID.ToString());
                //  li.SubItems.Add(item.Comment);
                li.SubItems.Add(item.Item_Quantity.ToString());
                li.SubItems.Add(item.Comment);
                // li.Tag = item;
                listViewKitchen.Items.Add(li);
            }

            foreach (OrderDetail orderDetail in orderDetails)
            {
                ListViewItem item = new ListViewItem(orderDetail.Order_DetailID.ToString());
                item.Tag = orderDetail;
            }
            listViewKitchen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewKitchen.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void ShowOrderDetailPanel()
        {
            KitchenPanel.Show();
            List<OrderDetail> orderDetails = GetOrderDetails();
            DisplayOrderDetails(orderDetails);

        }

        private void listView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);
            e.Graphics.DrawString(e.Header.Text, Font,
                Brushes.Black, e.Bounds);
        }
    }
}
