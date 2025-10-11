using System.Text;

namespace _00.Demos2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using FileStream fs = new("log.bin", FileMode.Create);//Creates a new file log.bin

            byte[] buffer = Encoding.UTF8.GetBytes("C# Advanced - Files");//saves the text as byte[]

            fs.Write(buffer, 0, buffer.Length);//Writes it
            fs.Close();//Closes fs

            using FileStream fs2 = new("log.bin", FileMode.Open);//Creates a new FileStream
            
            byte[] buffer2 = new byte[11];//Creates a buffer to store the result

            fs2.Read(buffer2, 0, 11);//Reads it

            string notFullResult = Encoding.UTF8.GetString(buffer2);//Saves it as string

            Console.WriteLine(notFullResult);//Writes it

            fs2.Seek(0, SeekOrigin.Begin);//Returns to the start

            byte[] buffer3 = new byte[fs2.Length];//Creates a new buffer to store the result

            fs2.Read(buffer3, 0, buffer.Length);//Reads it

            string fullResult = Encoding.UTF8.GetString(buffer3);//Saves it as string

            Console.WriteLine(fullResult);//Writes it
        }
    }
}
