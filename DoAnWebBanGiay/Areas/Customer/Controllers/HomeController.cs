using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Data;
using Microsoft.EntityFrameworkCore;
using DoAnWebBanGiay.Extensions;
using Microsoft.AspNetCore.Http;
using System.Text;
using DoAnWebBanGiay.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DoAnWebBanGiay.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        private int PageSize = 8;
        public async Task<IActionResult> Index(int shoesPage = 1,string shoeType = null,string searchString = null)
        {
            IQueryable<string> typeQuery = from m in _db.Shoes
                                            orderby m.ShoeTypes
                                            select m.ShoeTypes.Name;
            var shoesList =await _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).ToListAsync();
            StringBuilder param = new StringBuilder();
            param.Append("/Customer/Home?shoesPage=:");
            param.Append("&searchString");
            param.Append("&typeString");
            if (searchString != null)
            {
                param.Append(searchString);
            }
            if (shoeType != null)
            {
                param.Append(shoeType);
                shoesList = shoesList.Where(a => a.ShoeTypes.Name== shoeType).ToList();
            }

            

            if (searchString != null)
                shoesList = shoesList.Where(a => a.Name.ToLower().Contains(searchString.ToLower())).ToList();
            var count = shoesList.Count();
            shoesList = shoesList.OrderBy(p => p.Id).Skip((shoesPage - 1) * PageSize).Take(PageSize).ToList();
            PagingInfo PagingInfoVM = new PagingInfo
            {
                CurrentPage = shoesPage,
                ItemsPerPage = PageSize,
                totalItems = count,
                urlParam = param.ToString()
            };

            var HomeVM = new HomeViewModel
            {
                ShoeTypes = new SelectList(await _db.ShoeTypes.Select(x => x.Name).Distinct().ToListAsync()),
                Shoes = shoesList,
            };
            HomeVM.PagingInfoVM = PagingInfoVM;
            return View(HomeVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var Shoes = await _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).Where(x => x.Id == id).FirstOrDefaultAsync();
            return View(Shoes);
        }

        [HttpPost,ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPost(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart == null)
            {
                lstShoppingCart = new List<int>();
            }
            lstShoppingCart.Add(id);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Index","Home",new { area="Customer"});
        }
        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart.Count() > 0)
            {
                if (lstShoppingCart.Contains(id))
                    lstShoppingCart.Remove(id);
            }
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
