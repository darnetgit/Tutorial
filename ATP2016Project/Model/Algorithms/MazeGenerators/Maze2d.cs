using System;
using System.Collections;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The class Represents 2 dimentional maze.
/// </summary>
namespace ATP2016Project.Model.Algorithms.MazeGenerators
{
    class Maze2d : AMaze
    {
        /// <summary>
        /// The property which holds the maze.
        /// </summary>
        /// <remarks>The maze constructs from two dimintional array of 0s, 1s, 2s, one 3 and one 4.
        /// 0 - represent path, 1 - represent wall, 2 - represent the frame of the maze, 3 - the start of the maze, 4 - the end of the maze.</remarks>
        private int[,] Maze2D;

        /// <summary>
        /// Getter and setter of maze2d.
        /// </summary>
        public int[,] maze2d
        {
            get { return Maze2D; }
            set { Maze2D = value; }
        }

        /// <summary>
        /// The class constructor.
        /// </summary>
        /// <param name="sizes">The sizes of the maze. We build a new array according to the sizes given:
        /// the first node of the Arraylist is the number of the rows in the maze and the second node is the number of the columns.</param>
        public Maze2d(ArrayList sizes):base(sizes)
        {
            maze2d = new int[(int)sizes[0],(int)sizes[1]];
        }

        /// <summary>
        /// The function that prints the maze.
        /// </summary>
        /// <param name="z">The number of the floor we're in.</param>
        /// <remarks>We print every cell - if the cell is 0 - we print "  ", if the cell is 1 - we print purple "  ".
        /// We get the number of the floor for the 3D maze. We save the start and end position of the maze in each floor:
        /// if we are int the last floor, the exit from the maze, z will be -1 and then we print "EN" to the screen, End of the maze.
        /// if we are int the first floor, the enter to the maze, z will be 1 and then we print "ST" to the screen, Start of the maze.</remarks>
        public override void PrintMaze(int z)
        {
            
            for (int row=0; row < maze2d.GetLength(0); row++)
            {
                for(int column=0; column < maze2d.GetLength(1); column++)
                {
                    if (maze2d[row, column] == 1 || maze2d[row, column] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("  ");
                        Console.ResetColor();
                    }
                    else if (maze2d[row, column] == 4 && z == -1)
                        Console.Write("E ");
                    else if (maze2d[row, column] == 3 && z == 1)
                        Console.Write("S ");
                    else Console.Write("  ");
                }
                Console.WriteLine("");
            }
        }

    }
}
