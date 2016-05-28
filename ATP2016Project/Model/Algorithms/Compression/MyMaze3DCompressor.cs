
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Compression
{
    class MyMaze3DCompressor : ICompressor
    {
        public byte[] compress(byte[] data)
        {
            List<byte> compressed = new List<byte>();
            int i = 0;
            while (i < data.Length)
            {
                byte b = data[i]; // current data
                compressed.Add(b); // put it in
                i++;
                // how many times it appears continuously?
                byte count = 0;
                while (i < data.Length && data[i] == b && count < byte.MaxValue)
                {
                    count++;
                    i++;
                }
                // write that count;
                compressed.Add(count);
            }
            // return the compressed array
            /*for (int p = 0; p < compressed.Count; p++)
            {
                Console.WriteLine(compressed[p]);
            }
            */
            Console.WriteLine("size of not comprresed array: " + data.Length);
            Console.WriteLine("size of comprresed array: " + compressed.Count);
            return compressed.ToArray();
        }

        public byte[] decompress(byte[] data)
        {
            List<byte> decompressed = new List<byte>();
            int i = 0;
            while (i < data.Length)
            {
                byte b = data[i];
                decompressed.Add(b);
                i++;
                for (int j = 0; i < data.Length && j < data[i]; decompressed.Add(b), j++) ;
                i++;
            }
            Console.WriteLine("size of not comprresed array: " + decompressed.Count());
            Console.WriteLine("size of comprresed array: " + data.Count());
            return decompressed.ToArray();
            throw new NotImplementedException();
        }
    }
}
