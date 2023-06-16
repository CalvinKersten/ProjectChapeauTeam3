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
using System.Data.SqlClient;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        public KitchenBar()
        {
            InitializeComponent();
            ShowOrderDetailPanel();
        }
        public List<OrderDetail> GetOrderDetails()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> orderDetail = orderDetailService.GetOrderDetails();
            return orderDetail;
        }

        public List<OrderDetail> RunningOrders()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> runningOrder = orderDetailService.RunningOrders();
            return runningOrder;
        }
        public List<OrderDetail> KitchenOrders()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> kitchenOrder = orderDetailService.KitchenOrders();
            return kitchenOrder;
        }
        public List<OrderDetail> CompletedOrders()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> completedOrder = orderDetailService.CompletedOrders();
            return completedOrder;
        }


        private void DisplayRunningOrders(List<OrderDetail> runningOrder)
        {
            ListViewRunningOrders.Clear();
            ListViewRunningOrders.View = View.Details;
            ListViewRunningOrders.Columns.Add("Order ID", 110);
            ListViewRunningOrders.Columns.Add("Order number", 155); //table number
            ListViewRunningOrders.Columns.Add("Count", 90);
            ListViewRunningOrders.Columns.Add("Description", 330);

            foreach (OrderDetail item in runningOrder)
            {
                ListViewItem li = new ListViewItem(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Item_Quantity.ToString());
                li.SubItems.Add(item.MenuItem.Item_Name.ToString());
                li.Tag = item;
                ListViewRunningOrders.Items.Add(li);
            }
        }

        private void DisplayCompletedOrders(List<OrderDetail> completedOrder)
        {
            listViewCompletedOrders.Clear();
            listViewCompletedOrders.View = View.Details;
            listViewCompletedOrders.Columns.Add("Order ID", 110);
            listViewCompletedOrders.Columns.Add("Order number", 155); //table number
            listViewCompletedOrders.Columns.Add("Count", 90);
            listViewCompletedOrders.Columns.Add("Description", 330);

            foreach (OrderDetail item in completedOrder)
            {
                ListViewItem li = new ListViewItem(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Item_Quantity.ToString());
                li.SubItems.Add(item.MenuItem.Item_Name.ToString());
                li.Tag = item;
                listViewCompletedOrders.Items.Add(li);
            }
        }
        private void DisplayKitchenOrder(List<OrderDetail> orderDetail)
        {
            listViewOrderId.Clear();
            listViewOrderId.View = View.Details;
            listViewOrderId.Columns.Add("Order ID", 110);
            listViewOrderId.Columns.Add("Order number", 155); //table number
            listViewOrderId.Columns.Add("Count", 90);
            listViewOrderId.Columns.Add("Description", 330);

            foreach (OrderDetail item in orderDetail)
            {
                ListViewItem li = new ListViewItem(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Order_DetailID.ToString());
                li.SubItems.Add(item.Item_Quantity.ToString());
                li.SubItems.Add(item.MenuItem.Item_Name.ToString());
                li.Tag = item;
                listViewOrderId.Items.Add(li);
            }
        }

        private int GetItemAmount(int orderDetailID, List<OrderDetail> orderDetails)
        {
            //find the table with the corresponding TableID
            OrderDetail orderDetail = orderDetails.Find(OrD => OrD.Order_DetailID == orderDetailID);
            if (orderDetail != null)
            {
                return orderDetail.Item_Quantity;
            }
            return 0;
        }

        private string GetItemName(int menuItemID, List<MenuItem> menuItems)
        {
            //find the table with the corresponding TableID
            MenuItem menuItem = menuItems.Find(Men => Men.Menu_ItemID == menuItemID);
            if (menuItem != null)
            {
                return menuItem.Item_Name.ToString();
            }
            return string.Empty;
        }

        private void ShowOrderDetailPanel()
        {
            KitchenPanel.Show();
            List<OrderDetail> orderDetails = GetOrderDetails();
            //  DisplayOrder(orderDetails);
            DisplayKitchenOrder(orderDetails);
        }

        private void PreparationBtn_Click(object sender, EventArgs e)
        {
            lblOrderStatusFirst.Text = "In preparation";
        }

        private void PreaparedBtn_Click(object sender, EventArgs e)
        {
            lblOrderStatusFirst.Text = "Prepared";
        }

        private void ServedBtn_Click(object sender, EventArgs e, List<OrderDetail> orderDetail)
        {
            lblOrderStatusFirst.Text = "Served";

            //string conString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2;User=SomerenTeam2;Password=ProjectT3Team2";
            //string query = "INSERT INTO Order_Detail (Item_Quantity, Order_Time, Order_Status, Comment) VALUES (@ItemQuantity, @Order_Time, @Order_Status, @Comment)";
            //SqlConnection con = new SqlConnection(conString);
            //DateTime time = new DateTime();

            //string OrderStatus = "";
            //string Comment = "";
            //string OrderTime = time.ToString("hh/mm/ss");
            ////int ItemQuantity = 0;

            //foreach (OrderDetail item in orderDetail)
            //{
            //    OrderStatus = "Running";
            //    Comment = "";
            //   // ItemQuantity = int.Parse(item.SubItems[0].Text);
            //}
        }

        //text alignment for column subitems
        private void lvorder(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;

            if (e.ColumnIndex < 3)
            {
                flags = TextFormatFlags.HorizontalCenter;
            }
            e.DrawText(flags);
        }

        //text alignment for column header
        private void lvorder(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Orange, e.Bounds);

            TextFormatFlags flags = TextFormatFlags.Left;
            if (e.ColumnIndex == 0)
            {
                flags = TextFormatFlags.HorizontalCenter;
            }
            e.DrawText(flags);

        }
        private void ViewSelectedOrderId(object sender, EventArgs e)
        {
            if (listViewOrderId.SelectedItems.Count > 0)
            {
                ListViewItem item = listViewOrderId.SelectedItems[0];
                lblSelectedFirst.Text = item.SubItems[0].Text;
            }
        }

        private void btnRunningOrders_Click(object sender, EventArgs e)
        {
            KitchenPanel.Hide();
            panelCompletedOrders.Hide();
            panelRunningOrders.Show();
            List<OrderDetail> runningOrder = RunningOrders();
            //  DisplayOrder(orderDetails);
            DisplayRunningOrders(runningOrder);

        }

        private void btnCompletedOrders_Click(object sender, EventArgs e)
        {
            KitchenPanel.Hide();
            panelRunningOrders.Hide();
            panelCompletedOrders.Show();
            List<OrderDetail> completedOrder = CompletedOrders();
            //  DisplayOrder(orderDetails);
            DisplayCompletedOrders(completedOrder);
        }

        private void btnOverviewFromRunning_Click(object sender, EventArgs e)
        {
            KitchenPanel.Show();
            panelRunningOrders.Hide();
            panelCompletedOrders.Hide();
        }

        private void btnOverviewFromCompleted_Click(object sender, EventArgs e)
        {
            KitchenPanel.Show();
            panelRunningOrders.Hide();
            panelCompletedOrders.Hide();
        }

        //private void Addingtime()
        //{
        //    TimeSpan timePassed = DateTime.Now - OrderDetail.Order_Time;
        //    lbl.txt = timepassed.ToString(@"hh\:mm");
        //}
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            if (username == "0004" && password == "0000")
            {
                KitchenLabel.Text = "Kitchen Orders";
                KitchenPanel.Show();
                panelRunningOrders.Hide();
                panelCompletedOrders.Hide();
                panelLogin.Hide();
            }
            else if (username == "0003" && password == "0000")
            {
                KitchenLabel.Text = "Bar Orders";
                KitchenPanel.Show();
                panelRunningOrders.Hide();
                panelCompletedOrders.Hide();
                panelLogin.Hide();
            }
            else
            {
                MessageBox.Show("something went wrong");
            }
        }

    }
}
