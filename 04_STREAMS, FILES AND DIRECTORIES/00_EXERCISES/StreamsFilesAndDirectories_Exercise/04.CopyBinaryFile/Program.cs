using System;
using System.IO;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using FileStream originalFile = new FileStream("../../../../copyMe.png", FileMode.Open);
            using FileStream copiedlFile = new FileStream("../../../copiedFile.png", FileMode.Create);

            while(true)
            {
                byte[] buffer = new byte[4096];
                int count = originalFile.Read(buffer, 0, buffer.Length);
                if (count == 0)
                {
                    break;
                }

                copiedlFile.Write(buffer);
            }
        }
    }
}
