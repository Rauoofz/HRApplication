using HRApplication.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Models
{
    public class VmCompany
    {
        public IEnumerable<City> cities { get; set; }
        public IEnumerable<Country> countries { get; set; }
        public IEnumerable<Department> departments { get; set; }
        public Employee employee { get; set; }
    }
}
