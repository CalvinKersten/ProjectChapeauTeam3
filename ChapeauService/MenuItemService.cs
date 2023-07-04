using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauService
{
    public class MenuItemService
    {
        private MenuItemDao MenuItemdb;

        public MenuItemService()
        {
            MenuItemdb = new MenuItemDao();
        }
        public List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = MenuItemdb.GetAllMenuItems();
            return menuItems;
        }
        public decimal GetOrderedItemPrice(int menuItemID)
        {
            decimal itemPrice = MenuItemdb.GetItemPrice(menuItemID);
            return itemPrice;
        }
        public string GetItemName(int menuItemID) 
        {
            string itemName = MenuItemdb.GetItemName(menuItemID);
            return itemName;
        }
        public int GetItemCatagory(int menuItemID)
        {
            int itemCatagory = MenuItemdb.GetItemCatagory(menuItemID);
            return itemCatagory;
        }
        public MenuItem GetMenuItemByID(int id)
        {
            return MenuItemdb.GetMenuItemByID(id);
        }
    }
    
}
