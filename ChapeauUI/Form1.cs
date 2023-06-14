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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace ChapeauUI
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            SubscribeButtons();
            LoadItems();
        }
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        private void Start()
        {
            ShowOrderOverviewPnl();
        }
        //
        //
        //
        //
        // Events before Loading
        private void LoadItems()
        {
            List<MenuItem> menuItems = GetMenuItems();
            FillLunchPriceTags(menuItems);
            FillDinnerPriceTags(menuItems);
            FillDrinksPriceTags(menuItems);
            DisplayLVLunch();
        }
        //
        //
        //
        //
        // Show Panels
        private void ShowOrderOverviewPnl()
        {
            OpenPanel(pnlTableOverview); //Opens the OrderOverviewPNL

            try
            {
                List<Order> orders = GetOrders();
                List<OrderDetail> orderDetails = GetOrderDetails();
                List<MenuItem> menuItems = GetMenuItems();

                DisplayTableOrderOverview(orders, orderDetails, menuItems);
            }
            catch (Exception e)
            {
                MessageBox.Show("Whoops, the order overview could not be loaded.\n" +
                    "Please try to restart the application or contact your manager\n\n. " + e.Message);
            }

        }
        private void ShowOrderLunchPnl()
        {
            OpenPanel(pnlOrderViewLunch);

            try
            {
                List<Order> orders = GetOrders();
            }
            catch (Exception e)
            {
                MessageBox.Show("Whoops, the Lunch order page could not be loaded.\n" +
                    "Please try to restart the application or contact your manager\n\n. " + e.Message);
            }





        }
        private void ShowOrderDinnerPnl()
        {
            OpenPanel(pnlOrderViewDinner);
        }
        private void ShowOrderDrinksPnl()
        {
            OpenPanel(pnlOrderViewDrinks);
        }
        //
        //
        //
        //
        // Retreive lists from Database
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
        //
        //
        //
        //
        // Fill + Display ListViews and corresponding items
        private void DisplayTableOrderOverview(List<Order> orders, List<OrderDetail> orderDetails, List<MenuItem> menuItems)
        {
            //Clearing the LV before displaying
            LVOrderOverview.Clear();
            //Filling the LV Column headers
            LVOrderOverview.View = View.Details; //Displays each item on a seperate line
            LVOrderOverview.Columns.Add("no.", 50);
            LVOrderOverview.Columns.Add("name", 200);
            LVOrderOverview.Columns.Add("price", LVOrderOverview.Width - 250);

            decimal totalOrderPrice = 0;
            decimal totalOrderVAT = 0;
            int itemCatagory = 0;
            decimal VATPercentage = 0;
            foreach (Order order in orders)
            {
                itemCatagory = GetItemCatagory(order.MenuItemID, menuItems);
                int itemAmount = GetItemAmount(order.OrderDetailID, orderDetails);
                decimal itemPrice = GetItemPrice(order.MenuItemID, menuItems);

                ListViewItem item = new ListViewItem(itemAmount.ToString());
                item.SubItems.Add(GetItemName(order.MenuItemID, menuItems));
                item.SubItems.Add("€" + itemPrice);

                item.Tag = order;   // link table object to listview item
                LVOrderOverview.Items.Add(item);

                totalOrderPrice += (itemPrice * itemAmount);
                if (itemCatagory >= 0 && itemCatagory <= 8)
                {
                    VATPercentage = 0.06M;
                }
                else
                {
                    VATPercentage = 0.21M;
                }

                totalOrderVAT += ((itemPrice * VATPercentage) * itemAmount);
            }

            TotalOrderPrice.Text = "€" + totalOrderPrice;
            TotalOrderVAT.Text = "€" + totalOrderVAT.ToString(".00");

        }
        private void DisplayLVLunch()
        {
            //Clearing the LV before displaying
            LVSelectedItemsLunch.Items.Clear();
            //Filling the LV Column headers
            LVSelectedItemsLunch.View = View.Details; //Displays each item on a seperate line
            LVSelectedItemsLunch.Columns.Add("no.", 50);
            LVSelectedItemsLunch.Columns.Add("name", LVSelectedItemsLunch.Width - 120);
            LVSelectedItemsLunch.Columns.Add("price", 70);
        }
        //
        //
        //
        //
        // Retreive data from database by ID
        private int GetItemCatagory(int menuItemID, List<MenuItem> menuItems)
        {
            MenuItem menuItem = menuItems.Find(Men => Men.ItemCatagory == menuItemID);
            if (menuItem != null)
            {
                return menuItem.ItemCatagory;
            }
            return 0;
        }
        private int GetItemAmount(int orderDetailID, List<OrderDetail> orderDetails)
        {
            //find the table with the corresponding TableID
            OrderDetail orderDetail = orderDetails.Find(OrD => OrD.OrderDetailID == orderDetailID);
            if (orderDetail != null)
            {
                return orderDetail.ItemQuantity;
            }
            return 0;
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
        private decimal GetItemPrice(int menuItemID, List<MenuItem> menuItems)
        {
            //find the table with the corresponding TableID
            MenuItem menuItem = menuItems.Find(Men => Men.MenuItemID == menuItemID);
            if (menuItem != null)
            {
                return decimal.Parse(menuItem.ItemPrice.ToString(".00"));
            }
            return decimal.Zero;
        }
        //
        //
        //
        //
        // NAVButtons
        private void LunchNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderLunchPnl();

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = false;

            LunchNavButton.BackColor = Color.LightGray;
            DinnerNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }
        private void DinnerNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderDinnerPnl();

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = false;
            LunchNavButton.Enabled = true;

            DinnerNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }
        private void DrinksNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderDrinksPnl();

            DrinksNavButton.Enabled = false;
            DinnerNavButton.Enabled = true;
            LunchNavButton.Enabled = true;

            DrinksNavButton.BackColor = Color.LightGray;
            LunchNavButton.BackColor = Color.LightGreen;
            DinnerNavButton.BackColor = Color.LightGreen;
        }
        //
        //
        //
        //
        // Additional methods for ease of use
        private void OpenPanel(Control panelToOpen)
        {
            foreach (Control control in Controls)
            {
                if (control is Panel panel && panel != panelToOpen && panel != pnlMenu)
                {
                    panel.Hide();
                    panelToOpen.Show();
                }
            }

        } // closes all panels except for the panel in the argument and the default Menu panel
        private void FillLunchPriceTags(List<MenuItem> menuItems)
        {
            foreach (Control control in pnlOrderViewLunch.Controls)
            {
                if (control is Label label && label.Text == "Price")
                {
                    if (int.Parse(label.Tag.ToString()) is int tagMenuItemId)
                    {
                        foreach (MenuItem menuItem in menuItems)
                        {
                            if (tagMenuItemId == menuItem.MenuItemID)
                            {
                                label.Text = "€" + menuItem.ItemPrice.ToString(".00");
                                break;
                            }
                        }

                    }
                }
            }
        }
        private void FillDinnerPriceTags(List<MenuItem> menuItems)
        {
            foreach (Control control in pnlOrderViewDinner.Controls)
            {
                if (control is Label label && label.Text == "Price")
                {
                    if (int.Parse(label.Tag.ToString()) is int tagMenuItemId)
                    {
                        foreach (MenuItem menuItem in menuItems)
                        {
                            if (tagMenuItemId == menuItem.MenuItemID)
                            {
                                label.Text = "€" + menuItem.ItemPrice.ToString(".00");
                                break;
                            }
                        }

                    }
                }
            }
        }
        private void FillDrinksPriceTags(List<MenuItem> menuItems)
        {
            foreach (Control control in pnlOrderViewDrinks.Controls)
            {
                if (control is Label label && label.Text == "Price")
                {
                    if (int.Parse(label.Tag.ToString()) is int tagMenuItemId)
                    {
                        foreach (MenuItem menuItem in menuItems)
                        {
                            if (tagMenuItemId == menuItem.MenuItemID)
                            {
                                label.Text = "€" + menuItem.ItemPrice.ToString(".00");
                                break;
                            }
                        }

                    }
                }
            }
        }
        private void SubscribeButtons()
        {
            LunchItemS1Button.Click += ButtonClickEventHandler;
            LunchItemS2Button.Click += ButtonClickEventHandler;
            LunchItemS3Button.Click += ButtonClickEventHandler;

            LunchItemM1Button.Click += ButtonClickEventHandler;
            LunchItemM2Button.Click += ButtonClickEventHandler;
            LunchItemM3Button.Click += ButtonClickEventHandler;

            LunchItemD1Button.Click += ButtonClickEventHandler;
            LunchItemD2Button.Click += ButtonClickEventHandler;
            LunchItemD3Button.Click += ButtonClickEventHandler;

            DinnerItemS1Button.Click += ButtonClickEventHandler;
            DinnerItemS2Button.Click += ButtonClickEventHandler;
            DinnerItemS3Button.Click += ButtonClickEventHandler;

            DinnerItemE1Button.Click += ButtonClickEventHandler;
            DinnerItemE2Button.Click += ButtonClickEventHandler;

            DinnerItemM1Button.Click += ButtonClickEventHandler;
            DinnerItemM2Button.Click += ButtonClickEventHandler;
            DinnerItemM3Button.Click += ButtonClickEventHandler;

            DinnerItemD1Button.Click += ButtonClickEventHandler;
            DinnerItemD2Button.Click += ButtonClickEventHandler;
            DinnerItemD3Button.Click += ButtonClickEventHandler;

            SpaRedButton.Click += ButtonClickEventHandler;
            SpaGreenButton.Click += ButtonClickEventHandler;
            CocaColaButton.Click += ButtonClickEventHandler;
            CocaColaButton.Click += ButtonClickEventHandler;
            SisiButton.Click += ButtonClickEventHandler;
            TonicButton.Click += ButtonClickEventHandler;
            BitterLemonButton.Click += ButtonClickEventHandler;

            HertogJanButton.Click += ButtonClickEventHandler;
            DuvelButton.Click += ButtonClickEventHandler;
            KriegButton.Click += ButtonClickEventHandler;
            LeffeTripleButton.Click += ButtonClickEventHandler;

            WhiteWineBottleButton.Click += ButtonClickEventHandler;
            WhiteWineGlassButton.Click += ButtonClickEventHandler;
            RedWineBottleButton.Click += ButtonClickEventHandler;
            RedWineBottleButton.Click += ButtonClickEventHandler;
            ChampangeButton.Click += ButtonClickEventHandler;

            YoungJeneverButton.Click += ButtonClickEventHandler;
            WhiskyButton.Click += ButtonClickEventHandler;
            RumButton.Click += ButtonClickEventHandler;
            VieuxButton.Click += ButtonClickEventHandler;
            BerenburgButton.Click += ButtonClickEventHandler;

            CoffeeButton.Click += ButtonClickEventHandler;
            CappuccinoButton.Click += ButtonClickEventHandler;
            EspressoButton.Click += ButtonClickEventHandler;
            TeaButton.Click += ButtonClickEventHandler;
        }
        private void ButtonClickEventHandler(object sender, EventArgs e)
        {
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
            string itemText = clickedButton.Text;
            string labelText = "".Replace("€", "");

            foreach (Control control in pnlOrderViewLunch.Controls)
            {
                if (control is Label label && label.Tag != null && label.Tag.ToString() == clickedButton.Tag.ToString())
                {
                    labelText = label.Text;   
                    break;
                }
            }
            decimal itemPrice = decimal.Parse(labelText.Replace("€",""));

            bool itemExists = false;
            foreach (ListViewItem existingItem in LVSelectedItemsLunch.Items)
            {
                if (existingItem.SubItems[1].Text == itemText)
                {
                    itemExists = true;
                    existingItem.SubItems[0].Text = (int.Parse(existingItem.SubItems[0].Text) + 1).ToString(); // Increment the item amount
                    existingItem.SubItems[2].Text = "€" + (int.Parse(existingItem.SubItems[0].Text) * itemPrice).ToString();
                    break;
                }
            }
            // Add the item to the ListView
            if (!itemExists)
            {
                ListViewItem item = new ListViewItem("1"); // Initial item amount is 1
                item.SubItems.Add(itemText); // Add the item name
                item.SubItems.Add("€" + itemPrice); // Add the item price
                LVSelectedItemsLunch.Items.Add(item);
            }
        }
    }
}
