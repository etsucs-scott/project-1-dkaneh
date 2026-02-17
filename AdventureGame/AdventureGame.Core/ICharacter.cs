using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Basic interface for monsters and the player
    /// </summary>
    internal interface ICharacter
    {
        int X { get; set; }
        int Y { get; set; }
        int Health { get; set; }
        int Damage { get; set; }
    }
}
