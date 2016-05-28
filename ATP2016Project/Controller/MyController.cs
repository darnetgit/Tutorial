using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2016Project.Model;
using ATP2016Project.View;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.Model.View;

namespace ATP2016Project.Controller
{
    class MyController : IController
    {
        private Dictionary<string, ACommand> m_commands = new Dictionary<string, ACommand>();
        private IModel m_model;
        private IView m_view;
        private Dictionary<string, AMaze> Mazes = new Dictionary<string, AMaze>();
        private Dictionary<string, Solution> Bfssolutions = new Dictionary<string, Solution>();
        private Dictionary<string, Solution> Dfssolutions = new Dictionary<string, Solution>();

        public Dictionary<string, AMaze> mazes
        {
            get { return Mazes; }
            set { Mazes = value; }
        }
        public Dictionary<string, Solution> bfssolutions
        {
            get { return Bfssolutions; }
            set { Bfssolutions = value; }
        }
        public Dictionary<string, Solution> dfssolutions
        {
            get { return Dfssolutions; }
            set { Dfssolutions = value; }
        }
        public MyController()
        {
            
        }
       public void setcom()
        {
            m_commands["dir"] = new CommandDir(m_model, m_view);
            m_commands["generate3dmaze"] = new CommandGenerate3dMaze(m_model, m_view);
            m_commands["display"] = new CommandDisplay(m_model, m_view);
            m_commands["savemaze"] = new CommandSaveMaze(m_model, m_view);
            m_commands["loadmaze"] = new CommandLoadMaze(m_model, m_view);
            m_commands["mazesize"] = new CommandMazeSize(m_model, m_view);
            m_commands["filesize"] = new CommandFileSize(m_model, m_view);
            m_commands["solvemaze"] = new CommandSolveMaze(m_model, m_view);
            m_commands["displaysolution"] = new CommandDisplaySolution(m_model, m_view);
            
        }

        public Dictionary<string, ACommand> GetCommands()
        {
           
            return m_commands;
        }

        public void SetModel(IModel model)
        {
            m_model = model;
        }

        public void SetView(IView view)
        {
            m_view = view;
        }
        public IModel M_model
        {
            get { return m_model; }
        }

        public IView M_view
        {
            get { return m_view; }
        }
    }
}
