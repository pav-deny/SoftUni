using Microsoft.Data.SqlClient;
using System.Data;

namespace Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string salaryTreshold = Console.ReadLine();

            //Encrypt = False; = Do not use SSL/TLS Encryption 
            string connectionString = @"Server=DENI-PC\SQLEXPRESS;Database=SoftUni;Trusted_Connection=True;Encrypt=False;";
            using SqlConnection sqlConnection = new SqlConnection(connectionString);

            sqlConnection.Open();

            string query = @"SELECT CONCAT(FirstName, ' ', LastName) AS FullName,
		JobTitle,
		Salary
	FROM Employees
	WHERE Salary > @salaryTreshold";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlParameter salaryParameter = new SqlParameter("@salaryTreshold", SqlDbType.Decimal);
            salaryParameter.Value = decimal.Parse(salaryTreshold);

            command.Parameters.Add(salaryParameter);
            using SqlDataReader reader = command.ExecuteReader();
            int i = 1;

            while (reader.Read())
            {
                string fullName = reader.GetString(0);
                string jobTitle = reader.GetString(1);
                decimal salary = reader.GetDecimal(2);

                Console.WriteLine($"#{i} {fullName} - {jobTitle} (${salary})");
                i++;
            }

            reader.Close();
            sqlConnection.Close();
        }
    }
}
