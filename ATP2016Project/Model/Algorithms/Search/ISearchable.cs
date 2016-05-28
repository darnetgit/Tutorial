using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// interface that is recived by the solver in oreder to solve a solveable problem
    /// </summary>
    interface ISearchable
    {
        /// <summary>
        /// Returns the initial state
        /// </summary>
        /// <returns></returns>
        Astate getInitialState();
        /// <summary>
        /// Returns the goal state
        /// </summary>
        /// <returns></returns>
            Astate getGoalState();
        /// <summary>
        /// Returns all posible states that the problem could reach from given state s
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
            List<Astate> getAllPossibleStates(Astate s);
        
    }
}
