using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    /// <summary>
    /// IMaze is the interface that "AMaze" will inherit.
    /// </summary>
    interface IMaze
    {
        /// <summary>
        /// The function that prints the maze - the following class
        /// will implement the function.
        /// </summary>
        void Print();
    }
}
