using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureGame.Core
{
    internal class Maze
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public Maze(string[,] grid)
        {
            Grid = grid;
            Rows = grid.GetLength(0);
            Cols = grid.GetLength(1);
        }
        
        public void InitializeMaze()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Grid[y, x] = "#";
                    Console.ResetColor();
                }
            }
        }

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

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

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
