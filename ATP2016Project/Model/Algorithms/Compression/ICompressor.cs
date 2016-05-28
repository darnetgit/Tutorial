using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATP2016Project.Model.Algorithms.Compression
{
    interface ICompressor
    {
        /// <summary>
        /// this method will compress a given byte array and will produce a smaller sizes array
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] compress(byte[] data);
        /// <summary>
        /// this method will decompress a given byte array to it's original size
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        byte[] decompress(byte[] data);
    }
}
