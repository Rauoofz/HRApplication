using HRApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public interface IAccountService
    {
        Task<IdentityResult> CreateAccount(SignUpModel model);
        IQueryable<IdentityRole> GetRoles();
        Task<IdentityResult> CreateRole(RoleModel role);
        Task<SignInResult> SignIn(SignInModel model);
        Task SignOut();
    }
}
