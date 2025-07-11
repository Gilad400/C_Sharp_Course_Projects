using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowCurrentTime : IMenuItem
    {
        string IMenuItem.Title
        {
            get { return "Show Current Time"; }
        }

        void IMenuItem.Perform()
        {
            Console.WriteLine("Current Time is {0}", DateTime.Now.ToString("HH:mm"));
            Console.WriteLine();
        }
    }
}
