using System.Text;

namespace _07.StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            string result = ProcessExplosion(str);

            Console.WriteLine(result);
        }

        static string ProcessExplosion(string str)
        {
            StringBuilder result = new();
            int explosionStrength = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '>')
                {
                    explosionStrength += int.Parse(str[i + 1].ToString());
                    result.Append(str[i]);
                }
                else if (explosionStrength == 0)
                {
                    result.Append(str[i]);
                }
                else
                {
                    explosionStrength--;
                }
            }

            return result.ToString();
        }
    }
}
