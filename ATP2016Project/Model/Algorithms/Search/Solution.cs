using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ATP2016Project.Model.Algorithms.MazeGenerators;

namespace ATP2016Project.Model.Algorithms.Search
{
    /// <summary>
    /// solution class
    /// </summary>
    class Solution
    {
        /// <summary>
        /// consists from an array list 
        /// </summary>
        private ArrayList m_Solu;

        /// <summary>
        /// getter and setter for m_solu
        /// </summary>
        public ArrayList m_solu
        {
            get { return m_Solu; }
            set { m_Solu = value; }
        }

        /// <summary>
        /// constructor
        /// </summary>
        public Solution()
        {
            m_solu = new ArrayList();
        }
        /// <summary>
        /// add a state to the solution 
        /// </summary>
        /// <param name="state"></param>
        public void addState(Astate state)
        {
            m_solu.Add(state);
        }
        /// <summary>
        /// get the number of steps it takes to reach the solution 
        /// </summary>
        /// <returns></returns>
        public int getnumofsteps()
        {
            return m_solu.Count;
        }
        /// <summary>
        /// get the path that the solution is made of
        /// </summary>
        /// <returns></returns>
        public ArrayList getsolpath()
        {
            return m_solu;
        }
        /// <summary>
        /// reverse the arraylist that is the list of states that assmble the solution
        /// </summary>
        public void Reverse()
        {
            m_solu.Reverse();
        }

        public void PrintSolution()
        {
            foreach (Astate position in m_Solu)
                Console.WriteLine(position.state);
        }
    }
}
