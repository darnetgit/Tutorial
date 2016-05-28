using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// the Breadth First Search is used in order to find the shortets path in a graph
    /// </summary>
    class BreadthFirstSearch : ISearchingAlgorithm
    {
        /// <summary>
        /// BreadthFirstSearch contains a queue, dictionary, stopwatch and an int
        /// </summary>
        private Queue<Astate> queue;
        private Dictionary<string, Astate> m_visited;
        private Stopwatch m_stop;
        private int m_numofnodes;
        /// <summary>
        /// constructor
        /// </summary>
        public BreadthFirstSearch()
        {
            queue = new Queue<Astate>();
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
        }
        /// <summary>
        /// start timing
        /// </summary>
        public void StartTiming()
        {
            m_stop.Restart();
        }
        /// <summary>
        /// stop timing
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
        }
        /// <summary>
        /// implimantion of the BFS algorithm
        /// </summary>
        /// <remarks>1. insert to queue the start state and insert start state to m_visited
        /// 2. while queue is not empty
        /// 2.1 dequeue state and mark as v
        /// 2.1 if v is the goal
        /// 2.1.1 get solution
        /// 2.2 else
        /// 2.2.1 if v is not in m_visited
        /// 2.2.1.1 insert v to m_visited
        /// 2.2.1.2 insert to queue all neigbors of v</remarks>
        /// <param name="search"></param>
        /// <returns></returns>
        public Solution Solve(ISearchable search)
        {
            StartTiming();
            m_visited.Clear();
            m_numofnodes = 1;
            queue.Enqueue(search.getInitialState());
            m_visited.Add(search.getInitialState().ToString(), search.getInitialState());
            Solution sol = new Solution();
            Astate goal = search.getGoalState();
            while (queue.Count != 0)
            {
                Astate vertex = queue.Dequeue();
                if (vertex.Equals(goal))
                {
                    sol = backtrack(vertex);
                    break;
                }
                List<Astate> list = search.getAllPossibleStates(vertex);
                foreach (Astate state in list)
                {
                    if (!m_visited.ContainsKey((state as MazeState).currentp.ToString()))
                    {
                        m_visited.Add((state as MazeState).currentp.ToString(), state);
                        queue.Enqueue(state);
                        m_numofnodes++;
                        state.cameFrom = vertex;
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
            while (parent != null)
            {
                sol.addState(parent);
                parent = (MazeState)parent.cameFrom;
            }
            sol.Reverse();
            return sol;
        }
    }
}
