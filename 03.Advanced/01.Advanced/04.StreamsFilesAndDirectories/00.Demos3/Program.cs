namespace _00.Demos3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int originalNum = 4857;
            int secretNum = 2370;

            int encrypted = originalNum ^ secretNum;

            Console.WriteLine(encrypted);

            int decrypted = encrypted ^ secretNum;

            Console.WriteLine(decrypted);

            byte[] byteContents = File.ReadAllBytes("example.png");

            byte password = 187;

            for (int i = 0; i < byteContents.Length; i++)
            {
                byteContents[i] = (byte)(byteContents[i] ^ password);
            }

            File.WriteAllBytes("exampleEncrypted.png", byteContents);

            byte[] byteContents2 = File.ReadAllBytes("exampleEncrypted.png");

            for (int i = 0; i < byteContents2.Length; i++)
            {
                byteContents2[i] = (byte)(byteContents2[i] ^ password);
            }

            File.WriteAllBytes("exampleDecrypted.png", byteContents2);

        }
    }
}
