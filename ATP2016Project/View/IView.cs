using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.View
{
    interface IView
    {
        void Start();
        void Output(string output);
        void DisplayMaze(string mazename);
        void MazeSize(string mazename);
        void FileSize(string path);
        void DisplaySolution(string mazename);
        void dir(string path);
    }
}
