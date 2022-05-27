using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRApplication.Data
{
    public class Employee
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }
        public double ExpactedSalary { get; set; }
        public DateTime HireDate { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Path { get; set; }
        public string Gender { get; set; }
        [ForeignKey("department")]
        public int DepartmentID { get; set; }
        [ForeignKey("country")]
        public int CountryID { get; set; }
        [ForeignKey("city")]
        public int CityID { get; set; }
        public Department department { get; set; }
        public Country country { get; set; }
        public City city { get; set; }
    }
}
