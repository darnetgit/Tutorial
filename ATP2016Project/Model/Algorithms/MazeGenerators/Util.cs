using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Class that genaretes Random
/// </summary>
/// <remarks>A static class of random that saves the log of all the randoms we already did
/// and improves the random statisticly.</remarks>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    public static class Util
    {
        /// <summary>
        /// The property random.
        /// </summary>
        private static Random random = new Random();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="min">The lower bound of the random range.</param>
        /// <param name="max">The upper bound of the random range.</param>
        /// <returns>Returns a random value between min and max.</returns>
        public static int GetRandom(int min, int max)
        {
            return random.Next(min,max);
        }
    }
}
