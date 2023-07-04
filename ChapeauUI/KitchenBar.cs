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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChapeauUI
{
    public partial class KitchenBar : Form
    {
        private OrderDetailService detailService;
        private Catagory catagory;
        private Employee employee;
        private OrderDetail OrderDetail;
        private Order order;
        private EmployeeService employeeService;

        public KitchenBar()
        {
            InitializeComponent();
            employeeService = new EmployeeService();
            detailService = new OrderDetailService();
            panelLogin.Show();
            KitchenPanel.Hide();
        }
        private void DisplayKitchenBarView(Employee employee)
        {
            lblOrderStatus.Text = "Order Overview";

            //Display screen title based on employee type
            if (employee.Role == Role.Chef)
            {
                KitchenLabel.Text = "Kitchen View";
            }
            else if (employee.Role == Role.Barman)
            {
                KitchenLabel.Text = "Bar View";
            }

            //Get orders by for kitchen or bar, depends on employee type
            List<Order> orders = GetOrders(employee);

            //Fill in the listview with orders
            KitchenAndBarView(orders);
        }
        /// getting orders for bar and kitchen based on Employee Role
        private List<Order> GetOrders(Employee employee)
        {
            List<Order> orders = new List<Order>();

            switch (employee.Role)
            {
                case Role.Chef:
                    orders = detailService.ReadOrdersForKitchenBar(Catagory.Food, OrderStatus.Ordered);
                    break;
                case Role.Barman:
                    catagory = Catagory.NonAlcDrink;
                    catagory = Catagory.AlcDrink;
                    orders = detailService.ReadOrdersForKitchenBar(catagory, OrderStatus.Ordered);
                    break; 
            }
            return orders;
        }

        // listview of foods or drinks

        private void KitchenAndBarView(List<Order> orders)
        {
            listViewOrder.Items.Clear();
            listViewOrder.View = View.Details;

            listViewOrder.Columns.Add("Order ID", 120);
            listViewOrder.Columns.Add("Table No.", 120); //table number
            listViewOrder.Columns.Add("Count", 100);
            listViewOrder.Columns.Add("Description", 290);
            listViewOrder.Columns.Add("Status", 115);
            listViewOrder.Columns.Add("Order Time", 135);
           listViewOrder.Columns.Add("Note", 150);

            // foreach (OrderDetail item in orderDetails)
            {
                foreach (Order order in orders)
                {
                    ListViewItem li = new ListViewItem(order.OrderDetail.OrderDetailID.ToString());
                    li.SubItems.Add(order.Table.TableNumber.ToString());
                    li.SubItems.Add(order.OrderDetail.ItemQuantity.ToString());
                    li.SubItems.Add(order.OrderDetail.MenuItem.ItemName.ToString());
                    li.SubItems.Add(order.OrderDetail.OrderStatus.ToString());

                    string dateTimeToShow;
                    if (CheckOrderTime(order.OrderDetail))
                    {
                        TimeSpan dateTime = DateTime.Now.Subtract(order.OrderDetail.OrderTime);
                        dateTimeToShow = dateTime.Minutes.ToString() + " min ago";
                        li.SubItems.Add(dateTimeToShow);
                    }
                    else
                    {
                        li.SubItems.Add(order.OrderDetail.OrderTime.ToString("H:mm"));
                    }
                    li.SubItems.Add(order.OrderDetail.Comment.ToString());
                    li.Tag = order.OrderDetail;
                    listViewOrder.Items.Add(li);
                }
            }
        }

        /// to keep track of ordered time 
        private bool CheckOrderTime(OrderDetail orderDetail)
        {
            return orderDetail.OrderStatus == OrderStatus.Preparing;
        }

        /// Buttons added ///

        
        /// displaying list of completed orders
        private void btnCompletedOrders_Click(object sender, EventArgs e)
        {
            lblOrderStatus.Text = "Completed Orders";
            btnCompletedOrders.Visible = false;
            btnRunningOrders.Visible = true;
            listViewOrder.Clear();

            List<Order> orders = detailService.ReadOrdersForKitchenBar(catagory, OrderStatus.Completed);
            // listViewOrderId.Clear();
            KitchenAndBarView(orders);
        }

        /// displaying list of running orders
        private void btnRunningOrders_Click(object sender, EventArgs e)
        {
            lblOrderStatus.Text = "Running Orders";
            btnRunningOrders.Visible = false;
            btnCompletedOrders.Visible = true;
            listViewOrder.Clear();

            List<Order> orders = detailService.ReadOrdersForKitchenBar(catagory, OrderStatus.Preparing);
            KitchenAndBarView(orders);
        }

        /// changes order status to 'Prepared'
        private void PreaparedBtn_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewOrder.SelectedItems)
                {
                    OrderDetail orderDetail = (OrderDetail)selectedItem.Tag;
                    if (orderDetail != null)
                    {
                        detailService.ChangingOrderStatus(orderDetail, OrderStatus.Completed);
                        listViewOrder.Items.Remove(selectedItem);
                    }
                }
            }
        }

        private void btnPreparing_Click(object sender, EventArgs e)
        {
            if (listViewOrder.SelectedItems.Count > 0)
            {
                foreach (ListViewItem selectedItem in listViewOrder.SelectedItems)
                {
                    OrderDetail orderDetail = (OrderDetail)selectedItem.Tag;
                    if (orderDetail != null)
                    {
                        detailService.ChangingOrderStatus(orderDetail, OrderStatus.Preparing);
                        listViewOrder.Items.Remove(selectedItem);
                    }
                }
            }
        }

        private void btnOrderOverview_Click(object sender, EventArgs e)
        {
            lblOrderStatus.Text = "Order Overview";
            btnRunningOrders.Visible = true;
            listViewOrder.Clear();
            List<Order> orders = detailService.ReadOrdersForKitchenBar(catagory, OrderStatus.Ordered);
            KitchenAndBarView(orders);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lblOrderStatus.Text = "Running Orders";
            listViewOrder.Clear();
            List<Order> orders = detailService.ReadOrdersForKitchenBar(catagory, OrderStatus.Preparing);
            KitchenAndBarView(orders);
        }

        ///  text alignment for column subitems
        private void lvorder(object sender, DrawListViewSubItemEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;
            if (e.ColumnIndex < 3)
            {
                flags = TextFormatFlags.HorizontalCenter;
            }
            e.DrawText(flags);
        }

        ///  text alignment for column header
        private void lvorder(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            TextFormatFlags flags = TextFormatFlags.Left;
            if (e.ColumnIndex == 0)
            {
                flags = TextFormatFlags.HorizontalCenter;
            }
            e.DrawText(flags);
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            lblOrderStatus.Text = "Order Overview";
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            Employee employee = employeeService.VerifyCredentials(username, password);

            if (employee != null)
            {
                if ((employee.Role == Role.Chef) || (employee.Role == Role.Barman))
                {
                    panelLogin.Hide();
                    KitchenPanel.Show();
                    DisplayKitchenBarView(employee);
                }
                else 
                {
                    POSChapeau posChapeau = new POSChapeau();
                    posChapeau.Show();
                    
                }
            }
        }
    }
}
