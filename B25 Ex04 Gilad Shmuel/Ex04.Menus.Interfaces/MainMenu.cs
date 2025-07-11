using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex04.Menus.Interfaces
{
    public class MainMenu
    {
        private readonly string r_MenuTitle;
        private bool m_IsRootMenu;
        private readonly List<IMenuItem> r_MenuItems;

        public MainMenu(string i_MenuTitle, bool i_IsRootMenu = true, List<IMenuItem> i_MenuItems = null)
        {
            r_MenuTitle = i_MenuTitle;
            m_IsRootMenu = i_IsRootMenu;
            if (i_MenuItems != null)
            {
                r_MenuItems = i_MenuItems;
            }
            else
            {
                r_MenuItems = new List<IMenuItem>();
            }
        }

        public void AddMenuItem(IMenuItem i_Option)
        {
            r_MenuItems.Add(i_Option);
        }

        public void Show()
        {
            string exitText = m_IsRootMenu ? "Exit" : "Back";
            int userInput;

            while (true)
            {
                Console.WriteLine("** " + r_MenuTitle + " **");
                Console.WriteLine("------------------------");
                int optionCounter = 1;
                foreach (IMenuItem option in r_MenuItems)
                {
                    Console.WriteLine("{0}. {1}", optionCounter, option.Title);
                    optionCounter++;
                }

                Console.WriteLine("0. {0}", exitText);
                Console.WriteLine("Please enter your choice (1-{0} or 0 {1}): ", r_MenuItems.Count, m_IsRootMenu ? "to exit" : "to go back");
                if (int.TryParse(Console.ReadLine(), out userInput))
                {
                    if (userInput >= 1 && userInput <= r_MenuItems.Count)
                    {
                        Console.Clear();
                        r_MenuItems[userInput - 1].Perform();
                    }
                    else if (userInput == 0)
                    {
                        Console.Clear();
                        if (m_IsRootMenu)
                        {
                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Please enter a valid option");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Please enter a number");
                    Console.WriteLine();
                }
            }
        }
    }
}
