using HRApplication.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly Data.AppContext context;

        public EmployeeService(Data.AppContext _context)
        {
            context = _context;
        }
        public void AddEmployee(Employee employee)
        {
            try
            {
                context.employees.Add(employee);
                context.SaveChanges();

            }catch(Exception ex)
            {

            }
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                return context.employees.ToList();

            }catch(Exception ex)
            {
                return null;
            }
        }

        public List<Employee> GetEmployeeByName(string name)
        {
            try
            {

                return context.employees.Where(e => e.FirstName == name).ToList();

            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public void DeleteEmployee(int id)
        {
            try
            {
                Employee employee = context.employees.Find(id);
                context.employees.Remove(employee);
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                
            }
        }

        public Employee GetEmployeeById(int id)
        {
            return context.employees.Where(e=>e.ID==id).FirstOrDefault();

        }

        public void UpdateEmployee(Employee employee)
        {
            context.employees.Attach(employee);
            context.Entry(employee).State = EntityState.Modified;
            context.SaveChanges();
        }

        public IQueryable<Employee> GetEmployeesByDepartment(int id)
        {
            return context.employees.Where(e => e.DepartmentID == id).AsQueryable();
        }
    }
}
