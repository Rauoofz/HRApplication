using HRApplication.Data;
using HRApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;

        public DepartmentController(IDepartmentService _departmentService)
        {
            departmentService = _departmentService;
        }
        public IActionResult Index()
        {
            Department department = new Department();
            return View("AddDepartment",department);
        }
        [HttpPost]
        public IActionResult CreateDepartment(Department department)
        {
            departmentService.CreateDepartment(department);
            department = new Department();
            return View("AddDepartment",department);
        }

        public IActionResult Department()
        {
            List<Department> departments = new List<Department>();
            return View("DepartmentList",departments);
        }

        public IActionResult GetDepartment()
        {
            string name = Request.Form["Name"];
            List<Department> departments= departmentService.GetDepartmentsByName(name);
            return View("DepartmentList",departments);
        }

        public IActionResult EditDepartment(int id)
        {

            Department department= departmentService.GetDepartmentById(id);

            return View("AddDepartment",department);
        }

        public IActionResult UpdateDepartment(Department department)
        {
            departmentService.UpdateDepartment(department);
            department = new Department();
            return View("AddDepartment",department);
        } 

        public IActionResult DeleteDepartment(int id)
        {
            departmentService.DeleteDepartment(id);
            List<Department> departments = new List<Department>();
            return View("DepartmentList",departments);
        }
    }
}
