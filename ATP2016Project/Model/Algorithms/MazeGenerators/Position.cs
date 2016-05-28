using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The class Positon is a representation of a "point".
/// </summary>
/// <remarks>We use this class for presenting a specific position inside our maze.</remarks>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    class Position
    {
        /// <summary>
        /// Represents the number of the row.
        /// </summary>
        private int X;

        /// <summary>
        /// Represents the number of the column.
        /// </summary>
        private int Y;

        /// <summary>
        /// Represents the floor number.
        /// </summary>
        private int Z;

        /// <summary>
        /// Getter and setter for x.
        /// </summary>
        public int x
        {
            get { return X; }
            set { X = value; }
        }

        /// <summary>
        /// Getter and setter for y.
        /// </summary>
        public int y
        {
            get { return Y; }
            set { Y = value; }
        }
        /// <summary>
        /// Getter and setter for z.
        /// </summary>
        public int z
        {
            get { return Z; }
            set { Z = value; }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <remarks>Sets the position by the given parameters.</remarks>
        /// <param name="x">Sets the x value.</param>
        /// <param name="y">Sets the y value.</param>
        /// <param name="z">Sets the z value.</param>
        public Position(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
            this.z = -1;
        }
        /// <summary>
        /// Override of ToString of object.
        /// </summary>
        /// <returns>Returns a string that represents the position 
        /// in the form of (x,y,z).</returns>
        public override string ToString()
        {
            String and;
            if (z != -1)
                and = "(" + x + "," + y + "," + z + ")";
            else
                and = "(" + x + "," + y + ")";
            return and;
        }

        /// <summary>
        /// Prints the position.
        /// </summary>
        public void print()
        {
            if (z != -1)
                Console.WriteLine("(" + x + "," + y + "," + z + ")");
            else
                Console.WriteLine("(" + x + "," + y + ")");
        }
    }
}
