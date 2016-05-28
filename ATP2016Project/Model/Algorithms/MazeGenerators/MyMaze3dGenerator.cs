using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The class that generate 3D maze.
/// </summary>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    class MyMaze3dGenerator : AMazeGenerator
    {
        /// <summary>
        /// Generate a 3D maze.
        /// </summary>
        /// <param name="mazesizes">Get the sizes of the maze</param>
        /// <returns>Returns a maze with a solution.</returns>
        /// <remarks>For each floor we build a 2D maze. First we fill the 0 floor all with 1s then for each floor, except the last, 
        /// we call to generate2d that generates a 2D maze. The last floor will be filled with 1s and one 4 - the exit. Floor no. 1 will mark the start.</remarks>
        public override AMaze generate(ArrayList mazesizes)
        {
            Maze3d maze3d = new Maze3d(mazesizes);
            int floors = (int)mazesizes[2];
            ArrayList al2 = new ArrayList();
            al2.Add(mazesizes[0]);
            al2.Add(mazesizes[1]);
            
            for (int i = 0; i < (int)mazesizes[0]; i++) {
                for (int j = 0; j < (int)mazesizes[1]; j++) { 
                    maze3d.maze3d[0].maze2d[i, j] = 1;
                }
            }

            for (int i = 1; i <= floors; i++) {
                maze3d.maze3d[i]=(Maze2d)generate2d(al2);
            }
            for (int i = 0; i < (int)mazesizes[0]; i++)
            {
                for (int j = 0; j < (int)mazesizes[1]; j++)
                {
                    if (maze3d.maze3d[maze3d.maze3d.Length - 2].maze2d[i, j] == 4)
                    {
                        maze3d.maze3d[floors + 1].maze2d[i, j] = 4;
                        maze3d.end = new Position(i, j, floors + 1);
                    }
                    else
                        maze3d.maze3d[floors + 1].maze2d[i, j] = 1;
                }
            }
            maze3d.start = maze3d.maze3d[1].start;
            maze3d.maze3d[1].maze2d[maze3d.start.x, maze3d.start.y]=3;
            return maze3d;
        }

        /// <summary>
        /// Generate a 2D maze using Prim's algorithm.
        /// </summary>
        /// <param name="mazesizes">Get the sizes of the maze</param>
        /// <returns>Returns a maze with a solution.</returns>
        /// <remarks>1. A Grid consists of a 2 dimensional array of cells. A Cell has 2 states: Blocked or Passage.
        /// Start with a Grid full of Cells in state Blocked.
        /// 2. Pick a random Cell, set it to state Passage and Compute its frontier cells.
        /// A frontier cell of a Cell is a cell with distance 2 in state Blocked and within the grid.
        /// 3. While the list of frontier cells is not empty:
        /// 3.1. Pick a random frontier cell from the list of frontier cells.
        /// 3.2. Let neighbors(frontierCell) = All cells in distance 2 in state Passage. 
        /// Pick a random neighbor and connect the frontier cell with the neighbor by setting the cell in-between to state Passage. 
        /// Compute the frontier cells of the chosen frontier cell and add them to the frontier list. 
        /// Remove the chosen frontier cell from the list of frontier cells.</remarks>
        private AMaze generate2d(ArrayList mazesizes) { 
            Maze2d maze2d = new Maze2d(mazesizes);
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
            int rowtostart = Util.GetRandom(1, maze2d.maze2d.GetLength(0) - 1);
            int position;
            ArrayList n = new ArrayList();
            n.Add(new Position(rowtostart, 1,0));
            maze2d.start = new Position(rowtostart, 0, 1);
            maze2d.maze2d[rowtostart, 1] = 0;
            getFrontier(new Position(rowtostart, 1,0), maze2d.maze2d, n);
            while (n.Count > 0)
            {
                position = Util.GetRandom(0, n.Count);
                Position t = (Position)n[position];
                ArrayList nei = new ArrayList();
                getNeighbors(t, maze2d.maze2d,nei);
                if (nei.Count > 0)
                {
                    Position neig = (Position)nei[Util.GetRandom(0, nei.Count)];
                    maze2d.maze2d[neig.x, neig.y] = 0;
                    maze2d.maze2d[t.x, t.y] = 0;
                }
                getFrontier(t, maze2d.maze2d, n);
                n.RemoveAt(position);
                if (n.Count == 0)
                    maze2d.maze2d[t.x, t.y] = 4;
            }
            return maze2d;
        }

        /// <summary>
        /// Add to the list all the legible frontiers.
        /// </summary>
        /// <param name="position">The position for which we need the frontiers.</param>
        /// <param name="maze">The maze in which we work.</param>
        /// <param name="frontiers">The Arraylist to which we add the frontiers.</param>
        /// <remarks>Check in all directions - up, down, right, left if the frontier is legible (legible if the cell is 1), if it is - add
        /// to the arraylist.</remarks>
        private void getFrontier(Position position, int[,] maze, ArrayList frontiers)
        {
            if (position.x >= 2 && maze[position.x - 2, position.y] == 1)
                frontiers.Add(new Position(position.x - 2, position.y,0));
            if (position.x < maze.GetLength(0) - 2 && maze[position.x + 2, position.y] == 1)
                frontiers.Add(new Position(position.x + 2, position.y, 0));
            if (position.y >= 2 && maze[position.x, position.y - 2] == 1)
                frontiers.Add(new Position(position.x, position.y - 2, 0));
            if (position.y < maze.GetLength(1) - 2 && maze[position.x, position.y + 2] == 1)
                frontiers.Add(new Position(position.x, position.y + 2, 0));
        }

        /// <summary>
        /// Add to the list all the legible neighbors.
        /// </summary>
        /// <param name="position">The position for which we need the neighbors.</param>
        /// <param name="maze">The maze in which we work.</param>
        /// <param name="neighbors">The Arraylist to which we add the neighbors.</param>
        /// <remarks>Check in all directions - up, down, right, left if the neighbors is legible (legible if the cell is 1), if it is - add
        /// to the arraylist.</remarks>
        private void getNeighbors(Position position, int[,] maze, ArrayList neighbors)
        {
            if (position.x >= 2 && maze[position.x - 2, position.y] == 0)
                neighbors.Add(new Position(position.x - 1, position.y, 0));
            if (position.x < maze.GetLength(0) - 2 && maze[position.x + 2, position.y] == 0)
                neighbors.Add(new Position(position.x + 1, position.y, 0));
            if (position.y >= 2 && maze[position.x, position.y - 2] == 0)
                neighbors.Add(new Position(position.x, position.y - 1, 0));
            if (position.y < maze.GetLength(1) - 2 && maze[position.x, position.y + 2] == 0)
                neighbors.Add(new Position(position.x, position.y + 1, 0));
        }
    }
}
