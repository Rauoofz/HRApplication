﻿using HRApplication.Models;
using HRApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService _accountService)
        {
            accountService = _accountService;
        }
        public  IActionResult SignUp()
        {
            
            VMSignUpModel vMSignUp = new VMSignUpModel();
            vMSignUp.Roles = accountService.GetRoles().ToList();

            return View("SignUp",vMSignUp);
        }

        public IActionResult Roles()
        {
            return View("AddRoles");
        }

        public async Task<IActionResult> CreateRole(RoleModel role)
        {
            await accountService.CreateRole(role);
            return View("AddRoles");
        }

        public async Task<IActionResult> CreateAccount(VMSignUpModel vMSign)
        {
            var result= await accountService.CreateAccount(vMSign.signUp);
            
            if(result.Succeeded)
            {
                return View("AddRoles");
            }
            else
            {
                vMSign.Roles = accountService.GetRoles().ToList();

                return View("SignUp", vMSign);
            }
        }


    }
}
