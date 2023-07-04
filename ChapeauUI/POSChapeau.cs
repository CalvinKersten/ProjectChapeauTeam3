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
    public partial class POSChapeau : Form
    {
        public POSChapeau()
        {
            InitializeComponent();
            LoadItems(); // enables the button functionality, fills item price and name tags and loads the listviews
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
            /* ButtonFunctionalityAcrossAllPanels(LVSelectedItemsLunch, LVSelectedItemsDinner, LVSelectedDrinks, menuItems);*/ // Calls the method responsible for enabeling the buttons and variables stored in the button.Text
            SubscribeButtons();
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
                /*List<Order> orders = GetOrders();*/
                List<Order> orderForTable= GetOrderForTable(1); // 6 is hardcoded because we are missing the TableOverview part!!!
                List<OrderDetail> orderDetails = GetOrderDetails();
                List<MenuItem> menuItems = GetMenuItems();

                DisplayTableOrderOverview(orderForTable, orderDetails, menuItems);
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
        } // retreives a list of all menu items
        public int GetTableID(int orderID)
        {
            OrderService orderService = new OrderService();
            int tableID = orderService.GetTableID(orderID);
            return tableID;
        } // retreives the table ID for the particulair table in the order (using the orderID)
        public int GetTableNumber(int tableID)
        {
            TableService tableService = new TableService();
            int tableNumber = tableService.GetTableNumber(tableID);
            return tableNumber;
        } // retreives the table number for the particulair table (using the tableID)
        public List<Order> GetOrderForTable(int tableID)
        {
            OrderService orderService = new OrderService();
            List<Order> ordersForTable = orderService.GetOrderForTable(tableID);
            return ordersForTable;
        }
        public List<OrderDetail> GetOrderDetails()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            List<OrderDetail> orderDetail = orderDetailService.GetOrderDetails();
            return orderDetail;
        } // retreives a list of all order details
        public decimal GetItemPrice(int menuItemID)
        {
            MenuItemService menuItemService = new MenuItemService();
            decimal itemPrice = menuItemService.GetOrderedItemPrice(menuItemID);
            return itemPrice;
        } // retreives the item price for a particulair item (using the itemID)
        public string GetItemName(int menuItemID)
        {
            MenuItemService menuItemService = new MenuItemService();
            string itemName = menuItemService.GetItemName(menuItemID);
            return itemName;
        } // retreives the item name for a particulair item (using the itemID)
        public int GetItemAmount(int menuItemID)
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            int itemAmount = orderDetailService.GetItemAmount(menuItemID);
            return itemAmount;
        } // retreives the ordered amount for a particulair item (using the itemID)
        public int GetItemCatagory(int menuItemID) 
        {
            MenuItemService menuItemService = new MenuItemService();
            int itemCatagory = menuItemService.GetItemCatagory(menuItemID);
            return itemCatagory;
        } // retreives the item catagory for a particulair item (using the itemID)
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

            int itemCatagory = 0;
            foreach (Order orderForTable in orders)
            {
                // Retreives information from database to put in the listview
                itemCatagory = GetItemCatagory(orderForTable.MenuItemID); // Should be in CalculateVAT
                int itemAmount = GetItemAmount(orderForTable.MenuItemID); // Should be in CalculateTotalPrice
                decimal itemPrice = GetItemPrice(orderForTable.MenuItemID); // Should be in CalculateTotalPrice

                ListViewItem item = new ListViewItem(itemAmount.ToString());
                item.SubItems.Add(GetItemName(orderForTable.MenuItemID));
                item.SubItems.Add("€" + itemPrice.ToString("0.00"));

                LVOrderOverview.Items.Add(item);   
            }
            DisplayTotalPrice(CalculateTotalPrice(orders));
            DisplayTotalVAT(CalculateVAT(orders));

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
        } // Used for filling the ItemButtons and price tags with data
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
        } // Used for inserting an enter into the button names
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
        } // exists the comment function
        private void AddButtonComment_Click(object sender, EventArgs e)
        {
            string comment = CommentBox.Text;

            if (LVSelectedItemsLunch.SelectedItems.Count > 0)
            {
                LVSelectedItemsLunch.SelectedItems[0].SubItems[3].Text = comment;
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
        private void SubscribeButtons()
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
        private void ItemButtonClickEventHandler(object sender, EventArgs e)
        {
            Order order = new Order();
            System.Windows.Forms.Button clickedButton = (System.Windows.Forms.Button)sender; //Doing stuff from the UI, shouldn't be done that way.
            string itemName = clickedButton.Text;
            int itemID = int.Parse(clickedButton.Tag.ToString());
            decimal itemPrice = GetItemPrice(itemID);
            int itemQuantity = 1;
            string comment = "";

            List<System.Windows.Forms.ListView> listViewCollection = new List<System.Windows.Forms.ListView>
            {
                    LVSelectedItemsLunch,
                    LVSelectedItemsDinner,
                    LVSelectedDrinks
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
                LVLunch.SubItems.Add("");
                LVSelectedItemsLunch.Items.Add(LVLunch);

                ListViewItem LVDinner = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                LVDinner.SubItems.Add(itemName); // Add the item name
                LVDinner.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                LVLunch.SubItems.Add("");
                LVSelectedItemsDinner.Items.Add(LVDinner);

                ListViewItem LVDrinks = new ListViewItem(itemQuantity.ToString()); // Add the item quantity
                LVDrinks.SubItems.Add(itemName); // Add the item name
                LVDrinks.SubItems.Add("€" + itemPrice.ToString()); // Add the item price
                LVLunch.SubItems.Add("");
                LVSelectedDrinks.Items.Add(LVDrinks);
            }
        } // adds the selected item to all listviews (lunch, dinner and drinks)
        private decimal CalculateVAT(List<Order> orders)
        {
            // VAT = (6% of ItemPrice) * ItemAmount
            // VAT = 21% of ItemPrice) * ItemAmount
            decimal totalOrderVAT = 0;
            decimal totalPrice = 0;
            foreach (Order orderForTable in orders)
            {
                // Retreives information from database to put in the listview
                int itemCatagory = GetItemCatagory(orderForTable.MenuItemID);
                int itemAmount = GetItemAmount(orderForTable.MenuItemID);
                decimal itemPrice = GetItemPrice(orderForTable.MenuItemID);

                totalPrice += (itemPrice * itemAmount);
                decimal VATPercentage;
                if (itemCatagory == 1 || itemCatagory == 2)
                {
                    VATPercentage = 0.06m;
                }
                else
                {
                    VATPercentage = 0.21m;
                }
                totalOrderVAT += totalPrice * VATPercentage;
            }
            return totalOrderVAT;
        } // Calculates the total order VAT price
        private decimal CalculateTotalPrice(List<Order> orders)
        {
            decimal totalOrderPrice = 0;
            foreach (Order orderForTable in orders) 
            {
                // Retreives information from database to put in the listview
                int itemAmount = GetItemAmount(orderForTable.MenuItemID);
                decimal itemPrice = GetItemPrice(orderForTable.MenuItemID);

                totalOrderPrice += (itemPrice * itemAmount);
            }
            return totalOrderPrice;
        } // Calculates the total order price
        private void DisplayTotalVAT(decimal totalOrderVAT)
        {
            TotalOrderVAT.Text = totalOrderVAT.ToString("0.00");
        }
        private void DisplayTotalPrice(decimal totalOrderPrice)
        {
            TotalOrderPrice.Text = totalOrderPrice.ToString("0.00");
        }
        private void AddCommentButtonClickEventHandler(object Sender, EventArgs e)
        {
            ShowCommentPnl();
        } // Opens the comment Panel
        private void DeleteButtonClickEventHandler(object Sender, EventArgs e)
        {
            Delete();
        } // Deletes an Item from the Listview
        private void AddButtonClickEvenHandler(object Sender, EventArgs e)
        {
            AddOrder();
        } // Adds the order to the database
        private void Delete()
        {
            List<System.Windows.Forms.ListView> listViewCollection = new List<System.Windows.Forms.ListView>
            {
               LVSelectedItemsLunch,
               LVSelectedItemsDinner,
               LVSelectedDrinks
            };

            // Create a list to store the items to remove
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();

            // Iterate through all ListView controls
            foreach (System.Windows.Forms.ListView listView in listViewCollection)
            {
                // Iterate through selected items in the current ListView control
                foreach (ListViewItem selectedItem in listView.SelectedItems)
                {
                    int amount = int.Parse(selectedItem.SubItems[0].Text);

                    if (amount > 1)
                    {
                        // Decrement the amount by 1
                        amount--;
                        selectedItem.SubItems[0].Text = amount.ToString();
                    }
                    else
                    {
                        // Add the item to the list of items to remove
                        itemsToRemove.Add(selectedItem);
                    }
                }
            }
            // Remove the selected items from all ListView controls
            foreach (System.Windows.Forms.ListView listView in listViewCollection)
            {
                foreach (ListViewItem itemToRemove in itemsToRemove)
                {
                    listView.Items.Remove(itemToRemove);
                }
            }

        }
        private void AddOrder()
        {
            OrderDetailService orderDetailService = new OrderDetailService();
            OrderDetail orderDetail = new OrderDetail();
            OrderService orderService = new OrderService();
            Order order = new Order();

            try
            {
                orderDetailService.AddOrderDetail(orderDetail);
                orderService.AddOrder(order);
            }
            catch
            {

            }
        }
    }
}
