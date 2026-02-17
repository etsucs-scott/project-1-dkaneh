using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// The main game, what prints to screen and holds all the game data
    /// </summary>
    public class Game
    {
        private Maze CurrentMaze;
        private Player CurrentPlayer;
        private Monster CurrentMonster1, CurrentMonster2, CurrentMonster3;
        private Weapon CurrentWeapon1, CurrentWeapon2;
        private Potion CurrentPotion1, CurrentPotion2;
        Random random = new Random();

        /// <summary>
        /// Starts the game
        /// </summary>
        public void Start()
        {
            DisplayIntro();
            
            // Starting Grid
            string[,] grid =
            {
                { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "E", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", ".", "#", },
                { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", }
            };

            CurrentPlayer = new Player();
            CurrentMaze = new Maze(grid);
            CurrentMonster1 = new Monster();
            CurrentMonster2 = new Monster();
            CurrentMonster3 = new Monster();
            CurrentPotion1 = new Potion();
            CurrentPotion2 = new Potion();
            CurrentWeapon1 = new Weapon();
            CurrentWeapon2 = new Weapon();
            GenerateMaze(grid);

            Console.ReadKey(true);
            Console.Clear();

            RunGameLoop();
        }

        /// <summary>
        /// Creates maze for game
        /// </summary>
        /// <param name="grid">The base grid</param>
        /// <returns></returns>
        private string[,] GenerateMaze(string[,] grid)
        {
            int rows = grid.GetLength(0);
            int cols = grid.GetLength(1);

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    if (x == 0 || y == 0 || x == cols - 1 || y == rows - 1)
                    {
                        grid[y, x] = "#";
                    }
                }
            }

            for (int i = 0; i < 20; i++)
            {
                int x = random.Next(1, cols - 1);
                int y = random.Next(1, rows - 1);

                if (CanWallBePlaced(grid, x, y))
                {
                    grid[y, x] = "#";
                }
            }


            return grid;
        }

        /// <summary>
        /// Tells whether a cell in the maze is adjacent to 2 or fewer walls
        /// </summary>
        /// <param name="grid">The maze</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>If tile is adjacent to 2 or fewer walls</returns>
        private bool CanWallBePlaced(string[,] grid, int x, int y)
        {
            int totalWalls = 0;

            if (grid[y - 1, x] == "#") totalWalls++;
            if (grid[y + 1, x] == "#") totalWalls++;
            if (grid[y, x - 1] == "#") totalWalls++;
            if (grid[y, x + 1] == "#") totalWalls++;

            return totalWalls <= 2;
        }
        /// <summary>
        /// Prints intro to game
        /// </summary>
        private void DisplayIntro()
        {
            Console.WriteLine("Hello!");
            Console.WriteLine("Welcome to the Adventure Game!");
            Console.WriteLine("\nUse WASD or arrow keys to move around the maze!");
        }
        /// <summary>
        /// Displays victory screen if player reaches end
        /// </summary>
        private void DisplayVictory()
        {
            Console.Clear();
            Console.WriteLine("Congratulations! You escaped the maze!");
            Console.WriteLine("\nPress any key to exit...");
        }
        /// <summary>
        /// Display death screen if player dies.
        /// </summary>
        private void DisplayDeath()
        {
            Console.Clear();
            Console.WriteLine("GAME OVER! You're dead! So sad :(");
            Console.WriteLine("\nPress any key to exit...");
        }
        /// <summary>
        /// Prints a single frame of the game to the console
        /// </summary>
        private void DrawFrame()
        {
            CurrentMaze.Draw();

            string elementAtMonster1Position = CurrentMaze.GetElementAt(CurrentMonster1.X, CurrentMonster1.Y);
            string elementAtMonster2Position = CurrentMaze.GetElementAt(CurrentMonster2.X, CurrentMonster2.Y);
            string elementAtMonster3Position = CurrentMaze.GetElementAt(CurrentMonster3.X, CurrentMonster3.Y);

            if (CurrentMonster1.Health > 0)
            {
                while (CanWallBePlaced(CurrentMaze.Grid, CurrentMonster1.X, CurrentMonster1.Y) == false && elementAtMonster1Position != "#")
                {
                    CurrentMonster1.X = random.Next(6, 12);
                    CurrentMonster1.Y = random.Next(1, 12);
                }
                CurrentMonster1.Draw();
            }
            if (CurrentMonster2.Health > 0)
            {
                while (CanWallBePlaced(CurrentMaze.Grid, CurrentMonster2.X, CurrentMonster2.Y) == false && elementAtMonster2Position != "#")
                {
                    CurrentMonster2.X = random.Next(6, 12);
                    CurrentMonster2.Y = random.Next(1, 12);
                }
                CurrentMonster2.Draw();
            }

            if (CurrentMonster3.Health > 0)
            {
                while (CanWallBePlaced(CurrentMaze.Grid, CurrentMonster3.X, CurrentMonster3.Y) == false && elementAtMonster3Position != "#")
                {
                    CurrentMonster3.X = random.Next(6, 12);
                    CurrentMonster3.Y = random.Next(1, 12);
                }
                CurrentMonster3.Draw();
            }
            string elementAtPotion1Position = CurrentMaze.GetElementAt(CurrentPotion1.X, CurrentPotion1.Y);
            string elementAtPotion2Position = CurrentMaze.GetElementAt(CurrentPotion2.X, CurrentPotion2.Y);
            string elementAtWeapon1Position = CurrentMaze.GetElementAt(CurrentWeapon1.X, CurrentWeapon1.Y);
            string elementAtWeapon2Position = CurrentMaze.GetElementAt(CurrentWeapon2.X, CurrentWeapon2.Y);

            while (CanWallBePlaced(CurrentMaze.Grid, CurrentPotion1.X, CurrentPotion1.Y) == false && elementAtPotion1Position != "#")
            {
                CurrentPotion1.X = random.Next(6, 12);
                CurrentPotion1.Y = random.Next(1, 12);
            }
            CurrentPotion1.Draw();

            while (CanWallBePlaced(CurrentMaze.Grid, CurrentPotion2.X, CurrentPotion2.Y) == false && elementAtPotion2Position != "#")
            {
                CurrentPotion2.X = random.Next(6, 12);
                CurrentPotion2.Y = random.Next(1, 12);
            }
            CurrentPotion2.Draw();

            while (CanWallBePlaced(CurrentMaze.Grid, CurrentWeapon1.X, CurrentWeapon1.Y) == false && elementAtWeapon1Position != "#")
            {
                CurrentWeapon1.X = random.Next(6, 12);
                CurrentWeapon1.Y = random.Next(1, 12);
            }
            CurrentWeapon1.Draw();

            while (CanWallBePlaced(CurrentMaze.Grid, CurrentWeapon2.X, CurrentWeapon2.Y) == false && elementAtWeapon2Position != "#")
            {
                CurrentWeapon2.X = random.Next(6, 12);
                CurrentWeapon2.Y = random.Next(1, 12);
            }
            CurrentWeapon2.Draw();

            Console.SetCursorPosition(0, 15);
            Console.WriteLine($"You are currently at {CurrentPlayer.Health} health points!");
            Console.SetCursorPosition(0, 16);
            Console.WriteLine($"You have {CurrentPlayer.Damage} damage!");

            CurrentPlayer.Draw();
        }
        /// <summary>
        /// Allows the player's input to translate to the maze
        /// </summary>
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
        /// <summary>
        /// The cycle that the game runs on, checks if ending conditions are met
        /// </summary>
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

                if (((CurrentPlayer.X == CurrentPotion1.X) && (CurrentPlayer.Y == CurrentPotion1.Y)) || ((CurrentPlayer.X == CurrentPotion2.X) && (CurrentPlayer.Y == CurrentPotion2.Y)))
                {
                    CurrentPlayer.Health += 20;
                    if (CurrentPlayer.Health > 150) { CurrentPlayer.Health = 150;}
                    if ((CurrentPlayer.X == CurrentPotion1.X) && (CurrentPlayer.Y == CurrentPotion1.Y)) { CurrentPotion1.UsePotion(); }
                    if ((CurrentPlayer.X == CurrentPotion2.X) && (CurrentPlayer.Y == CurrentPotion2.Y)) { CurrentPotion2.UsePotion(); }

                }

                if (((CurrentPlayer.X == CurrentWeapon1.X) && (CurrentPlayer.Y == CurrentWeapon1.Y)) || ((CurrentPlayer.X == CurrentWeapon2.X) && (CurrentPlayer.Y == CurrentWeapon2.Y)))
                {
                    if ((CurrentPlayer.X == CurrentWeapon1.X) && (CurrentPlayer.Y == CurrentWeapon1.Y))
                    {
                        if (CurrentPlayer.Damage < (CurrentWeapon1.DamageModifier + 10)) { CurrentPlayer.Damage = CurrentWeapon1.DamageModifier + 10; }
                        else 
                        {
                            
                            Console.SetCursorPosition(0, 17);
                            Console.Write("You already have a better weapon equipped!");
                           
                        }
                        CurrentWeapon1.HoldWeapon();
                    }
                    
                    if ((CurrentPlayer.X == CurrentWeapon2.X) && (CurrentPlayer.Y == CurrentWeapon2.Y))
                    {
                        if (CurrentPlayer.Damage < (CurrentWeapon2.DamageModifier + 10)) { CurrentPlayer.Damage = CurrentWeapon2.DamageModifier + 10; }
                        else
                        {
                            
                            Console.SetCursorPosition(0, 17);
                            Console.Write("You already have a better weapon equipped!");
                            
                        }
                        CurrentWeapon2.HoldWeapon();
                    }
                }

                if (CurrentPlayer.Health < 1)
                {
                    break;
                }

            }


            if (CurrentPlayer.Health < 1)
            {
                DisplayDeath();
            }
            else
            {
                DisplayVictory();
            }
        }
        /// <summary>
        /// Battling mechanics
        /// </summary>
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
