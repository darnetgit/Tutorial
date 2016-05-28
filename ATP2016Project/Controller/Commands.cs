using ATP2016Project.Model;
using ATP2016Project.Model.Algorithms.Compression;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Controller
{
    class CommandDir : ACommand
    {
        public CommandDir( IModel model,  IView view) : base( model,  view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_view.dir(parameters[1]);

        }
        public override string GetName()
        {
            return "dir";
        }
    }
    
    class CommandGenerate3dMaze : ACommand
    {
        public CommandGenerate3dMaze(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 5)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            int x, y, z;
            if (Int32.TryParse(parameters[2], out x) && Int32.TryParse(parameters[3], out y) && Int32.TryParse(parameters[4], out z))
                m_model.GenerateMaze(parameters[1], x, y, z);
            else
                m_view.Output("wrong parameters entered");
        }

        public override string GetName()
        {
            return "generate";
        }
    }

    class CommandDisplay : ACommand
    {
        public CommandDisplay(IModel model, IView view) : base(model, view) { }

        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_view.DisplayMaze(parameters[1]);
        }

        public override string GetName()
        {
            return "DisplayMaze";
        }
    }

    class CommandSaveMaze : ACommand
    {
        public CommandSaveMaze(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 3)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }

            try
            {
                if (File.Exists(parameters[2]))
                {
                    m_view.Output("a maze already exists in this path");
                    return;
                }
                m_model.Solve(parameters[1], parameters[2]);
            }
            catch (Exception e)
            {
                m_view.Output("process failed due to " + e.ToString());
            }
            finally { }
        }


        public override string GetName()
        {
            return "Save";
        }
    }

    class CommandLoadMaze : ACommand
    {
        public CommandLoadMaze(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 3)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_model.Load(parameters[1], parameters[2]);
        }

        public override string GetName()
        {
            return "Load";
        }
    }

    class CommandMazeSize : ACommand
    {
        public CommandMazeSize(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_view.MazeSize(parameters[1]);
        }

        public override string GetName()
        {
            return "MazeSize";
        }
    }

    class CommandFileSize : ACommand
    {
        public CommandFileSize(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            m_view.FileSize(parameters[1]);
        }

        public override string GetName()
        {
            return "FileSize";
        }
    }

    class CommandSolveMaze : ACommand
    {
        public CommandSolveMaze(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 3)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_model.Solve(parameters[1], parameters[2]);
        }

        public override string GetName()
        {
            return "Solve";
        }
    }

    class CommandDisplaySolution : ACommand
    {
        public CommandDisplaySolution(IModel model, IView view) : base(model, view) { }
        public override void DoCommand(params string[] parameters)
        {
            if (parameters.Length != 2)
            {
                m_view.Output("Wrong number of parameters!");
                return;
            }
            m_view.DisplaySolution(parameters[1]);
        }

        public override string GetName()
        {
            return "DisplaySolution";
        }
    }
    
}
