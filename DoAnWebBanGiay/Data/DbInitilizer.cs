using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Data
{
    public class DbInitilizer:IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        public DbInitilizer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _db = db;
            _userManager = userManager;
            _RoleManager = RoleManager;
        }
        public async void Initilize()
        {
            if (_db.Database.GetPendingMigrations().Count() > 0)
            {
                _db.Database.Migrate();
            }
            if (_db.Roles.Any(r => r.Name == SD.SuperAdminEndUser)) return;
            _RoleManager.CreateAsync(new IdentityRole(SD.AdminEndUser)).GetAwaiter().GetResult();
            _RoleManager.CreateAsync(new IdentityRole(SD.SuperAdminEndUser)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                Name = "Bhrugen Patel",
                EmailConfirmed = true
            }, "Admin123*").GetAwaiter().GetResult();

            IdentityUser user = await _db.Users.Where(u => u.Email == "admin@gmail.com").FirstOrDefaultAsync();
            await _userManager.AddToRoleAsync(user, SD.SuperAdminEndUser);
        }
    }
}
