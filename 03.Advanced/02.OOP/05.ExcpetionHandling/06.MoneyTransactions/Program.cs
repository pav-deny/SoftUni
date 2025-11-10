namespace _06.MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);
            Dictionary<int, double> accountsBalances = new();

            foreach (string acc in data)
            {
                string[] accData = acc.Split('-');

                int accountNumber = int.Parse(accData[0]);
                double accountBalance = double.Parse(accData[1]);

                accountsBalances.Add(accountNumber, accountBalance);
            }

            string query = string.Empty;
            while ((query = Console.ReadLine()) != "End")
            {
                string[] queryData = query.Split(' ');

                try
                {
                    string action = queryData[0];
                    int account = int.Parse(queryData[1]);
                    double sum = double.Parse(queryData[2]);

                    Func<int, double, double> innactQuery = null;

                    if (action == "Deposit")
                    {
                        innactQuery = (a, s) => accountsBalances[a] + s; 
                    }
                    else if (action == "Withdraw")
                    {
                        innactQuery = (a, s) => accountsBalances[a] - s;
                    }
                    else
                        throw new ArgumentException("Invalid command!");


                    if (!accountsBalances.ContainsKey(account))
                        throw new ArgumentException("Invalid account!");

                    double result = innactQuery(account, sum);

                    if (result < 0 && action == "Withdraw")
                        throw new ArgumentException("Insufficient balance!");

                    accountsBalances[account] = result;
                    Console.WriteLine($"Account {account} has new balance: {accountsBalances[account]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
            }
        }
    }
}
