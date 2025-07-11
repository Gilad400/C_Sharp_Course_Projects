using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;

namespace Ex04.Menus.Test
{
    internal class MenuCreator
    {
        private readonly Interfaces.MainMenu r_InterfaceBasedMainMenu;
        private readonly Events.MainMenu r_EventsBasedMainMenu;

        public MenuCreator()
        {
            r_InterfaceBasedMainMenu = new Interfaces.MainMenu("Interface Main Menu");
            r_EventsBasedMainMenu = new Events.MainMenu("Delegates Main Menu");

            setupInterfaceBasedMenu();
            setupEventsBasedMenu();
        }

        private void setupInterfaceBasedMenu()
        {
            Interfaces.MenuItem lettersAndVersionOption = new Interfaces.MenuItem("Letters and Version");
            Interfaces.MenuItem dateTimeOption = new Interfaces.MenuItem("Show Current Date/Time");

            lettersAndVersionOption.AddInnerMenuItem(new ShowVersion());
            lettersAndVersionOption.AddInnerMenuItem(new CountLowercaseLetters());
            dateTimeOption.AddInnerMenuItem(new ShowCurrentDate());
            dateTimeOption.AddInnerMenuItem(new ShowCurrentTime());
            r_InterfaceBasedMainMenu.AddMenuItem(lettersAndVersionOption);
            r_InterfaceBasedMainMenu.AddMenuItem(dateTimeOption);
        }
        private void setupEventsBasedMenu()
        {
            Events.MenuItem lettersAndVersionOption = new Events.MenuItem("Letters and Version");
            Events.MenuItem dateTimeOption = new Events.MenuItem("Show Current Date/Time");
            Events.MenuItem showVersionOption = new Events.MenuItem("Show Version");
            Events.MenuItem countLettersOption = new Events.MenuItem("Count Lowercase Letters");
            Events.MenuItem showDateOption = new Events.MenuItem("Show Current Date");
            Events.MenuItem showTimeOption = new Events.MenuItem("Show Current Time");

            showVersionOption.PerformAction += MenuOperations.ShowVersion_PerformAction;
            countLettersOption.PerformAction += MenuOperations.CountLowercaseLetters_PerformAction;
            showDateOption.PerformAction += MenuOperations.ShowCurrentDate_PerformAction;
            showTimeOption.PerformAction += MenuOperations.ShowCurrentTime_PerformAction;
            lettersAndVersionOption.AddInnerMenuItem(showVersionOption);
            lettersAndVersionOption.AddInnerMenuItem(countLettersOption);
            dateTimeOption.AddInnerMenuItem(showDateOption);
            dateTimeOption.AddInnerMenuItem(showTimeOption);
            r_EventsBasedMainMenu.AddMenuItem(lettersAndVersionOption);
            r_EventsBasedMainMenu.AddMenuItem(dateTimeOption);
        }

        public void show()
        {
            r_InterfaceBasedMainMenu.Show();
            r_EventsBasedMainMenu.Show();
        }
    }
}
