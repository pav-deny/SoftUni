using Demo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            //FromSqlRaw - protects from SQL injection
            string query = "SELECT * FROM [Employees] WHERE [FirstName] = @name";
            SqlParameter name = new SqlParameter("@name", "Svetlin");
            var employee = await context.Employees.FromSqlRaw(query, name).ToListAsync();
            Console.WriteLine();

            //FromSqlInterpolated
            string firstName = "'John' OR 1 = 1"; //SQL Injection -> will give all the results of the table
            query = $"SELECT * FROM [Employees] WHERE [FirstName] = {firstName}"; //Not formatable string - helps with SQL injections
            employee = await context.Employees.FromSqlRaw(query).ToListAsync(); //SQL Raw is the problem

            FormattableString queryFormatable = $"SELECT * FROM [Employees] WHERE [FirstName] = {firstName}"; //Protects from SQL injections (DO NOT TOSTRING()!!)
            employee = await context.Employees.FromSqlInterpolated(queryFormatable).ToListAsync();//Protects from SQL injections

            //FromSqlRaw is really easy to get SQL Injected, it's sasfer to use FromSqlInterpolated

            //JOIN-ing, SqlQuery
            FormattableString joinQuery = @$"SELECT 
                d.DepartmentID AS DepartmentId,
                d.Name AS DepartmentName,
                COUNT(e.EmployeeID) AS EmployeeCount,
                AVG(e.Salary) AS AverageSalary
            FROM [Employees] AS e 
            JOIN [Departments] AS d 
            ON e.DepartmentID = d.DepartmentID
            GROUP BY d.DepartmentID, d.Name";

            var joinedTablesOutput = await context.Database.SqlQuery<DepartmentStatistic>(joinQuery).ToListAsync();
            Console.WriteLine();

            //SqlQuery and FromSqlQueryInetrpolated use FormattableString, while FromSqlRaw, uses regular string
            //FromSqlRaw is easier to get SQL Injected

            //BULK Operations
            context.Projects
                .Where(p => p.ProjectId > 128)
                .ExecuteDelete();

            await context.Employees
                .Where(e => e.DepartmentId == 1)
                .ExecuteUpdateAsync(c => c
                    .SetProperty(e => e.Salary, e => e.Salary * 1.1m));

            //Loadings
            List<Employee> emps = new List<Employee>();

            //Explicit Loading
            emps = await context.Employees.ToListAsync();
            foreach (var emp in emps)
            {
                if (emp.FirstName == "John")
                {
                    context.Entry(emp).Reference(e => e.Department).Load();
                    Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Department.Name}");
                }
                else
                {
                    Console.WriteLine($"{emp.FirstName} {emp.LastName}");
                }
            }

            //Eager Loading
            emps = await context.Employees
            .Include(e => e.Department)
            .Include(e => e.Address)
            .ThenInclude(a => a.Town)
            .ToListAsync();

            foreach (var emp in emps)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Department.Name}");
            }

            //Lazy Loading - Requires Microsoft.EntityFrameworkCore.Proxies and enabling in OnConfiguring method in DbContext
            //Creates an N+1 queries problem, as it loads an additional query
            emps = await context.Employees.ToListAsync();

            foreach (var emp in emps)
            {
                Console.WriteLine($"{emp.FirstName} {emp.LastName} - {emp.Department.Name}");
            }
        }
    }
}