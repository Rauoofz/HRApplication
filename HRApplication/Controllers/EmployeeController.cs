using HRApplication.Data;
using HRApplication.Models;
using HRApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Controllers
{
    [Authorize(Roles ="Admin")]
    public class EmployeeController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly IEmployeeService employeeService;
        private readonly ICountryService countryService;
        private readonly IDepartmentService departmentService;
        private readonly ICityService cityService;

        public EmployeeController(IConfiguration _configuration,IEmployeeService _employeeService,ICountryService _countryService,IDepartmentService _departmentService,ICityService _cityService)
        {
            configuration = _configuration;
            employeeService = _employeeService;
            countryService = _countryService;
            departmentService = _departmentService;
            cityService = _cityService;
        }
        public IActionResult Index()
        {
            VmCompany vm = new VmCompany();
            vm.cities = cityService.GetCities();
            vm.countries = countryService.GetAllCountry();
            vm.departments = departmentService.GetDepartments();
            vm.employee = new Employee();
            return View("Add_Employee",vm);
        }

        public IActionResult CreateEmployee(VmCompany vm)
        {
            vm.cities = cityService.GetCities();
            vm.departments = departmentService.GetDepartments();
            vm.countries = countryService.GetAllCountry();

            string path = Path.Combine(Directory.GetCurrentDirectory(), configuration["FilePath"], vm.employee.Image.FileName);
            vm.employee.Image.CopyTo(new FileStream(path, FileMode.Create));
            vm.employee.Path= Path.Combine("http://localhost/HRApplication/img/",vm.employee.Image.FileName);

            employeeService.AddEmployee(vm.employee);

            vm.employee = new Employee();

            return View("Add_Employee",vm);
        }

        public IActionResult Employees()
        {
            IEnumerable<Employee> employees = employeeService.GetEmployees();

            return View("EmployeeList",employees);
        }

        public IActionResult GetEmployee()
        {
            string name = Request.Form["Name"];

            List<Employee> employees = employeeService.GetEmployeeByName(name);

            return View("EmployeeList",employees);
        }

        public IActionResult DeleteEmployee(int id)
        {

            IEnumerable<Employee> employees = employeeService.GetEmployees();
            employeeService.DeleteEmployee(id);

            return View("EmployeeList",employees);
        }

        public IActionResult EditEmployee(int id)
        {

            Employee emp = employeeService.GetEmployeeById(id);
            VmCompany vm = new VmCompany();
            vm.cities = cityService.GetCities();
            vm.countries = countryService.GetAllCountry();
            vm.departments = departmentService.GetDepartments();
            vm.employee = emp;
            return View("Add_Employee",vm);
        }

        public IActionResult UpdateEmployee(VmCompany vm)
        {

            employeeService.UpdateEmployee(vm.employee);
            vm.cities = cityService.GetCities();
            vm.countries = countryService.GetAllCountry();
            vm.departments = departmentService.GetDepartments();
            vm.employee = new Employee();
            return View("Add_Employee", vm);
        }

        public IActionResult GetEmployeesByDepartment(int id)
        {
            List<Employee> employees = employeeService.GetEmployeesByDepartment(id).ToList();
            return View("EmployeeList",employees);
        }



    }
}
