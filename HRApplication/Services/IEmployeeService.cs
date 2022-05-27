using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public interface IEmployeeService
    {
        void AddEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        List<Employee> GetEmployeeByName(string name);
        void DeleteEmployee(int id);
        Employee GetEmployeeById(int id);
        void UpdateEmployee(Employee employee);
        IQueryable<Employee> GetEmployeesByDepartment(int id);
    }
}
