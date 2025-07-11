using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowCurrentDate : IMenuItem
    {
        string IMenuItem.Title
        {
            get { return "Show Current Date"; }
        }

        void IMenuItem.Perform()
        {
            Console.WriteLine("Current Date is {0}", DateTime.Now.Date.ToShortDateString());
            Console.WriteLine();
        }
    }
}
