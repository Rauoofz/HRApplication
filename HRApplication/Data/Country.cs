using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Data
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Employee> employees { get; set; }
    }
}
