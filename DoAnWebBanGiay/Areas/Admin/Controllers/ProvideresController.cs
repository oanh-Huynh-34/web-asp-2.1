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
    public class ProvidersController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProvidersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Providers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Providers provider)
        {
            if (ModelState.IsValid)
            {
                _db.Add(provider);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
                return NotFound();
            return View(provider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, Providers provider)
        {
            if (id != provider.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _db.Update(provider);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(provider);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
                return NotFound();
            return View(provider);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var provider = await _db.Providers.FindAsync(id);
            if (provider == null)
                return NotFound();
            return View(provider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var provider = await _db.Providers.FindAsync(id);
            _db.Providers.Remove(provider);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}