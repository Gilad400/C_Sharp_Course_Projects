using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MenuItem : IMenuItem
    {
        private readonly string r_MenuTitle;
        private readonly List<IMenuItem> r_MenuItems;

        public MenuItem(string i_MenuTitle)
        {
            r_MenuTitle = i_MenuTitle;
            r_MenuItems = new List<IMenuItem>();
        }

        string IMenuItem.Title
        {
            get { return r_MenuTitle; }
        }

        public void AddInnerMenuItem(IMenuItem i_Option)
        {
            r_MenuItems.Add(i_Option);
        }

        void IMenuItem.Perform()
        {
            if (r_MenuItems.Count > 0)
            {
                const bool v_IsRootMenu = true;
                MainMenu innerMenu = new MainMenu(r_MenuTitle, !v_IsRootMenu, r_MenuItems);

                innerMenu.Show();
            }
        }   
    }
}
