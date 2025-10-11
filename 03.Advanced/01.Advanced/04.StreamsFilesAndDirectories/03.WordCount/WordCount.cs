using System.IO;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            using StreamReader wordsReader = new StreamReader(wordsFilePath);

            HashSet<string> words = words = wordsReader.ReadToEnd().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(w => w.ToLower()).ToHashSet();

            Dictionary<string, int> wordCounts = LookForWords(textFilePath, words);

            PrintWordCounts(wordCounts, outputFilePath);
        }

        public static Dictionary<string, int> LookForWords(string textFilePath, HashSet<string> words)
        {
            using StreamReader textReader = new StreamReader(textFilePath);
            Dictionary<string, int> wordCounts = new();
            while (!textReader.EndOfStream)
            {
                string[] currentLine = textReader.ReadLine().ToLower().Split(new[] { ' ', ',', '-', '!', '?', '.' }, StringSplitOptions.RemoveEmptyEntries);
                
                foreach (string word in currentLine)
                {
                    if (words.Contains(word))
                    {
                        if (!wordCounts.ContainsKey(word))
                            wordCounts[word] = 0;

                        wordCounts[word]++;
                    }
                }
            }

            return wordCounts;
        }

        public static void PrintWordCounts(Dictionary<string,int> wordCounts, string outputFilePath)
        {
            using StreamWriter writer = new StreamWriter(outputFilePath);

            foreach ((string word, int count) in wordCounts.OrderByDescending(x => x.Value))
            {
                writer.WriteLine($"{word} - {count}");
            }
        }
    }
}
