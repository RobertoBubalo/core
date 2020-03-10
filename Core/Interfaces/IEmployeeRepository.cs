using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee Get(int id);
        Employee Add(Employee employee);
        Employee Update(Employee employee);
        Employee Delete(int id);
        IEnumerable<Employee> GetAll ();
    }
}
