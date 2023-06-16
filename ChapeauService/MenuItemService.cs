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

        public MenuItem GetMenuItemByID(int id) {
            return MenuItemdb.GetMenuItemByID(id);
        }
    }
}
