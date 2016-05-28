using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// IMazeGenerator is the interface that generates the maze. 
/// </summary>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    interface IMazeGenerator
    {
        /// <summary>
        /// The function that generates the maze - the following class
        /// will implement the function.
        /// </summary>
        AMaze generate(ArrayList mazesizes);

        /// <summary>
        /// The function measures how many miliseconds took to generate the maze.
        /// </summary>
        /// <param name="al"></param>
        /// <returns></returns>
        String MeasureAlgorithmTime(ArrayList al);
    }
}
