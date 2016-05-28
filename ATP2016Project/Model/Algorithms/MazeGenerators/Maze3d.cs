using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The class Represents 3 dimentional maze.
/// </summary>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    class Maze3d : AMaze
    {
        /// <summary>
        /// The property which holds the maze.
        /// </summary>
        /// <remarks>The maze constructs from one dimintional array of maze2d.</remarks>
        private Maze2d[] Maze3D;

        /// <summary>
        /// Getter and setter of maze2d.
        /// </summary>
        public Maze2d[] maze3d
        {
            get { return Maze3D; }
            set { Maze3D = value; }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="sizes">The sizes of the maze. We build a new array according to the sizes given:
        /// the first node of the Arraylist is the number of the rows in the maze, the second node is the number of the columns
        /// and the third node is the number of the floors (except the 1 floor - which all consists of walls, and the last that consists from one 
        /// except the end).</param>
        public Maze3d(ArrayList sizes):base(sizes)
        {
            ArrayList news = new ArrayList();
            news.Add(sizes[0]);
            news.Add(sizes[1]);
            maze3d = new Maze2d[(int)sizes[2]+2];
            for (int i = 0; i < maze3d.Length; i++)
                maze3d[i] = new Maze2d(news);
        }
        /// <summary>
        /// this constractor will recive an array of byte and transform them into a 3d array (decompress)
        /// </summary>
        /// <param name="todecompress"></param>
        public Maze3d(byte[] todecompress):base(new ArrayList(3))
        {
            sizes.Add(Convert.ToInt32(todecompress[0]));
            sizes.Add(Convert.ToInt32(todecompress[1]));
            sizes.Add(Convert.ToInt32(todecompress[2]));
            
            int count = 3;

            ArrayList news = new ArrayList();
            news.Add(sizes[0]);
            news.Add(sizes[1]);
            maze3d = new Maze2d[(int)sizes[2]];
            for (int i = 0; i < maze3d.Length; i++)
                maze3d[i] = new Maze2d(news);

            for (int i = 0; i < maze3d.Length; i++)
            {
                for (int j = 0; j < (int)sizes[1]; j++)
                {
                    for (int k = 0; k < (int)sizes[0]; k++)
                    {
                        
                        this.maze3d[i].maze2d[j,k] = Convert.ToInt32(todecompress[count]);
                        if (maze3d[i].maze2d[j, k] == 3)
                            start = new Position(j, k, i);
                        if (maze3d[i].maze2d[j, k] == 4 && i== (maze3d.Length) -1)
                            end = new Position(j, k, i);
                        if ((j == (int)sizes[0] - 1 || j == 0 || k == (int)sizes[1] - 1 || k == 0) && maze3d[i].maze2d[j, k]!=0)
                            maze3d[i].maze2d[j, k] = 2;
                        count++;
                    }
                }
            }
           // Print();
        }
        /// <summary>
        /// The function that prints the maze.
        /// </summary>
        /// <param name="z">The number of the floor we're in.</param>
        /// <remarks>We print each floor as a 2D maze. the parameter z is not used in here, we nedded it for
        /// send to the 2D print maze which floor we are printing now.</remarks>
        public override void PrintMaze(int z)
        {
            for (int floor = 0; floor < maze3d.Length; floor++)
            {
                if(floor == maze3d.Length-1)
                    maze3d[floor].PrintMaze(-1);
                else
                    maze3d[floor].PrintMaze(floor);
                Console.WriteLine();
            }
        }
        /// <summary>
        /// this method will transform the maze into a byte array
        /// </summary>
        /// <returns></returns>
        public byte[] toByteArray()
        {
            byte[] ans = new byte[(int)sizes[0]*(int)sizes[1]*((int)sizes[2]+2)+3];
            ans[0] = Convert.ToByte((int)sizes[0]);
            ans[1] = Convert.ToByte((int)sizes[1]);
            ans[2] = Convert.ToByte((int)sizes[2]+2);
            int count = 3;
            for (int i = 0; i < (int)sizes[2]+2; i++)
            {
                for (int j = 0; j < (int)sizes[1]; j++)
                { 
                    for (int k = 0; k < (int)sizes[0]; k++)
                    {
                        ans[count] = Convert.ToByte(maze3d[i].maze2d[j, k]);
                        if (ans[count] == 2)
                            ans[count] = Convert.ToByte(1);
                        //Console.Write(ans[count]);
                        count++;
                    }
                    //Console.WriteLine();
                }
            }
            return ans;
        }
    }
}
