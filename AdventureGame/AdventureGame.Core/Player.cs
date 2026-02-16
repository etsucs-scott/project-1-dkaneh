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
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerIcon = "@";
            Health = 100;
            Damage = 10;

        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerIcon);
        }
    }
}
