using AdventureGame.Core;

namespace AdventureGame.Cli
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game currentGame = new Game();
            currentGame.Start();
        }
    }
}
