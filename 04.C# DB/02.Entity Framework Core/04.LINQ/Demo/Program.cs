using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using SoftUniContext context = new SoftUniContext();

            var employeesProjection = await context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.Address.Town.Name
                })
                .ToListAsync();

            List<Employee> employees = await context.Employees
                .Include(e => e.Address)
                .ThenInclude(a => a.Town)
                .ToListAsync();

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.Address.Town.Name}");
            }

            int employeesCount = await context.Employees
                .CountAsync(e => e.DepartmentId == 7);

            Console.WriteLine(employeesCount);

            employeesCount = await context.Employees
                .Where(e => e.DepartmentId == 7)
                .CountAsync();

            Console.WriteLine(employeesCount);

            decimal maxSalaryInDepartment = await context.Employees
                .Where(e => e.DepartmentId == 7)
                .MaxAsync(e => e.Salary);

            Console.WriteLine(maxSalaryInDepartment);

            maxSalaryInDepartment = await context.Employees
                .Where(e => e.Department.Name == "Production")
                .MaxAsync(e => e.Salary);

            Console.WriteLine(maxSalaryInDepartment);

            var joined = await context.Employees
                .Join(
                    context.Departments,
                    e => e.DepartmentId,
                    d => d.DepartmentId,
                    (e, d) => new
                    {
                        e.FirstName,
                        e.LastName,
                        d.Name
                    })
                .ToListAsync();

            joined = await context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Department.Name
                })
                .ToListAsync();

            var grouping = await context.Employees
                .GroupBy(e => e.DepartmentId)
                .ToListAsync();

            var groupingAndSelecting = await context.Employees
                .GroupBy(e => e.DepartmentId)
                .Select(g => new
                {
                    DepartmentId = g.Key,
                    EmployeesCount = g.Count(),
                    AverageSalary = g.Average(e => e.Salary)
                })
                .ToListAsync();

            var groupingAndSelectingNotAnonymous = await context.Employees
                .GroupBy(e => new { e.DepartmentId, e.Department.Name })
                .Select(g => new DepartmentStatistic
                {
                    DepartmentId = g.Key.DepartmentId,
                    DepartmentName = g.Key.Name,
                    EmployeeCount = g.Count(),
                    AverageSalary = g.Average(e => e.Salary)
                })
                .ToListAsync();
        }
    }
}