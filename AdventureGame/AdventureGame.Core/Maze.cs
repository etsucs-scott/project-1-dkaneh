using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    /// <summary>
    /// Maintains information about the maze and recalls where specific items/obstacles are within it
    /// </summary>
    internal class Maze
    {
        public string[,] Grid;
        public int Rows;
        public int Cols;
        /// <summary>
        /// The maze the player traverses
        /// </summary>
        /// <param name="grid">The maze</param>
        public Maze(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }
        /// <summary>
        /// Prints the maze
        /// </summary>
        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    Console.SetCursorPosition(x, y);
                    if (element == "#") { Console.ForegroundColor = ConsoleColor.DarkYellow; }
                    Console.Write(element);
                    Console.ResetColor();
                }
            }
        }
        /// <summary>
        /// Retrieves what is on the tile of a given coordinate in the maze
        /// </summary>
        /// <param name="x">Y-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        /// <returns>String with element on the tile specified</returns>
        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        /// <summary>
        /// Returns whether a given coordinate is able to be walked on by the player
        /// </summary>
        /// <param name="x">X-coordinate</param>
        /// <param name="y">Y-coordinate</param>
        /// <returns>If the given coordinate does not have a wall on it</returns>
        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            return Grid[y, x] != "#";
        }
    }
}
