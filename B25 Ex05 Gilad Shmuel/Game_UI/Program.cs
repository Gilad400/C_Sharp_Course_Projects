using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game_Logic;

namespace Game_UI
{
    public static class Program
    {
        public static void Main()
        {
            GameManager gameManager = new GameManager();

            gameManager.Play();
        }
    }
}
