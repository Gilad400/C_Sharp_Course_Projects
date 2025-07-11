using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Events
{
    public class MenuItem
    {
        private readonly string r_MenuTitle;
        private readonly List<MenuItem> r_MenuItems;
        public event Action PerformAction;

        public MenuItem(string i_MenuTitle)
        {
            r_MenuTitle = i_MenuTitle;
            r_MenuItems = new List<MenuItem>();
        }

        public string Title
        {
            get { return r_MenuTitle; }
        }

        public void AddInnerMenuItem(MenuItem i_Option)
        {
            r_MenuItems.Add(i_Option);
        }

        public void Perform()
        {
            if (r_MenuItems.Count > 0)
            {
                showInnerMenu();
            }
            else
            {
                OnPerformAction();
            }
        }

        protected virtual void OnPerformAction()
        {
            PerformAction?.Invoke();
        }

        private void showInnerMenu()
        {
            const bool v_IsRootMenu = true;
            MainMenu innerMenu = new MainMenu(r_MenuTitle, !v_IsRootMenu, r_MenuItems);

            innerMenu.Show();
        }
    }
}
