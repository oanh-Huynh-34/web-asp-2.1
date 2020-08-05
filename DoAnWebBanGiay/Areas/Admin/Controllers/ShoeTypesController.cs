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
    public class ShoeTypesController : Controller
    {       
        private readonly ApplicationDbContext _db;
        public ShoeTypesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.ShoeTypes.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoeTypes shoeTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Add(shoeTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeTypes);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoeTypes = await _db.ShoeTypes.FindAsync(id);
            if (shoeTypes == null)
            {
                return NotFound();
            }

            return View(shoeTypes);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShoeTypes shoeTypes)
        {
            if (id != shoeTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _db.Update(shoeTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoeTypes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var shoeTypes = await _db.ShoeTypes.FindAsync(id);
            if (shoeTypes == null)
            {
                return NotFound();
            }

            return View(shoeTypes);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = await _db.ShoeTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            return View(productType);
        }

        //POST Edit action Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var shoeTypes = await _db.ShoeTypes.FindAsync(id);
            _db.ShoeTypes.Remove(shoeTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
    }
}