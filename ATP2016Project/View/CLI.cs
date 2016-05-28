using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.View
{
    class CLI : IView
    {
        private IController m_controller;
        private Stream m_input = Console.OpenStandardInput();
        private Stream m_output = Console.OpenStandardOutput();
        private string m_cursor = ">>";
        private Dictionary<string, ACommand> m_commands;
        public CLI(IController controller, Dictionary<string, ACommand> com)
        {
            m_controller = controller;
            m_commands = com;
        }

        public void Start()
        {
            Console.WriteLine("Command started!\n");
            PrintInstructions();
            string userCommand;
            string[] splitCommand;
            string command;
            while (true)
            {
                Output("");
                //Console.Write(">>");
                userCommand = Input().Trim();
                if (userCommand == "Exit")
                    break;
                splitCommand = userCommand.Split(' ');
                command = splitCommand[0].Trim();
                if (!m_commands.ContainsKey(command.ToLower()))
                    Output("Unrecognized command!");
                else
                    m_commands[command.ToLower()].DoCommand(splitCommand);
            }
        }
        private void PrintInstructions()
        {
            string instructions = "To choose a command please write the name of the command and fill the parameters instead of the <> \n \n";
            instructions = instructions + "Dir <path>\nGenerate3dMaze <maze name> <num of lines> <num of columns> <num of floors>\n";
            instructions = instructions + "Display <maze name>\nSaveMaze <maze name> <file path>\nLoadMaze <file path> <maze name>\n";
            instructions = instructions + "MazeSize <maze name>\nFileSize <file path>\nSolveMaze <maze name> <BFS/DFS>\nDisplaySolution <maze name>\n \n";
            instructions = instructions + "Enter Exit to exit the program";
            Output(instructions);
        }
        public void Output(string output)
        {
            //throw new NotImplementedException();
            //Console.ForegroundColor = ConsoleColor.Yellow;
            StreamWriter streamWriter = new StreamWriter(m_output);
            streamWriter.AutoFlush = true;
            Console.SetCursorPosition(0, Console.CursorTop);
            streamWriter.WriteLine(output);
            streamWriter.WriteLine("");
            streamWriter.Write(m_cursor);
            Console.ResetColor();
        }
        public string Input()
        {
            StreamReader streamreader = new StreamReader(m_input);
            return streamreader.ReadLine();
        }

        public void DisplayMaze(string mazename)
        {
            AMaze maze;
            (m_controller as MyController).mazes.TryGetValue(mazename, out maze);
            if (maze != null)
                maze.Print();
            else
                Output("no maze exists with the given name");
        }

        public void MazeSize(string mazename)
        {
            if (!(m_controller as MyController).mazes.ContainsKey(mazename))
            {
                Output("maze name does not exists");
                return;
            }
            byte[] comp = ((m_controller as MyController).mazes[mazename] as Maze3d).toByteArray();
            //Console.WriteLine(comp.Length);
            Output(Convert.ToString(comp.Length));
        }

        public void FileSize(string path)
        {
            if (!File.Exists(path))
            {
                Output("File does not exsits");
                return;
            }
            FileInfo f = new FileInfo(path);
            long l = f.Length;
            Output(Convert.ToString(l) + " bytes");
        }

        public void DisplaySolution(string mazename)
        {
            if (!(m_controller as MyController).bfssolutions.ContainsKey(mazename) && !(m_controller as MyController).dfssolutions.ContainsKey(mazename))
            {
                Output("Solution for maze " + mazename + " does not exist");
                return;
            }
            if ((m_controller as MyController).bfssolutions.ContainsKey(mazename))
            {
                //(m_controller as MyController).bfssolutions[mazename].PrintSolution();
                string solution = "";
                foreach (Astate position in (m_controller as MyController).bfssolutions[mazename].m_solu)
                {
                    //Console.WriteLine(position.state);
                    //Console.WriteLine(solution);
                    solution = solution + position.state + " \n";
                }
                //Console.Write(solution);
                Output("BFS solution: \n" + solution);
            }
            if ((m_controller as MyController).dfssolutions.ContainsKey(mazename))
            {
                string solution = "";
                foreach (Astate position in (m_controller as MyController).dfssolutions[mazename].m_solu)
                    solution = solution + position.state + "\n";
               // Console.Write(solution);
                Output("DFS solution: \n" + solution);
            }
        }

        public void dir(string path)
        {
            if (Directory.Exists(path))
            {
                string[] allfiles = Directory.GetFiles(path);
                string[] alldirs = Directory.GetDirectories(path);
                string allfilesasstring = "";
                foreach (string filename in allfiles)
                    allfilesasstring = allfilesasstring + filename + "\n";
                foreach (string dirname in alldirs)
                    allfilesasstring = allfilesasstring + dirname + "\n";
                Output(allfilesasstring);
            }
            else
                Output(path + " is not a valid directory");

        }
    }
}
