using ATP2016Project.Controller;
using ATP2016Project.Model.Algorithms.Compression;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.Model.View;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model
{
    class MyModel : IModel
    {
        private IController m_controller;

        public MyModel(IController controller)
        {
            m_controller = controller;
        }

        public void GenerateMaze(string mazename, int x, int y, int z)
        {
            if ((m_controller as MyController).mazes.ContainsKey(mazename))
            {
                (m_controller as MyController).M_view.Output("maze name already exists");
                return;
            }
            ArrayList list = new ArrayList();
            list.Add(x);
            list.Add(y);
            list.Add(z);
            MyMaze3dGenerator mg = new MyMaze3dGenerator();
            AMaze maze = mg.generate(list);
            (m_controller as MyController).mazes.Add(mazename, maze);
            (m_controller as MyController).M_view.Output("maze " + mazename + " is ready");
        }

        public void Load(string path, string mazename)
        {
            if ((m_controller as MyController).mazes.ContainsKey(mazename))
            {
                (m_controller as MyController).M_view.Output("maze name already exists");
                return;
            }
            if (!File.Exists(path))
            {
                (m_controller as MyController).M_view.Output("File does not exsits");
                return;
            }
            byte[] todecompress = File.ReadAllBytes(path);
            byte[] buffer = new byte[todecompress[0] * todecompress[1] * todecompress[2] + 3];

            using (FileStream fileInStream = new FileStream(path, FileMode.Open))
            {
                using (Stream inStream = new MyCompressorStream(fileInStream, 2))
                {
                    byte[] mazeBytes = new byte[inStream.Read(buffer, 0, 0)];

                }
            }
            AMaze maze = new Maze3d(buffer);
            (m_controller as MyController).mazes.Add(mazename, maze);

        }

        public void Save(string mazename, string path)
        {
            if (!(m_controller as MyController).mazes.ContainsKey(mazename))
            {
                File.Create(path);
                byte[] comp = ((m_controller as MyController).mazes[mazename] as Maze3d).toByteArray();
                MyMaze3DCompressor dcomp = new MyMaze3DCompressor();
                byte[] tosave = dcomp.compress(comp);
                File.WriteAllBytes(path, tosave);
            }
            else
                (m_controller as MyController).M_view.Output("maze name does not exists");
            return;

        }

        public void Solve(string mazename, string algorithm)
        {
            if (!(m_controller as MyController).mazes.ContainsKey(mazename))
            {
                (m_controller as MyController).M_view.Output("maze name does not exists");
                return;
            }

            SearchableMaze3d sm = new SearchableMaze3d(((m_controller as MyController).mazes[mazename] as Maze3d));
            if (algorithm.ToLower().Equals("bfs"))
            {
                BreadthFirstSearch bs = new BreadthFirstSearch();
                Solution bssol = bs.Solve(sm);
                (m_controller as MyController).bfssolutions.Add(mazename, bssol);
                (m_controller as MyController).M_view.Output("BFS solution for " + mazename + " is ready");
            }
            else if (algorithm.ToLower().Equals("dfs"))
            {
                DepthFirstSearch ds = new DepthFirstSearch();
                Solution dssol = ds.Solve(sm);
                (m_controller as MyController).dfssolutions.Add(mazename, dssol);
                (m_controller as MyController).M_view.Output("DFS solution for " + mazename + " is ready");
            }
            else
                (m_controller as MyController).M_view.Output("Wrong searching algorithm");
        }
    }
}
