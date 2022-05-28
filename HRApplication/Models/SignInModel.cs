using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Models
{
    public class SignInModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public Boolean RemeberMe { get; set; }
        public List<SelectListItem> items { get; set; }
    }
}
