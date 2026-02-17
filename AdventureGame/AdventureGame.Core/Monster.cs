using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    internal class Monster : ICharacter
    {
        public int X {  get; set; }
        public int Y { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }
        public string MonsterIcon { get; set; }

        private static Random random = new Random();

        /// <summary>
        /// Tracks the monster's position in the maze, its health, and its damage.
        /// </summary>
        public Monster()
        {
            X = random.Next(6,12);
            Y = random.Next(3,12);
            MonsterIcon = "M";
            Health = random.Next(30, 51);
            Damage = random.Next(13, 21);
        }

        /// <summary>
        /// Prints the monster to the screen
        /// </summary>
        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(MonsterIcon);
            Console.ResetColor();
        }
    }
}
