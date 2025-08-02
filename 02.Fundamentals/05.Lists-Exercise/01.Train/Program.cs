namespace _01.Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> train = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacityOfWagon = int.Parse(Console.ReadLine());

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] inputAsArr = input.Split();
                int passengersToAdd = 0;

                if (inputAsArr[0] == "Add")
                {
                    passengersToAdd = int.Parse(inputAsArr[1]);
                    train.Add(passengersToAdd);
                }
                else
                {
                    for (int i = 0; i < train.Count; i++)
                    {
                        passengersToAdd = int.Parse(input); 
                        if ((passengersToAdd + train[i]) <= maxCapacityOfWagon)
                        {
                            train[i] += passengersToAdd;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine(string.Join(" ", train));
        }
    }
}
