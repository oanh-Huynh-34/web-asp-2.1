using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoAnWebBanGiay.Data;
using DoAnWebBanGiay.Models;
using Microsoft.AspNetCore.Mvc;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Authorization;
namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminEndUser + "," + SD.AdminEndUser)]
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _db;
        public OrderDetailController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Edit(int? ShoesId,int? OrderId)
        {
            if (ShoesId == null || OrderId==null)
                return NotFound();
            var shoesList = _db.OrderDetails.Where(p => p.OrderId == OrderId && p.ShoesID == ShoesId).FirstOrDefault();
            return View(shoesList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {

                var orderDetailFormDB = _db.OrderDetails.Where(a => (a.ShoesID == orderDetail.ShoesID && a.OrderId==orderDetail.OrderId)).FirstOrDefault();
                orderDetailFormDB.ArriveDate = orderDetail.ArriveDate;
                _db.SaveChanges();
                return RedirectToAction("Index", "Order");
            }
            return View(orderDetail);
        }
        public async Task<IActionResult> Details(int? ShoesId, int? OrderId)
        {
            if (ShoesId == null || OrderId == null)
                return NotFound();
            var shoesList = _db.OrderDetails.Where(p => p.OrderId == OrderId && p.ShoesID == ShoesId).FirstOrDefault();
            return View(shoesList);
        }
        public async Task<IActionResult> Delete(int? ShoesId, int? OrderId)
        {
            if (ShoesId == null || OrderId == null)
                return NotFound();
            var shoesList = _db.OrderDetails.Where(p => p.OrderId == OrderId && p.ShoesID == ShoesId).FirstOrDefault();
            return View(shoesList);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComfirmed(int ShoesId, int OrderId)
        {
            var orderDetails = _db.OrderDetails.Where(d => d.OrderId == OrderId && d.ShoesID==ShoesId).FirstOrDefault();
            _db.OrderDetails.Remove(orderDetails);
            await _db.SaveChangesAsync();
            var order = _db.OrderDetails.Where(o => o.OrderId == OrderId).ToList<OrderDetail>();
            if (order.Count == 0)
                _db.Orders.Remove(_db.Orders.Where(o => o.Id == OrderId).FirstOrDefault());
            await _db.SaveChangesAsync();
            return RedirectToAction("Index","Order");

        }
    }
}