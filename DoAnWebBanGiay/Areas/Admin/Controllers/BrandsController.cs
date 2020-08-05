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
    [Authorize(Roles = SD.SuperAdminEndUser)]
    public class BrandsController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BrandsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Brands.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brands Brand)
        {
            if (ModelState.IsValid)
            {
                _db.Add(Brand);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Brand);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var brach =await _db.Brands.FindAsync(id);
            if (brach == null)
                return NotFound();
            return View(brach);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ?id, Brands brach)
        {
            if (id != brach.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(brach);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brach);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();
            return View(brand);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var brand = await _db.Brands.FindAsync(id);
            if (brand == null)
                return NotFound();
            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _db.Brands.FindAsync(id);
            _db.Brands.Remove(brand);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}