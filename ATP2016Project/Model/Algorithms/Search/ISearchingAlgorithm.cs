using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// interface that BFS and DFS algorithms will inherite in order to solve the maze
    /// </summary>
    interface ISearchingAlgorithm
    {
        /// <summary>
        /// recives an Isearchable and returns a solution for given problem
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        Solution Solve(ISearchable search);

        /// <summary>
        /// returns numbers of nodes developed during the solution 
        /// </summary>
        /// <returns></returns>
        int getNumberOfNodes();

        /// <summary>
        /// returns the time it took the algorithm to reach a solution 
        /// </summary>
        /// <returns></returns>
        double GetSolvingTime();
    }
}
