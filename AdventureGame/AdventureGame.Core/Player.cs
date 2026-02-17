using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    internal class Player : ICharacter
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string PlayerIcon;
        public int Health { get; set; }
        public int Damage { get; set; }
        Random random = new Random();

        /// <summary>
        /// Handles the palyer's positio in the maze, health, and damage
        /// </summary>
        public Player()
        {
            X = 1;
            Y = random.Next(1,12);
            PlayerIcon = "@";
            Health = 100;
            Damage = 10;

        }
        /// <summary>
        /// Prints the player to the screen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(PlayerIcon);
            Console.ResetColor();
        }
    }
}
