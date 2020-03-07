using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees;
        public MockEmployeeRepository()
        {
            _employees = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Mary", Department = Department.HR, Email = "mary@pragimtech.com" },
                new Employee() { Id = 2, Name = "John", Department = Department.IT, Email = "john@pragimtech.com" },
                new Employee() { Id = 3, Name = "Sam", Department = Department.Payroll, Email = "sam@pragimtech.com" },
            };
        }
        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAllEmployees ()
        {
            return _employees;
        }
    }
}
