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

        public Monster()
        {
            X = random.Next(6,12);
            Y = random.Next(3,12);
            MonsterIcon = "M";
            Health = random.Next(26, 46);
            Damage = random.Next(10, 19);
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(MonsterIcon);
            Console.ResetColor();
        }
    }
}
