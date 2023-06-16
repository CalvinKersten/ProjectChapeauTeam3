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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace ChapeauUI
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
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
            ButtonFunctionalityAcrossAllPanels(LVSelectedItemsLunch, LVSelectedItemsDinner, LVSelectedDrinks, menuItems);
            FillLunchPriceTags(menuItems);
            FillDinnerPriceTags(menuItems);
            FillDrinksPriceTags(menuItems);
            LoadAllLVs();
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
        private void LoadAllLVs()
        {
            //Clearing the LVs before displaying
            LVSelectedItemsLunch.Items.Clear();
            LVSelectedItemsDinner.Items.Clear();
            LVSelectedDrinks.Items.Clear();
            //Filling the LVs Column headers
            LVSelectedItemsLunch.View = View.Details; //Displays each item on a seperate line
            LVSelectedItemsLunch.Columns.Add("no.", 50);
            LVSelectedItemsLunch.Columns.Add("name", LVSelectedItemsLunch.Width - 120);
            LVSelectedItemsLunch.Columns.Add("price", 70);

            LVSelectedItemsDinner.View = View.Details; //Displays each item on a seperate line
            LVSelectedItemsDinner.Columns.Add("no.", 50);
            LVSelectedItemsDinner.Columns.Add("name", LVSelectedItemsDinner.Width - 120);
            LVSelectedItemsDinner.Columns.Add("price", 70);

            LVSelectedDrinks.View = View.Details; //Displays each item on a seperate line
            LVSelectedDrinks.Columns.Add("no.", 50);
            LVSelectedDrinks.Columns.Add("name", LVSelectedDrinks.Width - 120);
            LVSelectedDrinks.Columns.Add("price", 70);
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
        private void ButtonFunctionalityAcrossAllPanels(System.Windows.Forms.ListView listViewLunch, System.Windows.Forms.ListView listViewDinner, System.Windows.Forms.ListView listViewDrinks, List<MenuItem> menuItems)
        {
            void SubscribeButtons()
            {
                LunchItemS1Button.Click += ItemButtonClickEventHandler;
                LunchItemS2Button.Click += ItemButtonClickEventHandler;
                LunchItemS3Button.Click += ItemButtonClickEventHandler;

                LunchItemM1Button.Click += ItemButtonClickEventHandler;
                LunchItemM2Button.Click += ItemButtonClickEventHandler;
                LunchItemM3Button.Click += ItemButtonClickEventHandler;

                LunchItemD1Button.Click += ItemButtonClickEventHandler;
                LunchItemD2Button.Click += ItemButtonClickEventHandler;
                LunchItemD3Button.Click += ItemButtonClickEventHandler;

                DinnerItemS1Button.Click += ItemButtonClickEventHandler;
                DinnerItemS2Button.Click += ItemButtonClickEventHandler;
                DinnerItemS3Button.Click += ItemButtonClickEventHandler;

                DinnerItemE1Button.Click += ItemButtonClickEventHandler;
                DinnerItemE2Button.Click += ItemButtonClickEventHandler;

                DinnerItemM1Button.Click += ItemButtonClickEventHandler;
                DinnerItemM2Button.Click += ItemButtonClickEventHandler;
                DinnerItemM3Button.Click += ItemButtonClickEventHandler;

                DinnerItemD1Button.Click += ItemButtonClickEventHandler;
                DinnerItemD2Button.Click += ItemButtonClickEventHandler;
                DinnerItemD3Button.Click += ItemButtonClickEventHandler;

                SpaRedButton.Click += ItemButtonClickEventHandler;
                SpaGreenButton.Click += ItemButtonClickEventHandler;
                CocaColaButton.Click += ItemButtonClickEventHandler;
                CocaColaButton.Click += ItemButtonClickEventHandler;
                SisiButton.Click += ItemButtonClickEventHandler;
                TonicButton.Click += ItemButtonClickEventHandler;
                BitterLemonButton.Click += ItemButtonClickEventHandler;

                HertogJanButton.Click += ItemButtonClickEventHandler;
                DuvelButton.Click += ItemButtonClickEventHandler;
                KriegButton.Click += ItemButtonClickEventHandler;
                LeffeTripleButton.Click += ItemButtonClickEventHandler;

                WhiteWineBottleButton.Click += ItemButtonClickEventHandler;
                WhiteWineGlassButton.Click += ItemButtonClickEventHandler;
                RedWineBottleButton.Click += ItemButtonClickEventHandler;
                RedWineBottleButton.Click += ItemButtonClickEventHandler;
                ChampangeButton.Click += ItemButtonClickEventHandler;

                YoungJeneverButton.Click += ItemButtonClickEventHandler;
                WhiskyButton.Click += ItemButtonClickEventHandler;
                RumButton.Click += ItemButtonClickEventHandler;
                VieuxButton.Click += ItemButtonClickEventHandler;
                BerenburgButton.Click += ItemButtonClickEventHandler;

                CoffeeButton.Click += ItemButtonClickEventHandler;
                CappuccinoButton.Click += ItemButtonClickEventHandler;
                EspressoButton.Click += ItemButtonClickEventHandler;
                TeaButton.Click += ItemButtonClickEventHandler;

                AddButtonLunch.Click += AddButtonClickEvenHandler;
                AddButtonDinner.Click += AddButtonClickEvenHandler;
                AddButtonDrinks.Click += AddButtonClickEvenHandler;
            }
            SubscribeButtons();

            void ItemButtonClickEventHandler(object sender, EventArgs e)
            {
                System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender;
                string itemName = clickedButton.Text;
                int itemID = int.Parse(clickedButton.Tag.ToString());
                decimal itemPrice = GetItemPrice(itemID, menuItems);
                int itemQuantity = 1;

                List<System.Windows.Forms.ListView> listViewCollection = new List<System.Windows.Forms.ListView>
                {
                    listViewLunch,
                    listViewDinner,
                    listViewDrinks
                };

                bool itemExists = false;
                foreach (System.Windows.Forms.ListView listView in listViewCollection)
                {
                    foreach (ListViewItem item in listView.Items)
                    {
                        if (item.SubItems[1].Text == itemName)
                        {
                            itemExists = true;
                            itemQuantity = int.Parse(item.SubItems[0].Text); // Get current item quantity
                            decimal currentPrice = decimal.Parse(item.SubItems[2].Text.Replace("€", "")); // Get current item price 

                            item.SubItems[0].Text = (itemQuantity + 1).ToString();
                            decimal totalPrice = currentPrice + itemPrice;
                            item.SubItems[2].Text = "€" + totalPrice.ToString();

                            break;
                        }
                    }
                }
                if (!itemExists)
                {
                    // Add the item to all ListView
                    ListViewItem LVLunch = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                    LVLunch.SubItems.Add(itemName); // Add the item name
                    LVLunch.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                    listViewLunch.Items.Add(LVLunch);

                    ListViewItem LVDinner = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                    LVDinner.SubItems.Add(itemName); // Add the item name
                    LVDinner.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                    listViewDinner.Items.Add(LVDinner);

                    ListViewItem LVDrinks = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                    LVDrinks.SubItems.Add(itemName); // Add the item name
                    LVDrinks.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                    listViewDrinks.Items.Add(LVDrinks);
                }
            }
            void AddButtonClickEvenHandler(object Sender, EventArgs e)
            {

            }
        }
       
    }
}
