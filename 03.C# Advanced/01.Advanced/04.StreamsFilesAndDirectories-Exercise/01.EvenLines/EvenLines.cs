namespace EvenLines
{
    using System;
    using System.Text;

    public class EvenLines
    {
        private static char[] CharsToReplace = ['-', ',', '.', '!', '?'];

        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)  
        {
            using StreamReader reader = new(inputFilePath);

            bool isEven = true;
            StringBuilder sb = new();

            while (!reader.EndOfStream)
            {
                string currentLine = reader.ReadLine();

                if (isEven)
                {
                    sb.AppendLine(Format(currentLine));
                }

                isEven = !isEven;
            }

            return sb.ToString();
        }

        private static string Format(string line)
        {
            string[] words = line.Split();

            for (int i = 0; i < words.Length; i++)
            {
                for(int j = 0; j < CharsToReplace.Length; j++)
                {
                    words[i] = words[i].Replace(CharsToReplace[j], '@');
                }
            }

           return string.Join(" ", words.Reverse());
        }
    }
}

