using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly Data.AppContext context;

        public DepartmentService(Data.AppContext _context)
        {
            context = _context;
        }


        public IEnumerable<Department> GetDepartments()
        {
            return context.departments.ToList();
        }

        public void CreateDepartment(Department department)
        {
            context.departments.Add(department);
            context.SaveChanges();
        }

        public List<Department> GetDepartmentsByName(string name)
        {
            return context.departments.Where(d => d.Name == name).ToList();
        }

        public Department GetDepartmentById(int id)
        {
            return context.departments.Where(d => d.ID == id).FirstOrDefault();
        }

        public void UpdateDepartment(Department department)
        {
            context.departments.Attach(department);
            context.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            Department department = context.departments.Find(id);
            context.departments.Remove(department);
            context.SaveChanges();
        }

    }
}
