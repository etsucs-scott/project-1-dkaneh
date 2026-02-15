using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    public class Game
    {
        private Maze CurrentMaze;
        private Player CurrentPlayer;
        public void Start()
        {
            
            string[,] grid =
            {
                { "#", "#", "#", "#", "#", "#", "#", },
                { "#", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", "E", },
                { "#", ".", ".", ".", ".", ".", "#", },
                { "#", "#", "#", "#", "#", "#", "#", }
            };
            CurrentMaze = new Maze(grid);

            CurrentPlayer = new Player(1, 1);

            // Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey(true);

            RunGameLoop();
        }

        private void DrawFrame()
        {
            CurrentMaze.Draw();
            CurrentPlayer.Draw();
        }
        private void PlayerInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.W:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.A:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.S:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                case ConsoleKey.D:
                    if (CurrentMaze.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;
                    }
                    break;
                default:
                    break;
            }
        }

        private void RunGameLoop()
        {
            while (true)
            {
                DrawFrame();
                PlayerInput();
                string elementAtPlayerPosition = CurrentMaze.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPosition == "E")
                {
                    break;
                }
            }
        }
    }
}
