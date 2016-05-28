using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// inherits Isearchable in order to search a 3d maze for a solution
    /// </summary>
    class SearchableMaze3d : ISearchable
    {
        private Maze3d maze;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="maze3d"></param>
        public SearchableMaze3d(Maze3d maze3d)
        {
            maze = maze3d;
        }
        /// <summary>
        /// get all possible states that can be reached from given state
        /// </summary>
        /// <remarks>in a given state s look to all directions - up, down, left, right, floor up, floor down and insert to a list 
        /// all possible directions</remarks>
        /// <param name="s">Get state for which we need to seek for legible neighbors</param>
        /// <returns>returns a list with all the directions that we can go through</returns>
        public List<Astate> getAllPossibleStates(Astate s)
        {
            List<MazeState> list = new List<MazeState>();
            List<Astate> list2 = new List<Astate>();
            Position p = (s as MazeState).currentp;
            Maze2d maze2 = maze.maze3d[p.z];
            try{
                if (maze2.maze2d[p.x, p.y + 1] == 0 || maze2.maze2d[p.x, p.y + 1] == 4 || maze2.maze2d[p.x, p.y + 1] == 3)
                    list.Add(new MazeState(s, new Position(p.x, p.y + 1, p.z)));
            }
            catch (IndexOutOfRangeException e) { };
            try{
                if (maze2.maze2d[p.x - 1, p.y] == 0 || maze2.maze2d[p.x - 1, p.y] == 3 || maze2.maze2d[p.x - 1, p.y] == 4)
                    list.Add(new MazeState(s, new Position(p.x - 1, p.y, p.z)));
            }
            catch (Exception e) { };
            try{
                if (maze2.maze2d[p.x, p.y - 1] == 0 || maze2.maze2d[p.x, p.y - 1] == 3 || maze2.maze2d[p.x, p.y - 1] == 4)
                    list.Add(new MazeState(s, new Position(p.x, p.y - 1, p.z)));
            }
            catch (Exception e) { };
            try{
                if (maze2.maze2d[p.x + 1, p.y] == 0 || maze2.maze2d[p.x + 1, p.y] == 3 || maze2.maze2d[p.x + 1, p.y] == 4)
                    list.Add(new MazeState(s, new Position(p.x + 1, p.y, p.z)));
            }
            catch (Exception e) { };
            if (p.z + 1 < (maze as Maze3d).maze3d.Length && ((maze as Maze3d).maze3d[p.z + 1].maze2d[p.x, p.y] == 0 || (maze as Maze3d).maze3d[p.z + 1].maze2d[p.x, p.y] == 4 || (maze as Maze3d).maze3d[p.z + 1].maze2d[p.x, p.y] == 3))
                list.Add(new MazeState(s, new Position(p.x, p.y, p.z + 1)));
            if (p.z - 1 >= 0 && p.z - 1 < (maze as Maze3d).maze3d.Length && (((maze as Maze3d).maze3d[p.z - 1].maze2d[p.x, p.y] == 0)|| ((maze as Maze3d).maze3d[p.z - 1].maze2d[p.x, p.y] == 3)|| ((maze as Maze3d).maze3d[p.z - 1].maze2d[p.x, p.y] == 4)))
                list.Add(new MazeState(s, new Position(p.x, p.y, p.z - 1)));
            foreach(MazeState m in list)
                list2.Add((m as Astate));
            return list2;
        }

        /// <summary>
        /// get goal state (the end of the maze)
        /// </summary>
        /// <returns>The goal state</returns>
        public Astate getGoalState()
        {
            
            Position goal=maze.getGoalPosition();
            Astate ans = new MazeState(null, goal);

            return ans;

        }
        /// <summary>
        /// get initial state (the state of the maze)
        /// </summary>
        /// <returns>The initial state</returns>
        public Astate getInitialState()
        {
            Position start = maze.getStartPosition();
            Astate ans = new MazeState(null, start);

            return ans;
        }
    }
}
