using ATP2016Project.Model.Algorithms.MazeGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// inherits abstract class Astate
    /// </summary>
    class MazeState : Astate
    {
        private Position currentP;
        /// <summary>
        /// each maze state is composed from a "father" state and a position 
        /// </summary>
        /// <param name="camefrom"></param>
        /// <param name="curr"></param>
        public MazeState(Astate camefrom, Position curr) : base(camefrom)
        {
            state = curr.ToString();
            currentp = curr;
        }
        /// <summary>
        /// getter and setter for the current position
        /// </summary>
        public Position currentp
        {
            get { return currentP; }
            set { currentP = value; }
        }
        /// <summary>
        /// overrides the equals method
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public override bool Equals(Astate state)
        {
            return currentp.ToString().Equals((state as MazeState).currentp.ToString());
        }
    }
}
