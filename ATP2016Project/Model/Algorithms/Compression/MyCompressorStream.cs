using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//If something went wrong check here!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
namespace ATP2016Project.Model.Algorithms.Compression
{
    class MyCompressorStream: Stream
    {
        private static readonly int m_compress = 1;
        private static readonly int m_decompress = 2;

        private const int m_BufferSize = 100;
        private byte[] m_bytesReadFromStream;
        private Queue<byte> m_queue;
        private MyMaze3DCompressor m_naiveCompressor;

        private Stream m_io;
        private int m_mode;
        public MyCompressorStream(Stream io, int mode)
        {
            this.m_io = io;
            this.m_mode = mode;
            m_bytesReadFromStream = new byte[m_BufferSize];
            m_queue = new Queue<byte>();
            m_naiveCompressor = new MyMaze3DCompressor();
        }

        public static int Compress
        {
            get
            {
                return m_compress;
            }
        }

        public static int Decompress
        {
            get
            {
                return m_decompress;
            }
        }

        public override bool CanRead
        {
            get { return m_io.CanRead; }
        }


        public override bool CanWrite
        {
            get { return m_io.CanWrite; }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            if (m_mode == Compress)
            {
                int r = 0;
                while (m_queue.Count < count && (r = m_io.Read(m_bytesReadFromStream, 0, m_BufferSize)) != 0)
                {
                    byte[] data = new byte[r];
                    for (int i = 0; i < r; data[i] = m_bytesReadFromStream[i], i++) ;
                    byte[] compressed = m_naiveCompressor.compress(data);
                    foreach (byte b in compressed)
                        m_queue.Enqueue(b);
                }
                int bytesCount = Math.Min(m_queue.Count, count);
                for (int i = 0; i < bytesCount; i++)
                    buffer[i + offset] = m_queue.Dequeue();
                return -1;
            }
            else if (m_mode == MyCompressorStream.Decompress)
            {
                // we should read X < Count compressed bytes form the source stream
                // and allow the reader to read COUNT decomprssed bytes from buffer
                // starting from OFFSET index

                int r = 0;
                while (m_queue.Count < count && (r = m_io.Read(m_bytesReadFromStream, 0, m_BufferSize)) != 0)
                {
                    // our source actually contain R bytes and if R<bufferSize then the rest of bytes are leftovers... 
                    // let's cut them
                    byte[] data = new byte[r];
                    for (int i = 0; i < r; data[i] = m_bytesReadFromStream[i], i++) ;

                    byte[] decompressed = m_naiveCompressor.decompress(data);
                    // now, we'll put the decomprssed data in the queue; it is used as a buffer
                    foreach (byte b in decompressed)
                    {
                        m_queue.Enqueue(b);
                    }

                }
                int bytesCount = Math.Min(m_queue.Count, count);

                for (int i = 0; i < bytesCount; i++)
                {
                    buffer[i + offset] = m_queue.Dequeue();
                }
                return bytesCount;
            }
            return 0;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (m_mode == MyCompressorStream.Compress)
            {
                byte[] data = new byte[count];
                for (int i = 0; i < count; data[i] = buffer[i + offset], i++) ;
                byte[] compressed = m_naiveCompressor.compress(data);
                m_io.Write(compressed, 0, compressed.Length);
            }
            else
                if (m_mode == MyCompressorStream.Decompress)
            {
                // do it yourself....
                byte[] data = new byte[count];
                for (int i = 0; i < count; data[i] = buffer[i + offset], i++) ;
                byte[] decompressed = m_naiveCompressor.decompress(data);
                m_io.Write(decompressed, 0, decompressed.Length);
            }
        }

        public override bool CanSeek
        {
            get { return m_io.CanSeek; }
        }

        public override void Flush()
        {
            m_io.Flush();
        }

        public override long Length
        {
            get { throw new NotImplementedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotImplementedException();
        }

        public override void SetLength(long value)
        {
            throw new NotImplementedException();
        }


    }
}
