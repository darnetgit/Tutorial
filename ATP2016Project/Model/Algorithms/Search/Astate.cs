using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Search
{
    abstract class Astate
    {
        /// <summary>
        /// the abstrace class of state
        /// state- representing the state by string
        /// CameFrom- the state from which we came to this state
        /// </summary>
        private string State;
        private Astate CameFrom;
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="CameFrom"></param>
        public Astate(Astate CameFrom)    
        {
            this.cameFrom = cameFrom;
        }
        /// <summary>
        /// getter and setter for the state as a string
        /// </summary>
        public string state
        {
            get { return State; }
            set { State = value; }
        }

        /// <summary>
        /// getter and setter for parent
        /// </summary>
        public Astate cameFrom
        {
            get { return CameFrom; }
            set { CameFrom = value; }
        }
        /// <summary>
        /// override Object's Equals method
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public abstract bool Equals(Astate state);


    }
}
