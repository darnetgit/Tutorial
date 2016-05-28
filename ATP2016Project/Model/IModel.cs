using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model
{
    interface IModel
    {
        void GenerateMaze(string mazename, int x, int y, int z);
        void Save(string mazename, string path);
        void Load(string path, string mazename);
        void Solve(string mazename, string algorithm);
        
    }
}
