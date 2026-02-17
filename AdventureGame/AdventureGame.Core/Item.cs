using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Abstract class for potions and weapons
    /// </summary>
    internal abstract class Item
    {
        public int X { get; set; }
        public int Y { get; set; }

    }
}
