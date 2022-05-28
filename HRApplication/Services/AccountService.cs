using HRApplication.Data;
using HRApplication.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Services
{
    public class AccountService:IAccountService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountService(UserManager<ApplicationUser> _userManager,SignInManager<ApplicationUser> _signInManager,RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> CreateAccount(SignUpModel model)
        {
            ApplicationUser user = new ApplicationUser();
            user.Name = model.Name;
            user.UserName = model.UserName;
            user.Email = model.Email;

            var result= await userManager.CreateAsync(user,model.Password);

            if(result.Succeeded)
            {
                var role= await roleManager.FindByIdAsync(model.RoleId);
                await userManager.AddToRoleAsync(user, role.Name);
            }
            return result;
            
        }

        public IQueryable<IdentityRole> GetRoles()
        {
            return roleManager.Roles.AsQueryable();
        }

        public async Task<IdentityResult> CreateRole(RoleModel role)
        {
            IdentityRole identityRole = new IdentityRole();
            identityRole.Name = role.Name;
            var result= await roleManager.CreateAsync(identityRole);
            return result;
        }

        public async Task<SignInResult> SignIn(SignInModel model)
        {
            var result= await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RemeberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await signInManager.SignOutAsync();
        }

    }
}
