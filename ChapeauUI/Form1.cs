using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using ChapeauModel;
using ChapeauDAL;
using ChapeauService;
using System.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace ChapeauUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            ShowOrderOverviewPnl();
        }
        private void OpenPanel(Control panelToOpen) // closes all panels except for the panel in the argument and the default Menu panel
        {
            foreach (Control control in Controls)
            {
                if (control is Panel panel && panel != panelToOpen && panel != pnlMenu)
                {
                    panel.Hide();
                    panelToOpen.Show();
                }
            }
            
        }
        private void ShowOrderOverviewPnl()
        {
            OpenPanel(pnlTableOverview); //Opens the OrderOverviewPNL

            try
            {
                List<Order> orders = GetOrders();
                List<OrderDetail> orderDetails = GetOrderDetails();
                List<MenuItem> menuItems = GetMenuItems();
               /* List<Table> tables = GetTables();
                List<Employee> employees = GetEmployees();*/
                DisplayTableOrderOverview(orders, orderDetails, menuItems);
            }
            catch (Exception e)
            {
                MessageBox.Show("Whoops, the order overview could not be loaded.\n" +
                    "Please try to restart the application or contact your manager. " + e.Message);
            }

        }
        public List<MenuItem> GetMenuItems()
        {
            MenuItemService menuItemService = new MenuItemService();
            List<MenuItem> menuItems = menuItemService.GetMenuItems();
            return menuItems;
        }
        public List<Table> GetTables()
        {
            TableService tableService = new TableService();
            List<Table> tables = tableService.GetTables();
            return tables;
        }
        public List<Order> GetOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetOrders();
            return orders;
        }
        public List<Employee> GetEmployees()
        {
            EmployeeService employeeService = new EmployeeService();
            List<Employee> employee = employeeService.GetEmployees();
            return employee;
        }
        public List<OrderDetail> GetOrderDetails()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> orderDetail = orderDetailService.GetOrderDetails();
            return orderDetail;
        }
        private void DisplayTableOrderOverview(List<Order> orders, List<OrderDetail> orderDetails, List<MenuItem> menuItems)
        {
            //Clearing the LV before displaying
            LVOrderOverview.Clear();
            //Filling the LV Column headers
            LVOrderOverview.View = View.Details; //Displays each item on a seperate line
            LVOrderOverview.Columns.Add("no.", 50);
            LVOrderOverview.Columns.Add("name", 200);
            LVOrderOverview.Columns.Add("price",LVOrderOverview.Width - 250);

            foreach (Order order in orders)
            {
                ListViewItem item = new ListViewItem(GetItemAmount(order.OrderDetailID, orderDetails));
                item.SubItems.Add(GetItemName(order.MenuItemID, menuItems));
                item.SubItems.Add("€" + order.TotalPrice.ToString(".00"));
                item.Tag = order;   // link table object to listview item
                LVOrderOverview.Items.Add(item);
            }
        }

        private string GetItemAmount(int orderDetailID, List<OrderDetail> orderDetails)
        {
            //find the table with the corresponding TableID
            OrderDetail orderDetail = orderDetails.Find(OrD => OrD.OrderDetailID == orderDetailID);
            if (orderDetail != null)
            {
                return orderDetail.ItemQuantity.ToString();
            }
            return string.Empty;
        }
        private string GetItemName(int menuItemID, List<MenuItem> menuItems)
        {
            //find the table with the corresponding TableID
            MenuItem menuItem = menuItems.Find(Men => Men.MenuItemID == menuItemID);
            if (menuItem != null)
            {
                return menuItem.ItemName.ToString();
            }
            return string.Empty;
        }
        /* private string GetTableNumber(int tableID, List<Table> tables)
         {
             //find the table with the corresponding TableID
             Table table = tables.Find(tb1 => tb1.TableID == tableID);
             if (table != null)
             {
                 return table.Table_Num.ToString();
             }
             return string.Empty;
         }
         private string GetEmployeeName(int employeeID, List<Employee> employees)
         {
             //find the table with the corresponding TableID
             Employee employee = employees.Find(emp => emp.EmployeeID == employeeID);
             if (employee != null)
             {
                 return employee.LastName.ToString();
             }
             return string.Empty;
         }*/



        //
        //
        //
        //
        // NAV
        private void LunchNavButton_Click(object sender, EventArgs e)
        { 
            OpenPanel(pnlOrderViewLunch);

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = false;

            LunchNavButton.BackColor = Color.LightGray;
            DinnerNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }

        private void DinnerNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDinner);

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = false;
            LunchNavButton.Enabled = true;

            DinnerNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }

        private void DrinksNavButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlOrderViewDrinks);

            DrinksNavButton.Enabled = false;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = true;

            DrinksNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DinnerNavButton.BackColor = Color.LightGreen;
        }
    }
}
