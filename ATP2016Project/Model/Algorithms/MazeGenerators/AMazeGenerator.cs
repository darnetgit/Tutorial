using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The abstract class that Generates the maze.
/// </summary>
/// <remarks>Represent the abstract form of generating a maze.</remarks>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    abstract class AMazeGenerator : IMazeGenerator
    {
        public abstract AMaze generate(ArrayList mazesizes);

        /// <summary>
        /// Measures the time took to generate the maze.
        /// </summary>
        /// <param name="mazesizes">The sizes of the maze to generate and measure time.</param>
        /// <returns>Returns a string of the time that took to generate the maze.</returns>
        /// <remarks>We define stopwatch and generates a maze, than we stop the stopwatch and save the number of miliseconds 
        /// that took to generate the maze.</remarks>
        public string MeasureAlgorithmTime(ArrayList mazesizes)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            generate(mazesizes);
            watch.Stop();
            var ms = watch.ElapsedMilliseconds;
                String ans = "time passed: " + ms + " ms";
            return ans;
        }
    }
}
