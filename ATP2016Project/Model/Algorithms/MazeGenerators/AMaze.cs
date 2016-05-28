using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The abstract class of maze.
/// </summary>
/// <remarks>Represent the abstract form of maze and holds all the properties of every maze.</remarks>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    abstract class AMaze : IMaze
    {

        /// <summary>
        /// The property that holds the position of the maze starts.
        /// </summary>
        private Position Start;

        /// <summary>
        /// The property that holds the position of the maze ends.
        /// </summary>
        private Position End;

        /// <summary>
        /// The property that holds the sizes of the maze.
        /// </summary>
        private ArrayList Sizes;

        /// <summary>
        /// Abstract function of printing a maze - maze2d and maze3d implements the function.
        /// </summary>
        /// <param name="z">The number of the floor.</param>
        public abstract void PrintMaze(int z);

        /// <summary>
        /// Getter end setter of start.
        /// </summary>
        public Position start
        {
            get { return Start; }
            set { Start = value; }
        }

        /// <summary>
        /// Getter end setter of end.
        /// </summary>
        public Position end
        {
            get { return End; }
            set { End = value; }
        }

        /// <summary>
        /// Getter end setter of sizes.
        /// </summary>
        public ArrayList sizes
        {
            get { return Sizes; }
            set { Sizes = value; }
        }

        /// <summary>
        /// The constructor of the class.
        /// </summary>
        /// <param name="sizes">Saves the sizes in our Arraylist according the sizes we got.</param>
        public AMaze (ArrayList sizes)
        {
            this.sizes = sizes;
        }

        /// <summary>
        /// Print the maze. Calls to PrintMaze with 1.
        /// </summary>
        public void Print()
        {
            PrintMaze(1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The position where the maze starts.</returns>
        public Position getStartPosition()
        {
            return this.start;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>The position where the maze ennds.</returns>
        public Position getGoalPosition()
        {
            return this.end;
        }
    }
}
