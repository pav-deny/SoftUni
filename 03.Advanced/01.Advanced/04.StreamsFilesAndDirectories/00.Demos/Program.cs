using System;
using System.IO;
using System.Text;

namespace _00.Demos
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            MemoryStream memory = new(); //Creates a new MemoryStream /will read/write to RAM/

            string text = "Deny Pavlov";//What we will write

            byte[] textBytes = Encoding.UTF8.GetBytes(text);//Encoding it to byte[]

            memory.Write(textBytes, 0, textBytes.Length);//Writing it
            memory.Flush();//Flushing it

            memory.Seek(0, SeekOrigin.Begin);//Returning back to the start


            byte[] buffer = new byte[memory.Length]; //Creates a buffer to save the read stuff

            memory.Read(buffer, 0, buffer.Length);//Reads it

            Console.WriteLine(Encoding.UTF8.GetString(buffer, 0, buffer.Length));//Writes it and it encodes it back to a string

        }
    }
}
