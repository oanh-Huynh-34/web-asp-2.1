using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
    public class ShoesController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _HostingEnvironment;
        [BindProperty]
        public ShoesViewModel shoeVM { set; get; }

        public ShoesController(ApplicationDbContext db, HostingEnvironment HostingEnvironment)
        {
            _db = db;
            _HostingEnvironment = HostingEnvironment;
            shoeVM = new ShoesViewModel()
            {
                shoeTypes = _db.ShoeTypes.ToList(),
                brands = _db.Brands.ToList(),
                Shoes = new Models.Shoes(),
            };
        }
        public async Task<IActionResult> Index()
        {
            var shoe = _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands);
            return View(await shoe.ToListAsync());
        }
        public IActionResult Create()
        {
            var results = from b in _db.Providers
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = false
                          };
            var ProviderShoesCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var c in results)
            {
                var checkBox = new CheckBoxViewModel();
                checkBox.Id = c.Id;
                checkBox.Name = c.Name;
                checkBox.Checked = c.Checked;
                ProviderShoesCheckBoxList.Add(checkBox);
            }
            shoeVM.providers = ProviderShoesCheckBoxList;
            return View(shoeVM);
        }
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (!ModelState.IsValid)
            {
                return View(shoeVM);
            }
             _db.Add(shoeVM.Shoes);
             await _db.SaveChangesAsync();
             string webRootPath = _HostingEnvironment.WebRootPath;
             var files = HttpContext.Request.Form.Files;
             var ProductsFromDb = _db.Shoes.Find(shoeVM.Shoes.Id);
             if (files.Count != 0 && files[0].Length<= 2097152)
             {
                 var uploaded = Path.Combine(webRootPath, SD.ImageFolder);
                 var extension = Path.GetExtension(files[0].FileName);
                 using (var fileStream = new FileStream(Path.Combine(uploaded, shoeVM.Shoes.Id + extension), FileMode.Create))
                 {
                      files[0].CopyTo(fileStream);
                  }
                  ProductsFromDb.Image = @"\" + SD.ImageFolder + @"\" + shoeVM.Shoes.Id + extension;
             }
             else
             {
                  var uploaded = Path.Combine(webRootPath, SD.ImageFolder+@"\"+SD.DefaultShoesImage);
                  System.IO.File.Copy(uploaded, webRootPath + @"\" + SD.ImageFolder + @"\" + shoeVM.Shoes.Id + ".png");
                  ProductsFromDb.Image = @"\" + SD.ImageFolder + @"\" + shoeVM.Shoes.Id + ".png";
             }

            await _db.SaveChangesAsync();
            var shoesID = _db.Shoes.Select(c=>c.Id).Max();
            foreach (var item in shoeVM.providers)
            {
                if (item.Checked)
                {
                    _db.ProviderShoes.Add(new ProviderShoes() { ShoesID = shoesID, ProviderID = item.Id });
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id ==null)
            {
                return NotFound();
            }
            shoeVM.Shoes =await _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).SingleOrDefaultAsync(x=>x.Id==id);
            var results = from b in _db.Providers
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from a in _db.ProviderShoes where (a.ShoesID == id) && (a.ProviderID == b.Id) select a).Count() > 0)
                          };
            var ProviderShoesCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var c in results)
            {
                var checkBox = new CheckBoxViewModel();
                checkBox.Id = c.Id;
                checkBox.Name = c.Name;
                checkBox.Checked = c.Checked;
                ProviderShoesCheckBoxList.Add(checkBox);
            }
            shoeVM.providers = ProviderShoesCheckBoxList;
            if (shoeVM.Shoes == null)
                return NotFound();
            return View(shoeVM);
        }
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(shoeVM);
            }
            string webRootPath = _HostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var ShoesFromDb = _db.Shoes.Where(x => x.Id == shoeVM.Shoes.Id).FirstOrDefault();
            if (files.Count > 0&& files[0]!=null && files[0].Length<= 2097152)
            {
                var uploaded = Path.Combine(webRootPath, SD.ImageFolder);
                var extension_new = Path.GetExtension(files[0].FileName);
                var extension_old= Path.GetExtension(ShoesFromDb.Image);
                if (System.IO.File.Exists(Path.Combine(uploaded, shoeVM.Shoes.Id + extension_old)))
                {
                    System.IO.File.Delete(Path.Combine(uploaded, shoeVM.Shoes.Id + extension_old));
                }
                using (var fileStream = new FileStream(Path.Combine(uploaded, shoeVM.Shoes.Id + extension_new), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                shoeVM.Shoes.Image = @"\" + SD.ImageFolder + @"\" + shoeVM.Shoes.Id + extension_new;
               
            }
            if (shoeVM.Shoes.Image != null)
            {
                ShoesFromDb.Image = shoeVM.Shoes.Image;
            }
            ShoesFromDb.Name = shoeVM.Shoes.Name;
            ShoesFromDb.Color = shoeVM.Shoes.Color;
            ShoesFromDb.Size = shoeVM.Shoes.Size;
            ShoesFromDb.Price = shoeVM.Shoes.Price;
            ShoesFromDb.Available = shoeVM.Shoes.Available;
            ShoesFromDb.ShoeTypeID = shoeVM.Shoes.ShoeTypeID;
            ShoesFromDb.BrandID = shoeVM.Shoes.BrandID;
            foreach (var item in _db.ProviderShoes)
            {
                if (item.ShoesID == id)
                    _db.Entry(item).State = EntityState.Deleted;
            }
            foreach (var item in shoeVM.providers)
            {
                if (item.Checked)
                {
                    _db.ProviderShoes.Add(new ProviderShoes() { ShoesID = id, ProviderID = item.Id });
                }
            }
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            shoeVM.Shoes = await _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).SingleOrDefaultAsync(x => x.Id == id);
            var results = from b in _db.Providers
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from a in _db.ProviderShoes where (a.ShoesID == id) && (a.ProviderID == b.Id) select a).Count() > 0)
                          };
            var ProviderShoesCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var c in results)
            {
                var checkBox = new CheckBoxViewModel();
                checkBox.Id = c.Id;
                checkBox.Name = c.Name;
                checkBox.Checked = c.Checked;
                ProviderShoesCheckBoxList.Add(checkBox);
            }
            shoeVM.providers = ProviderShoesCheckBoxList;
            if (shoeVM.Shoes == null)
                return NotFound();
            return View(shoeVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            shoeVM.Shoes = await _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).SingleOrDefaultAsync(x => x.Id == id);
            if (shoeVM.Shoes == null)
                return NotFound();
            return View(shoeVM);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string webRootPath = _HostingEnvironment.WebRootPath;
            Shoes shoes = await _db.Shoes.FindAsync(id);

            if (shoes == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    foreach (var item in shoeVM.providers)
                    {
                        if (item.Checked)
                        {
                            _db.ProviderShoes.Add(new ProviderShoes() { ShoesID = id, ProviderID = item.Id });
                        }
                    }
                }
                catch { }
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(shoes.Image);

                if (System.IO.File.Exists(Path.Combine(uploads, shoes.Id + extension)))
                {
                    System.IO.File.Delete(Path.Combine(uploads, shoes.Id + extension));
                }
                _db.Shoes.Remove(shoes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
}