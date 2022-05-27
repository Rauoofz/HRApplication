using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public interface IDepartmentService
    {
        IEnumerable<Department> GetDepartments();
        void CreateDepartment(Department department);
        List<Department> GetDepartmentsByName(string name);
        Department GetDepartmentById(int id);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int id);
    }
}
