using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            //Getting the first project with Id = 134
            Project? project = await context.Projects
                .FirstOrDefaultAsync(p => p.ProjectId == 134);

            if (project != null)
            {
                project.Description = "New Description";
            }

            await context.SaveChangesAsync();

            //Getting the query as a string
            string query = context.Employees
                .Where(e => e.DepartmentId == 4)
                .OrderBy(e => e.Salary)
                .ToQueryString();

            Console.WriteLine(query);

            //Pages
            List<Employee> employees = new List<Employee>();
            int page = 0;

            do
            {
                page++;
                employees = await context.Employees
                    .OrderBy(e => e.EmployeeId)
                    .Skip((page - 1) * 10)
                    .Take(10)
                    .ToListAsync();

                if (employees.Count > 0)
                {
                    Console.WriteLine($"Page {page}");

                    foreach (Employee e in employees)
                    {
                        Console.WriteLine($"#{e.EmployeeId} {e.FirstName} {e.LastName} - {e.JobTitle}");
                    }

                    Console.WriteLine();
                }
            } while (employees.Count > 0);

            Employee employee = new Employee
            {
                FirstName = "John",
                LastName = "Doe",
                JobTitle = "Software Developer",
                HireDate = DateTime.Now,
                Salary = 60000m,
                DepartmentId = 7,
                Address = new Address
                {
                    AddressText = "123 Main St",
                    TownId = context.Towns.First().TownId
                }
            };

            employee.Projects.Add(new Project
            {
                Name = "New Project",
                StartDate = DateTime.Now
            });

            await context.Employees.AddAsync(employee);
            await context.SaveChangesAsync();

            Project projectEdit = await context.Projects.FindAsync(128);
            projectEdit.Description = "A very cool project, the coolest project there ever was";
            await context.SaveChangesAsync();
        }
    }
}
