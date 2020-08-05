using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnWebBanGiay.Data;
using DoAnWebBanGiay.Extensions;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DoAnWebBanGiay.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { set; get; }
        public ShoppingCartController(ApplicationDbContext db)
        {
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                Shoes = new List<Models.Shoes>()
            };
            _db = db;
        }
        public async Task<IActionResult> Index()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart != null)
            {
                foreach (int carItem in lstShoppingCart)
                {
                    Shoes shoes = _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).Where(x => x.Id == carItem).FirstOrDefault();
                    ShoppingCartVM.Shoes.Add(shoes);
                }
            }
            return View(ShoppingCartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart!=null)
            {
                ShoppingCartVM.Order.AppointmentDate = ShoppingCartVM.Order.AppointmentDate
                                                       .AddHours(ShoppingCartVM.Order.AppointmentTime.Hour)
                                                       .AddMinutes(ShoppingCartVM.Order.AppointmentTime.Minute);

                Order newOrder = ShoppingCartVM.Order;
                _db.Orders.Add(newOrder);
                _db.SaveChanges();
                int orderId = newOrder.Id;
                foreach (var item in lstShoppingCart)
                {
                    OrderDetail newOrderDetail = new OrderDetail()
                    {
                        OrderId = orderId,
                        ShoesID = item,
                        Price = _db.Shoes.Where(x => x.Id == item).Select(x => x.Price).FirstOrDefault()
                    };
                    _db.OrderDetails.Add(newOrderDetail);
                }
                _db.SaveChanges();
                lstShoppingCart = new List<int>();
                HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);

                return RedirectToAction("ConfirmOrder", "ShoppingCart", new { Id = orderId });
            }
            return null;
        }
        public IActionResult Remove(int id)
        {
            List<int> lstShoppingCart = HttpContext.Session.Get<List<int>>("ssShoppingCart");
            if (lstShoppingCart != null)
            {
                lstShoppingCart.Contains(id);
                {
                    lstShoppingCart.Remove(id);
                    
                }
            }
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult ConfirmOrder(int id)
        {
            ShoppingCartVM.Order = _db.Orders.Where(x => x.Id == id).FirstOrDefault();
            List<OrderDetail> orderDetail = _db.OrderDetails.Where(x => x.OrderId == id).ToList();
            foreach (var shoesDetail in orderDetail)
            {
                Shoes shoes = _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands).Where(x => x.Id == shoesDetail.ShoesID).FirstOrDefault();
                ShoppingCartVM.Shoes.Add(shoes);
            }
            return View(ShoppingCartVM);
        }
    }
}