using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    internal class Weapon : Item
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string WeaponIcon { get; set; }
        public int DamageModifier { get; set; }

        private static Random random = new Random();

        /// <summary>
        /// Tracks the weapon's position and what its damage modifier is.
        /// </summary>
        public Weapon()
        {
            X = random.Next(5, 9);
            Y = random.Next(3, 12);
            WeaponIcon = "W";
            DamageModifier = random.Next(5, 11);
        }

        /// <summary>
        /// Prints the weapon to the screen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(WeaponIcon);
            Console.ResetColor();
        }

        /// <summary>
        /// Removes weapon
        /// </summary>
        public void HoldWeapon()
        {
            X = 1;
            Y = 1;
            WeaponIcon = "";
        }
    }
}
