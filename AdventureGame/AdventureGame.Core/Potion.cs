using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Handles the potions, and 
    /// </summary>
    internal class Potion : Item
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string PotionIcon { get; set; }

        private static Random random = new Random();

        /// <summary>
        /// Holds the location of the potion
        /// </summary>
        public Potion()
        {
            X = random.Next(5, 9);
            Y = random.Next(3, 12);
            PotionIcon = "P";
        }

        /// <summary>
        /// Draws the potion to the screen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(PotionIcon);
            Console.ResetColor();
        }

        /// <summary>
        /// Makes the potion vanish
        /// </summary>
        public void UsePotion()
        {
            X = 1;
            Y = 1;
            PotionIcon = "";
        }
    }
}
