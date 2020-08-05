using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnWebBanGiay.Data;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.SuperAdminEndUser)]
    public class AdminUsersController : Controller
    {
        
        private readonly ApplicationDbContext _db;
        public AdminUsersController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }
            var userFromDb = await _db.ApplicationUsers.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ApplicationUser admin)
        {
            if (id !=admin.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                ApplicationUser Admin = _db.ApplicationUsers.Where(x => x.Id == id).FirstOrDefault();
                Admin.Name = admin.Name;
                Admin.PhoneNumber = admin.PhoneNumber;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || id.Trim().Length == 0)
            {
                return NotFound();
            }
            var userFromDb = await _db.ApplicationUsers.FindAsync(id);
            if (userFromDb == null)
            {
                return NotFound();
            }
            return View(userFromDb);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string id)
        {
            ApplicationUser Admin = _db.ApplicationUsers.Where(x => x.Id == id).FirstOrDefault();
            Admin.LockoutEnd =DateTime.Now.AddYears(1000) ;
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}