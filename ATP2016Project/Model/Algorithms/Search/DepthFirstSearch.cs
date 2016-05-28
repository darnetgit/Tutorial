using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using ATP2016Project.Model.Algorithms.MazeGenerators;

namespace ATP2016Project.Model.Algorithms.Search
{   /// <summary>
    /// the Depth First Search is an algorithm for traversing or searching tree or graph
    /// </summary>
    class DepthFirstSearch : ISearchingAlgorithm
    {
        /// <summary>
        /// the property that holds the stack we use for the DFS
        /// </summary>
        private Stack<Astate> stack = new Stack<Astate>();

        /// <summary>
        /// Dictionary that holds all the nodes we visited in.
        /// </summary>
        private Dictionary<string, Astate> m_visited;

        /// <summary>
        /// stopwatch - for measure the time it took to solve the problem
        /// </summary>
        private Stopwatch m_stop;

        /// <summary>
        /// property that holds the number of nodes developed so far
        /// </summary>
        private int m_numofnodes;

        /// <summary>
        /// constructor
        /// </summary>
        public DepthFirstSearch()
        {
            stack = new Stack<Astate>();
            m_visited = new Dictionary<string, Astate>();
            m_stop = new Stopwatch();
            m_numofnodes = 1;
        }

        /// <summary>
        /// get the number of nodes used by the algorithm
        /// </summary>
        /// <returns></returns>
        public int getNumberOfNodes()
        {
            return m_numofnodes;
            throw new NotImplementedException();
        }
        /// <summary>
        /// start timing the algorithm
        /// </summary>
        public void StartTiming()
        {
            m_stop.Restart();
        }
        /// <summary>
        /// stop timing the algorithm
        /// </summary>
        public void StopTiming()
        {
            m_stop.Stop();
        }
        /// <summary>
        /// return the difference between end and start time
        /// </summary>
        /// <returns></returns>
        public double GetSolvingTime()
        {
            return m_stop.ElapsedMilliseconds;
            throw new NotImplementedException();
        }
        /// <summary>
        /// implimantion of the DFS algorithm
        /// </summary>
        /// <remarks>1. insert the start state to the stack.
        /// 2. While stack not empty
        /// 2.1 pop from stack and insert to v
        /// 2.2 if v is the goal
        /// 2.2.1 get solution
        /// 2.3 if v is not in the visited list:
        /// 2.3.1 insert v to m_visited
        /// 2.3.2 for all neighbors of v, push neighbor to stack</remarks>
        /// <param name="search"></param>
        /// <returns></returns>
        public Solution Solve(ISearchable search)
        {
            StartTiming();
            m_visited.Clear();
            m_numofnodes = 1;
            stack.Push(search.getInitialState());
            Solution sol = new Solution();
            Astate goal = search.getGoalState();
            while (stack.Count != 0)
            {
                Astate vertex = stack.Pop();
                if (vertex.Equals(goal))
                {
                    sol = backtrack(vertex);
                    break;
                }
                if (!m_visited.ContainsKey((vertex as MazeState).currentp.ToString()))
                    m_visited.Add((vertex as MazeState).currentp.ToString(), vertex);
                List <Astate> lolist = search.getAllPossibleStates(vertex);
                foreach (Astate a in lolist)
                {
                    if (!m_visited.ContainsKey((a as MazeState).currentp.ToString()))
                    {
                        a.cameFrom = vertex;
                        stack.Push(a);
                        m_numofnodes++;
                    }
                }
            }
            StopTiming();
            return sol;
        }
        /// <summary>
        /// in order to find the solution we need to go backwards from the goal position to the start position
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        private Solution backtrack(Astate v)
        {
            Solution sol = new Solution();
            MazeState parent = (MazeState)v;
            while (parent!= null)
            {
                sol.addState(parent);
                parent = (MazeState)parent.cameFrom;
            }
            sol.Reverse();
            return sol;  
        }
    }
}
