using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnWebBanGiay.Areas.Identity.Pages.Account
{
    public class AddAdminUserModel : PageModel
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AddAdminUserModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;

            _roleManager = roleManager;
        }
        public async Task<IActionResult> OnGet()
        {
            if (!await _roleManager.RoleExistsAsync(SD.AdminEndUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.AdminEndUser));
            }
            if (!await _roleManager.RoleExistsAsync(SD.SuperAdminEndUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser));
            }
            var UserAdmin = new ApplicationUser
            {
                UserName="admin@gmail.com",
                Email = "admin@gmail.com",
                PhoneNumber = "1122334455",
                Name="Admin Wen"
            };
            var result = await _userManager.CreateAsync(UserAdmin, "Admin123*");
            await _userManager.AddToRoleAsync(UserAdmin, SD.SuperAdminEndUser);
            return Page();
        }
    }
}