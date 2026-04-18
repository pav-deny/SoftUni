namespace _07.CompanyUsers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Company> companiesMap = new();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] companyData = input.Split(" -> ");

                string name = companyData[0];
                string id = companyData[1];

                if (!companiesMap.ContainsKey(name))
                {
                    companiesMap.Add(name, new Company(name));
                }

                bool isUniqueId = companiesMap[name].CheckIfUniqueId(id);

                if (isUniqueId)
                {
                    companiesMap[name].EmployeesIds.Add(id);
                }
            }

            foreach(KeyValuePair<string, Company> pair  in companiesMap)
            {
                Console.WriteLine(pair.Key);
                Console.WriteLine(pair.Value.PrintEmployees());
            }
        }
    }

    public class Company
    {
        public string Name { get; set; }

        public List<string> EmployeesIds { get; set; }

        public Company(string name)
        {
            EmployeesIds = new();
            Name = name;
        }

        public bool CheckIfUniqueId(string id)
        {
            if (EmployeesIds.Contains(id))
            {
                return false;
            }

            return true;
        }

        public string PrintEmployees()
        {
            string result = $"";

            foreach (string id in EmployeesIds)
            {
                result += $"-- {id}\n";
            }

            return result.Trim();
        }
    }
}
