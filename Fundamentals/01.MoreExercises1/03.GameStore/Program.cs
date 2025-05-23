using System.Reflection;

namespace _03.GameStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*OutFall 4                 $39.99
            CS: OG                      $15.99
            Zplinter Zell	            $19.99
            Honored 2                   $59.99
            RoverWatch                  $29.99
            RoverWatch Origins Edition  $39.99*/

            float balance = float.Parse(Console.ReadLine());
            float total = 0f;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Game Time")
            {
                {
                    float price = 0f;
                    bool isTooExpensive = false;
                    switch (input)
                    {
                        case "OutFall 4":
                            price = 39.99f;
                            IsTooExpensive(price, false, balance);
                            Console.WriteLine(isTooExpensive);
                            break;
                    }
                }
            }
            static bool IsTooExpensive(float price, bool isTooExpensive, float balance)
            {
                if ((balance - price) < 0)
                {
                    isTooExpensive = true;
                }
                else
                {
                    isTooExpensive = false;
                }
                return isTooExpensive;
            }
        }
    }
}
