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
        public Employee Get(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Employee> GetAll ()
        {
            return _employees;
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
            return employee;
        }

        public Employee Update(Employee employee)
        {
            var _employee = _employees.FirstOrDefault(e => e.Id == employee.Id);
            if(_employee != null)
            {
                _employee = employee;
            }
            return _employee;
        }

        public Employee Delete(int id)
        {
            var _employee = _employees.FirstOrDefault(e => e.Id == id);
            if(_employee != null)
            {
                _employees.Remove(_employee);
            }
            return _employee;
        }
    }
}
