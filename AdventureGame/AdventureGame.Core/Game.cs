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
        private Monster CurrentMonster1, CurrentMonster2, CurrentMonster3;

        public void Start()
        {
            DisplayIntro();
            
            // Test Grid
            string[,] grid =
            {
                { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "E", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", }
            };
            CurrentMaze = new Maze(grid);
            CurrentPlayer = new Player(1, 1);
            CurrentMonster1 = new Monster();
            CurrentMonster2 = new Monster();
            CurrentMonster3 = new Monster();

            Console.ReadKey(true);
            Console.Clear();

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("\nUse WASD or arrow keys to move around the maze!");
        }

        private void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You escaped the maze!");
            Console.WriteLine("\nPress any key to exit...");
        }

        private void DisplayDeath()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER! You're dead! So sad :(");
            Console.WriteLine("\nPress any key to exit...");
        }

        private void DrawFrame()
        {
            CurrentMaze.Draw();
            string elementAtMonster1Position = CurrentMaze.GetElementAt(CurrentMonster1.X, CurrentMonster1.Y);
            string elementAtMonster2Position = CurrentMaze.GetElementAt(CurrentMonster2.X, CurrentMonster2.Y);
            string elementAtMonster3Position = CurrentMaze.GetElementAt(CurrentMonster3.X, CurrentMonster3.Y);

            if (CurrentMonster1.Health > 0)
            {
                if (elementAtMonster1Position == ".")
                {
                    CurrentMonster1.Draw();
                }
                else
                {
                    CurrentMonster1.X -= 1;
                    CurrentMonster1.Y -= 1;
                    CurrentMonster1.Draw();
                }
            }
            if (CurrentMonster2.Health > 0)
            {
                if (elementAtMonster2Position == ".")
                {
                    CurrentMonster2.Draw();
                }
                else
                {
                    CurrentMonster2.X -= 1;
                    CurrentMonster2.Y -= 1;
                    CurrentMonster2.Draw();
                }
            }

            if (CurrentMonster3.Health > 0)
            {
                if (elementAtMonster3Position == ".")
                {
                    CurrentMonster3.Draw();
                }
                else
                {
                    CurrentMonster3.X -= 1;
                    CurrentMonster3.Y -= 1;
                    CurrentMonster3.Draw();
                }
            }

            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"You are currently at {CurrentPlayer.Health} health points!");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine($"You have {CurrentPlayer.Damage} damage!");

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

                if (((CurrentPlayer.X == CurrentMonster1.X) && (CurrentPlayer.Y == CurrentMonster1.Y)) || ((CurrentPlayer.X == CurrentMonster2.X) && (CurrentPlayer.Y == CurrentMonster2.Y)) || ((CurrentPlayer.X == CurrentMonster3.X) && (CurrentPlayer.Y == CurrentMonster3.Y)))
                {
                    Fight();
                }

                if (CurrentPlayer.Health < 0)
                {
                    break;
                }

            }

            if (CurrentPlayer.Health < 0)
            {
                DisplayDeath();
            }
            else
            {
                DisplayVictory();
            }
        }

        private void Fight()
        {
            if ((CurrentPlayer.X == CurrentMonster1.X) && (CurrentPlayer.Y == CurrentMonster1.Y))
            {
                while (CurrentPlayer.Health > 1 || CurrentMonster1.Health > 1)
                {
                    CurrentMonster1.Health -= CurrentPlayer.Damage;
                    if (CurrentMonster1.Health < 1) { break; }
                    CurrentPlayer.Health -= CurrentMonster1.Damage;
                }
            }

            if ((CurrentPlayer.X == CurrentMonster2.X) && (CurrentPlayer.Y == CurrentMonster2.Y))
            {
                while (CurrentPlayer.Health > 1 || CurrentMonster2.Health > 1)
                {
                    CurrentMonster2.Health -= CurrentPlayer.Damage;
                    if (CurrentMonster2.Health < 1) { break; }
                    CurrentPlayer.Health -= CurrentMonster2.Damage;
                }
            }

            if ((CurrentPlayer.X == CurrentMonster3.X) && (CurrentPlayer.Y == CurrentMonster3.Y))
            {
                while (CurrentPlayer.Health > 1 || CurrentMonster3.Health > 1)
                {
                    CurrentMonster3.Health -= CurrentPlayer.Damage;
                    if (CurrentMonster3.Health < 1) { break; }
                    CurrentPlayer.Health -= CurrentMonster3.Damage;
                }
            }
        }

    }
}
