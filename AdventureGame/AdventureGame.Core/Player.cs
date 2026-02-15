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
        private string PlayerIcon;
        
        public Player(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerIcon = "@";
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(PlayerIcon);
        }
    }
}
