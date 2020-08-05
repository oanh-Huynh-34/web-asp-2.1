using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnWebBanGiay.Data;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Models.ViewModel;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminEndUser)]
    public class ProviderShoesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _HostingEnvironment;
        [BindProperty]
        public ProviderShoesModel providerShoesVM { set; get; }
        public ProviderShoesController(ApplicationDbContext db, HostingEnvironment HostingEnvironment)
        {
            _db = db;
            _HostingEnvironment = HostingEnvironment;
            providerShoesVM = new ProviderShoesModel()
            {
                shoes = _db.Shoes.ToList(),
                providers = _db.Providers.ToList(),
                providerShoes = new Models.ProviderShoes(),
            };
        }
        public async Task<IActionResult> Index()
        {
            var providerShoes = _db.ProviderShoes.Include(m => m.Shoes).Include(n => n.Provider);
            return View(await providerShoes.ToListAsync());
        }
        public IActionResult Create()
        {
            return View(providerShoesVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(providerShoesVM);
            }
            _db.Add(providerShoesVM.providerShoes);
            await _db.SaveChangesAsync();           
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? ProviderID,int? ShoesID)
        {
            if (ProviderID == null && ShoesID==null)
            {
                return NotFound();
            }
            providerShoesVM.providerShoes = await _db.ProviderShoes.Include(m => m.Shoes).Include(n => n.Provider).SingleOrDefaultAsync(x => (x.ProviderID == ProviderID&&x.ShoesID==ShoesID));
            if (providerShoesVM.providerShoes == null)
                return NotFound();
            return View(providerShoesVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int ProviderID, int ShoesID)
        {
            if (!ModelState.IsValid)
            {
                return View(providerShoesVM);
            }
            var ProviderFromDb = _db.ProviderShoes.Where(x => (x.ProviderID == ProviderID && x.ShoesID == ShoesID)).FirstOrDefault();
            ProviderFromDb.ProviderID = providerShoesVM.providerShoes.ProviderID;
            ProviderFromDb.ShoesID = providerShoesVM.providerShoes.ShoesID;
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int? ProviderID, int? ShoesID)
        {
            if (ProviderID == null && ShoesID == null)
            {
                return NotFound();
            }
            providerShoesVM.providerShoes = await _db.ProviderShoes.Include(m => m.Shoes).Include(n => n.Provider).SingleOrDefaultAsync(x => (x.ProviderID == ProviderID && x.ShoesID == ShoesID));
            if (providerShoesVM.providerShoes == null)
                return NotFound();
            return View(providerShoesVM);
        }
        public async Task<IActionResult> Delete(int? ProviderID, int? ShoesID)
        {
            if (ProviderID == null && ShoesID == null)
            {
                return NotFound();
            }
            providerShoesVM.providerShoes = await _db.ProviderShoes.Include(m => m.Shoes).Include(n => n.Provider).SingleOrDefaultAsync(x => (x.ProviderID == ProviderID && x.ShoesID == ShoesID));
            if (providerShoesVM.providerShoes == null)
                return NotFound();
            return View(providerShoesVM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int ProviderID, int ShoesID)
        {
            string webRootPath = _HostingEnvironment.WebRootPath;
            ProviderShoes providershoes = await _db.ProviderShoes.Where(x=>(x.ProviderID == ProviderID && x.ShoesID == ShoesID)).FirstOrDefaultAsync();

            if (providershoes == null)
            {
                return NotFound();
            }
            else
            {
                _db.ProviderShoes.Remove(providershoes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}