using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The class that generate 2D maze.
/// </summary>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    class SimpleMaze2dGenerator : AMazeGenerator
    {

        /// <summary>
        /// Generate a simple 2D maze.
        /// </summary>
        /// <param name="mazesizes">Get the sizes of the maze</param>
        /// <returns>Returns a maze with a solution.</returns>
        /// <remarks>first we fill the maze with 1s and 2s. Pick a random start position in column 0, calls to buildApath and after that
        /// fills randomly the maze with walls.</remarks>
        public override AMaze generate(ArrayList mazesizes)
        {
            Maze2d maze2d = new Maze2d(mazesizes);
            int start = Util.GetRandom(1, maze2d.maze2d.GetLength(0) - 1);
            for (int row = 0; row < maze2d.maze2d.GetLength(0); row++)
            {
                for (int column = 0; column < maze2d.maze2d.GetLength(1); column++)
                {
                    if (row == 0 || column == 0 || row == maze2d.maze2d.GetLength(0) - 1 || column == maze2d.maze2d.GetLength(1) - 1)
                        maze2d.maze2d[row, column] = 2;
                    else
                        maze2d.maze2d[row, column] = 1;
                }
            }
            maze2d.start = new Position(start, 0);
            maze2d.maze2d[start, 0] = 0;
            maze2d.maze2d[start, 1] = 0;
            buildApath(start, 1, maze2d);
            for (int row = 0; row < maze2d.maze2d.GetLength(0); row++)
            {
                for (int column = 0; column < maze2d.maze2d.GetLength(1); column++)
                {
                    if (maze2d.maze2d[row, column] == 1)
                        maze2d.maze2d[row, column] = Util.GetRandom(0, 2);
                }
            }
            return (AMaze)maze2d;
        }

        /// <summary>
        /// Build a path from the start to a cell in the last column.
        /// </summary>
        /// <param name="row">The row where the maze starts.</param>
        /// <param name="column">The column where the maze starts.</param>
        /// <param name="maze2d">The maze in which we build the path.</param>
        /// <remarks>recursive function that builds a path. when we get to the last column, the function stops. We pick randomly direction 0-up, 
        /// 1-right, 2-down or 3-left where the proper cell is 1 (in a while until a proper dircetion is chosen), put in the currnet cell (maze2d[row, column]) 0 and call to buildApath
        /// with the parameters we got from the direction that was chosen. If there is no where to go (all around the current cell is 0 or 2) we will go to the rhight.(</remarks>
        private void buildApath(int row, int column, Maze2d maze2d)
        {
            bool flag = true;
            if (row <= 0 || column <= 0 || row >= maze2d.maze2d.GetLength(0) - 1 || column >= maze2d.maze2d.GetLength(1))
            { return; }
            else if (column == maze2d.maze2d.GetLength(1) - 1)
            {
                maze2d.maze2d[row, column] = 0;
                maze2d.end = new Position(row, column);
                return;
            }
            else
                maze2d.maze2d[row, column] = 0;
            while (flag)
            {
                int dir = Util.GetRandom(0, 4);
                if (dir == 0 && maze2d.maze2d[row - 1, column] != 2 && maze2d.maze2d[row - 1, column] != 0)
                {
                    flag = false;
                    buildApath(row - 1, column, maze2d);
                }
                else if (dir == 1 && maze2d.maze2d[row, column + 1] != 0)
                {
                    flag = false;
                    buildApath(row, column + 1, maze2d);
                }
                else if (dir == 2 && maze2d.maze2d[row + 1, column] != 2 && maze2d.maze2d[row + 1, column] != 0)
                {
                    flag = false;
                    buildApath(row + 1, column, maze2d);
                }
                else if (dir == 3 && maze2d.maze2d[row, column - 1] != 2 && maze2d.maze2d[row, column - 1] != 0)
                {
                    flag = false;
                    buildApath(row, column - 1, maze2d);
                }
                else if ((maze2d.maze2d[row + 1, column] == 0 || maze2d.maze2d[row + 1, column] == 2) && (maze2d.maze2d[row - 1, column] == 0 || maze2d.maze2d[row - 1, column] == 2)
                    && (maze2d.maze2d[row, column + 1] == 0 || maze2d.maze2d[row, column + 1] == 2) && (maze2d.maze2d[row, column - 1] == 0 || maze2d.maze2d[row, column - 1] == 2))
                {
                    flag = false;
                    buildApath(row, column + 1, maze2d);
                }
            }
        }
    }
}
