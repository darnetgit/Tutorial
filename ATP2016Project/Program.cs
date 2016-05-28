using ATP2016Project.Controller;
using ATP2016Project.Model;
using ATP2016Project.Model.Algorithms.Compression;
using ATP2016Project.Model.Algorithms.MazeGenerators;
using ATP2016Project.Model.Algorithms.Search;
using ATP2016Project.Model.View;
using ATP2016Project.View;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project
{

    class Program
    {
        static void Main(string[] args)
        {
            //testMaze2dGenerator(new SimpleMaze2dGenerator());
            //testMeze3dGenerator(new MyMaze3dGenerator());
            //testSearchAlgorithms();
            //TestNaiveCompressorStream();
            testnewshit();
            Console.ReadKey();

        }

        private static void testnewshit()
        {
            IController controller = new MyController();
            IModel model = new MyModel(controller);
            controller.SetModel(model);
            IView view = new CLI(controller, controller.GetCommands());
            controller.SetView(view);
            (controller as MyController).setcom();
            view.Start();
        }

        private static void testSearchAlgorithms()
        {
            ArrayList s = new ArrayList();
            s.Add(5);
            s.Add(5);
            s.Add(4);
            MyMaze3dGenerator mg = new MyMaze3dGenerator();
            AMaze maze = mg.generate(s);
            maze.Print();
            Console.WriteLine("DFS solution path:");
            SearchableMaze3d sm = new SearchableMaze3d((maze as Maze3d));
            DepthFirstSearch ds = new DepthFirstSearch();
            Solution dssol = ds.Solve(sm);
            dssol.PrintSolution();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("for BFS solution press any key");
            Console.ReadKey();
            Console.WriteLine("BFS solution path:");
            BreadthFirstSearch bs = new BreadthFirstSearch();
            Solution bssol = bs.Solve(sm);
            bssol.PrintSolution();
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("for further information about DFS solution press any key");
            Console.ReadKey();
            Console.WriteLine("num of nodes developed in DFS: " + ds.getNumberOfNodes());
            Console.WriteLine("time it took to find solution(ms) in DFS: " + ds.GetSolvingTime());
            Console.WriteLine();
            Console.WriteLine("for further information about BFS solution press any key");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine("num of nodes developed in BFS: " + bs.getNumberOfNodes());
            Console.WriteLine("time it took to find solution(ms) in BFS: " + bs.GetSolvingTime());
        }

        private static void testMeze3dGenerator(MyMaze3dGenerator mg)
        {
            ArrayList s = new ArrayList();

            s.Add(20);
            s.Add(20);
            s.Add(4);

            Console.WriteLine(mg.MeasureAlgorithmTime(s));
            AMaze maze = mg.generate(s);
            Position start = maze.getStartPosition();
            start.print();
            maze.getGoalPosition().print();
            maze.Print();
            byte[] dar = (maze as Maze3d).toByteArray();
            Maze3d hara = new Maze3d(dar);
            ICompressor car = new MyMaze3DCompressor();

            byte[] hara1 = car.compress(dar);
            byte[] hara2 = car.decompress(hara1);
            Maze3d hara3 = new Maze3d(hara2);
            hara3.Print();


            /*using (FileStream fileOutStream = new FileStream("1.maze", FileMode.Create))
            {
                using (Stream outStream = new MyCompressorStream(fileOutStream, 1))
                {
                    outStream.Write((maze as Maze3d).toByteArray(),0,1);
                    outStream.Flush();
                }
            }
            byte[] mazeBytes;
            using (FileStream fileInStream = new FileStream("1.maze", FileMode.Open))
            {
                using (Stream inStream = new MyCompressorStream(fileInStream,1))
                {
                    mazeBytes = new byte[(maze as Maze3d).toByteArray().Count()];
                    input.read(b);
                }
            }
            Maze3d loadedMaze = new Maze3d(mazeBytes);
            System.out.println(loaded.equals(maze));*/




            Console.ReadKey();
        }

        private static void TestNaiveCompressorStream()
        {
            printCaption("Test - Naive Compressor Stream");

            string originalFilePath = @"D:\bart.txt";
            string compressedFilePath = @"D:\bart_Compressed.txt";
            string decompressedFilePath = @"D:\bart_Decompressed.txt";
            Console.WriteLine("Source file path: {0}", originalFilePath);

            CompressFile(originalFilePath, compressedFilePath);
            Console.WriteLine("Compressed file path: {0}", compressedFilePath);

            DecompressFile(compressedFilePath, decompressedFilePath);
            Console.WriteLine("Decompressed file path: {0}", decompressedFilePath);
        }


        private static void CompressFile(string originalFilePath, string compressedFilePath)
        {
            //Compress bart.txt => bart_compressed.txt
            using (FileStream originalFileStream = new FileStream(originalFilePath, FileMode.Open))
            {
                using (FileStream compressedFileStream = new FileStream(compressedFilePath, FileMode.CreateNew))
                {
                    using (MyCompressorStream myCompressorStream = new MyCompressorStream(compressedFileStream, MyCompressorStream.Compress))
                    {
                        //Read original bart
                        byte[] buffer = new byte[50];
                        int r = 0;
                        while ((r = originalFileStream.Read(buffer, 0, buffer.Length)) != 0)
                        {
                            myCompressorStream.Write(buffer, 0, r);
                        }
                    }
                }
            }
        }

        private static void DecompressFile(string compressedFilePath, string decompressedFilePath)
        {
            // decompress bart_compressed.txt => bart_decompressed.txt
            using (FileStream compressesFileStream = new FileStream(compressedFilePath, FileMode.Open))
            {
                using (FileStream decompressedFileStream = new FileStream(decompressedFilePath, FileMode.Create))
                {
                    using (MyCompressorStream myCompressorStream = new MyCompressorStream(compressesFileStream, MyCompressorStream.Decompress))
                    {
                        byte[] data = new byte[100];
                        int r = 0;
                        while ((r = myCompressorStream.Read(data, 0, 100)) != 0)
                        {
                            decompressedFileStream.Write(data, 0, data.Length);
                        }
                    }
                }
            }
        }

        private static void testMaze2dGenerator(SimpleMaze2dGenerator mg)
        {
            ArrayList sizes = new ArrayList();

            sizes.Add(30);
            sizes.Add(30);

            Console.WriteLine(mg.MeasureAlgorithmTime(sizes));
            AMaze maze = mg.generate(sizes);
            Position start = maze.getStartPosition();
            start.print();
            maze.getGoalPosition().print();
            maze.Print();

            Console.ReadKey();
        }
        private static void printCaption(string caption)
        {
            Console.WriteLine("");
            Console.WriteLine(caption);
            Console.WriteLine("**************************");
        }
    }
}