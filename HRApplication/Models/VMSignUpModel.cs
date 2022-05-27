using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Models
{
    public class VMSignUpModel
    {
        public SignUpModel signUp { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}
