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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Microsoft.VisualBasic;

namespace ChapeauUI
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadItems(); // enables the button functionality, fills item price and name tags and loads the listviews
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
        // Events while Loading
        private void LoadItems()
        {
            List<MenuItem> menuItems = GetMenuItems(); //Retreives the MenuItems from database and stores it in menuItems
            ButtonFunctionalityAcrossAllPanels(LVSelectedItemsLunch, LVSelectedItemsDinner, LVSelectedDrinks, menuItems); // Calls the method responsible for enabeling the buttons and variables stored in the button.Text
            FillItemPriceAndName(menuItems, pnlOrderViewLunch); // fills the price and name tags for pnlOrderViewLunch
            FillItemPriceAndName(menuItems, pnlOrderViewDinner); // fills the price and name tags for pnlOrderViewDinner
            FillItemPriceAndName(menuItems, pnlOrderViewDrinks); // fills the price and name tags for pnlOrderViewDrinks
            LoadAllLVs(); // Sets all listView headers and enables full row select
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

        } // open the order overview panel
        private void ShowOrderLunchPnl()
        {
            OpenPanel(pnlOrderViewLunch);
        } // opens the order lunch panel
        private void ShowOrderDinnerPnl()
        {
            OpenPanel(pnlOrderViewDinner);
        } // opens the order dinner panel
        private void ShowOrderDrinksPnl()
        {
            OpenPanel(pnlOrderViewDrinks);
        } // opens the Order drinks panel
        private void ShowCommentPnl()
        {
            OpenPanel(pnlAddComment);
            pnlMenu.Hide();

            
        } // opens the comment panel
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
            LVOrderOverview.Columns.Add("Comment");

            int itemCatagory = 0;
            foreach (Order order in orders)
            {
                // Retreives information from database to put in the listview
                itemCatagory = GetItemCatagory(order.MenuItemID, menuItems);
                int itemAmount = GetItemAmount(order.OrderDetailID, orderDetails);
                decimal itemPrice = GetItemPrice(order.MenuItemID, menuItems);

                ListViewItem item = new ListViewItem(itemAmount.ToString());
                item.SubItems.Add(GetItemName(order.MenuItemID, menuItems));
                item.SubItems.Add("€" + itemPrice);

                LVOrderOverview.Items.Add(item);   
            }

            TotalOrderPrice.Text = "€" + CalculateTotalPrice(orders, orderDetails, menuItems).ToString("0.00");
            TotalOrderVAT.Text = "€" + CalculateVAT(orders, orderDetails, menuItems).ToString("0.00");

        } // Sets listview header for Table order overview
        private void LoadAllLVs()
        {
            //Clearing the LVs before displaying
            LVSelectedItemsLunch.Items.Clear();
            LVSelectedItemsDinner.Items.Clear();
            LVSelectedDrinks.Items.Clear();

            //Filling the LVs Column headers
            LVSelectedItemsLunch.View = View.Details; //Displays each item on a seperate line
            LVSelectedItemsLunch.Columns.Add("no.", 50);
            LVSelectedItemsLunch.Columns.Add("name", LVSelectedItemsLunch.Width - 220);
            LVSelectedItemsLunch.Columns.Add("price", 70);
            LVSelectedItemsLunch.Columns.Add("Comment", 100);
            LVSelectedItemsLunch.FullRowSelect = true;

            LVSelectedItemsDinner.View = View.Details; //Displays each item on a seperate line
            LVSelectedItemsDinner.Columns.Add("no.", 50);
            LVSelectedItemsDinner.Columns.Add("name", LVSelectedItemsDinner.Width - 220);
            LVSelectedItemsDinner.Columns.Add("price", 70);
            LVSelectedItemsDinner.Columns.Add("Comment", 100);
            LVSelectedItemsDinner.FullRowSelect = true;

            LVSelectedDrinks.View = View.Details; //Displays each item on a seperate line
            LVSelectedDrinks.Columns.Add("no.", 50);
            LVSelectedDrinks.Columns.Add("name", LVSelectedDrinks.Width - 220);
            LVSelectedDrinks.Columns.Add("price", 70);
            LVSelectedDrinks.Columns.Add("Comment", 100);
            LVSelectedDrinks.FullRowSelect = true;
        } // Sets all listView headers and enables full row select
        //
        //
        //
        //
        // Retreive data from database by ID
        private int GetItemCatagory(int menuItemID, List<MenuItem> menuItems)
        {
            MenuItem menuItem = menuItems.Find(Men => Men.ItemCatagory == menuItemID); // searches the menuItems list to find the corresponding item catagory for the given menuitemID
            if (menuItem != null)
            {
                return menuItem.ItemCatagory; // return the Item catagory
            }
            return 0; // return 0 as default if no matching items are found
        } // Takes 2 input parameters to find the item catagory
        private int GetItemAmount(int orderDetailID, List<OrderDetail> orderDetails)
        {
            //find the table with the corresponding TableID
            OrderDetail orderDetail = orderDetails.Find(OrD => OrD.OrderDetailID == orderDetailID);
            if (orderDetail != null)
            {
                return orderDetail.ItemQuantity;
            }
            return 0;
        } // Takes 2 input parameters to find the item amount
        private string GetItemName(int menuItemID, List<MenuItem> menuItems)
        {
            //find the table with the corresponding TableID
            MenuItem menuItem = menuItems.Find(Men => Men.MenuItemID == menuItemID);
            if (menuItem != null)
            {
                return menuItem.ItemName.ToString();
            }
            return string.Empty;
        } // Takes 2 input parameters to find the item name
        private decimal GetItemPrice(int menuItemID, List<MenuItem> menuItems)
        {
            //find the table with the corresponding TableID
            MenuItem menuItem = menuItems.Find(Men => Men.MenuItemID == menuItemID);
            if (menuItem != null)
            {
                return decimal.Parse(menuItem.ItemPrice.ToString(".00"));
            }
            return decimal.Zero;
        } // Takes 2 input parameters to find the item price
        //
        //
        //
        //
        // NAVButtons controls
        private void LunchNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderLunchPnl(); // opens the Lunch panel

            LunchNavButton.Enabled = false; // becomes non interactive
            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = true;

            LunchNavButton.BackColor = Color.LightGray; // becomes grey to indicate it is a non interactive
            DinnerNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGreen;
        }
        private void DinnerNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderDinnerPnl(); // opens the Dinner panel

            DrinksNavButton.Enabled = true;
            DinnerNavButton.Enabled = false; // becomes non interactive
            LunchNavButton.Enabled = true;

            LunchNavButton.BackColor = Color.LightGreen;
            DinnerNavButton.BackColor = Color.LightGray; // becomes grey to indicate it is non interactive
            DrinksNavButton.BackColor = Color.LightGreen;
        }
        private void DrinksNavButton_Click(object sender, EventArgs e)
        {
            ShowOrderDrinksPnl();

            LunchNavButton.Enabled = true;
            DinnerNavButton.Enabled = true;
            DrinksNavButton.Enabled = false; // becomes non interactive

            LunchNavButton.BackColor = Color.LightGreen;
            DinnerNavButton.BackColor = Color.LightGreen;
            DrinksNavButton.BackColor = Color.LightGray; // becomes grey to indicate it is non interactive
        }
        //
        //
        //
        //
        // Filling item name and price
        private void FillItemPriceAndName(List<MenuItem> menuItems, Panel panel) 
        {
            foreach (Control control in panel.Controls)
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
                } // Fill the PriceTags and NameTags with data from the database
                if (control is System.Windows.Forms.Button button && button.Text == "Name")
                {
                    if (int.Parse(button.Tag.ToString()) is int tagMenuItemId)
                    {
                        foreach (MenuItem menuItem in menuItems)
                        {
                            if (tagMenuItemId == menuItem.MenuItemID)
                            {
                                string itemName = menuItem.ItemName.ToString();
                                // Insert a line break after 30 characters
                                string formattedName = InsertLineBreaks(itemName, 30);
                                button.Text = formattedName;
                                break;
                            }
                        }

                    }
                }
            }
        }
        private string InsertLineBreaks(string text, int charactersPerLine)
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;

            foreach (char c in text)
            {
                sb.Append(c);
                count++;

                if (count % charactersPerLine == 0)
                    sb.Append("\n");
            }
            return sb.ToString();
        }
        //
        //
        //
        //
        // Adding comments
        private void CommentBox_Click(object sender, EventArgs e)
        {
            CommentBox.Text = "";
        } // removes text in commentbox when starting to type
        private void CommentBackButton_Click(object sender, EventArgs e)
        {
            OpenPanel(pnlMenu);
            ShowOrderLunchPnl();
            /* if (previousPanel == pnlOrderViewLunch)
             {

             }
             else if (previousPanel == pnlOrderViewDinner)
             {

             }
             else if (previousPanel == pnlOrderViewDrinks)
             {
                 ShowOrderDrinksPnl();
             }
             */
        } // exists the comment function
        private void AddButtonComment_Click(object sender, EventArgs e)
        {
            string comment = CommentBox.Text;

            if (LVSelectedItemsLunch.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = LVSelectedItemsLunch.SelectedItems[0];
                selectedItem.SubItems[3].Text = comment;
            }

        } // SHOULD add a comment to the item in the listview
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
        private void ButtonFunctionalityAcrossAllPanels(System.Windows.Forms.ListView listViewLunch, System.Windows.Forms.ListView listViewDinner, System.Windows.Forms.ListView listViewDrinks, List<MenuItem> menuItems)
        {
            void SubscribeButtons()
            {
                // Create an array of all the item button controls
                System.Windows.Forms.Button[] buttons =
                {
                     LunchItemS1Button, LunchItemS2Button, LunchItemS3Button,
                     LunchItemM1Button, LunchItemM2Button, LunchItemM3Button,
                     LunchItemD1Button, LunchItemD2Button, LunchItemD3Button,
                     DinnerItemS1Button, DinnerItemS2Button, DinnerItemS3Button,
                     DinnerItemE1Button, DinnerItemE2Button,
                     DinnerItemM1Button, DinnerItemM2Button, DinnerItemM3Button,
                     DinnerItemD1Button, DinnerItemD2Button, DinnerItemD3Button,
                     SpaRedButton, SpaGreenButton, CocaColaButton,
                     SisiButton, TonicButton, BitterLemonButton,
                     HertogJanButton, DuvelButton, KriegButton, LeffeTripleButton,
                     WhiteWineBottleButton, WhiteWineGlassButton, RedWineBottleButton,
                     ChampangeButton, YoungJeneverButton, WhiskyButton, RumButton,
                     VieuxButton, BerenburgButton, CoffeeButton, CappuccinoButton,
                     EspressoButton, TeaButton
                };

                // Subscribe the event handler to each button in the array
                foreach (System.Windows.Forms.Button button in buttons)
                {
                    button.Click += ItemButtonClickEventHandler;
                }

                // Subscribe the other event handlers
                AddButtonLunch.Click += AddButtonClickEvenHandler;
                AddButtonDinner.Click += AddButtonClickEvenHandler;
                AddButtonDrinks.Click += AddButtonClickEvenHandler;

                DeleteButtonLunch.Click += DeleteButtonClickEventHandler;
                DeleteButtonDinner.Click += DeleteButtonClickEventHandler;
                RemoveButtonDrinks.Click += DeleteButtonClickEventHandler;

                CommentButtonLunch.Click += AddCommentButtonClickEventHandler;
                CommentButtonDinner.Click += AddCommentButtonClickEventHandler;
                CommentButtonDrinks.Click += AddCommentButtonClickEventHandler;
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
                    LVSelectedItemsLunch.Items.Add(LVLunch);

                    ListViewItem LVDinner = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                    LVDinner.SubItems.Add(itemName); // Add the item name
                    LVDinner.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                    LVSelectedItemsDinner.Items.Add(LVDinner);

                    ListViewItem LVDrinks = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                    LVDrinks.SubItems.Add(itemName); // Add the item name
                    LVDrinks.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                    LVSelectedDrinks.Items.Add(LVDrinks);
                }
            } // adds the selected item to all listviews (lunch, dinner and drinks)


        } // Creates an array of all item buttons, subscribes them to the corresponding event handler.
        private decimal CalculateVAT(List<Order> orders, List<OrderDetail> orderDetails, List<MenuItem> menuItems)
        {
            // VAT = (6% of ItemPrice) * ItemAmount
            // VAT = 21% of ItemPrice) * ItemAmount
            decimal totalOrderVAT = 0;
            decimal orderVAT = 0;
            foreach (Order order in orders)
            {
                // Retreives information from database to put in the listview
                int itemCatagory = GetItemCatagory(order.MenuItemID, menuItems);
                int itemAmount = GetItemAmount(order.OrderDetailID, orderDetails);
                decimal itemPrice = GetItemPrice(order.MenuItemID, menuItems);

                orderVAT += (itemPrice * itemAmount);
                decimal VATPercentage;
                if (itemCatagory == 1)
                {
                    VATPercentage = 0.06m;
                }
                else
                {
                    VATPercentage = 0.21m;
                }
                totalOrderVAT += (itemPrice * itemAmount) * VATPercentage;
            }
            return totalOrderVAT;
        } // Calculates the total order VAT price
        private decimal CalculateTotalPrice(List<Order> orders, List<OrderDetail> orderDetails, List<MenuItem> menuItems)
        {
            decimal totalOrderPrice = 0;
            foreach (Order order in orders)
            {
                // Retreives information from database to put in the listview
                int itemAmount = GetItemAmount(order.OrderDetailID, orderDetails);
                decimal itemPrice = GetItemPrice(order.MenuItemID, menuItems);

                totalOrderPrice += itemPrice * itemAmount;
            }
            return totalOrderPrice;
        } // Calculates the total order price
        private void AddCommentButtonClickEventHandler(object Sender, EventArgs e)
        {
            ShowCommentPnl();
        } // Opens the comment Panel
        private void DeleteButtonClickEventHandler(object Sender, EventArgs e)
        {
            List<System.Windows.Forms.ListView> listViewCollection = new List<System.Windows.Forms.ListView>
                {
                    LVSelectedItemsLunch,
                    LVSelectedItemsDinner,
                    LVSelectedDrinks
                };

            List<ListViewItem> selectedItems = new List<ListViewItem>();

            // Collect the selected items from all ListView controls
            foreach (System.Windows.Forms.ListView listView in listViewCollection)
            {
                foreach (ListViewItem selectedItem in listView.SelectedItems)
                {
                    selectedItems.Add(selectedItem);
                }
            }

            // Remove the selected items from all ListView controls

            foreach (ListViewItem selectedItem in selectedItems)
            {
                foreach (System.Windows.Forms.ListView listView in listViewCollection)
                {
                    listView.Items.Remove(selectedItem);
                }
            }
        } // Deletes an Item from the Listview
        private void AddButtonClickEvenHandler(object Sender, EventArgs e)
        {
            string conString = "Data Source=somerenit1bt2.database.windows.net;Initial Catalog=Project_SomerenIT1BT2;User=SomerenTeam2;Password=ProjectT3Team2";
            string query = "INSERT INTO Order_Detail (Item_Quantity, Order_Status, Comment, Menu_ItemID) VALUES (@ItemQuantity, @Order_Status, @Comment, @MenuItemID)";
            SqlConnection con = new SqlConnection(conString);
            
            string OrderStatus = "";
            string Comment = "";
            int ItemQuantity = 0;

            foreach (ListViewItem item in LVSelectedItemsLunch.Items)
            {
                OrderStatus = "Running";
                Comment = "";
                ItemQuantity = int.Parse(item.SubItems[0].Text);
            }
            try
            {
                con.Open();

                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@ItemQuantity", ItemQuantity);
                command.Parameters.AddWithValue("@Order_Status", OrderStatus);
                command.Parameters.AddWithValue("@Comment", Comment);
                /*command.Parameters.AddWithValue("@MenuItemID", );*/
                command.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            LoadAllLVs(); // Reload all LV's = remove all Items from the LV's
            ShowOrderOverviewPnl(); // Show full order on OrderOVerviewpnl
        } // Adds the order to the database
        
    }
}
