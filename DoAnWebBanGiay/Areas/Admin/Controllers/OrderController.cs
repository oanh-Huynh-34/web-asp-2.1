using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DoAnWebBanGiay.Data;
using DoAnWebBanGiay.Models;
using DoAnWebBanGiay.Models.ViewModel;
using DoAnWebBanGiay.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;

namespace DoAnWebBanGiay.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.SuperAdminEndUser + "," + SD.AdminEndUser)]
    public class OrderController : Controller
    {

        private readonly ApplicationDbContext _db;
        private int PageSize = 5;
        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task<IActionResult> Index(int shoesPage = 1,string searchName = null, string searchPhoneNumber = null, string searchEmail = null, string datepicker = null, string searchAddress = null)
        {
            System.Security.Claims.ClaimsPrincipal currentAdmin = this.User;
            var clamIdentity = (ClaimsIdentity)this.User.Identity;
            var clam = clamIdentity.FindFirst(ClaimTypes.NameIdentifier);
            OrderViewModel OrderVM = new OrderViewModel()
            {
                Orders = new List<Models.Order>()
            };
            StringBuilder param = new StringBuilder();
            param.Append("/Admin/Order?shoesPage=:");
            param.Append("&searchName");
            if (searchName != null)
            {
                param.Append(searchName);
            }
            param.Append("&searchPhoneNumber");
            if (searchPhoneNumber != null)
            {
                param.Append(searchPhoneNumber);
            }
            param.Append("&searchEmail");
            if (searchEmail != null)
            {
                param.Append(searchEmail);
            }
            param.Append("&datepicker");
            if (datepicker != null)
            {
                param.Append(datepicker);
            }
            param.Append("&searchAddress");
            if (searchAddress != null)
            {
                param.Append(searchAddress);
            }
            OrderVM.Orders =await _db.Orders.Include(x => x.SalesPerson).ToListAsync();
            if (User.IsInRole(SD.AdminEndUser))
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.SalesPersonId == clam.Value).ToList();
            }
            if (searchName != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerName.ToLower().Contains(searchName.ToLower())).ToList();
            }
            if (searchPhoneNumber != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerPhoneNumber.ToLower().Contains(searchPhoneNumber.ToLower())).ToList();
            }
            if (searchEmail != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.CustomerEmail.ToLower().Contains(searchEmail.ToLower())).ToList();
            }
            if (searchAddress != null)
            {
                OrderVM.Orders = OrderVM.Orders.Where(a => a.address.ToLower().Contains(searchAddress.ToLower())).ToList();
            }
            if (datepicker != null)
            {
                try
                {
                    DateTime searchDate = Convert.ToDateTime(datepicker);
                    OrderVM.Orders = OrderVM.Orders.Where(a => a.AppointmentDate.ToShortDateString().ToLower().Equals(searchDate.ToShortDateString())).ToList();

                }
                catch { }
            }
            var count = OrderVM.Orders.Count();
            OrderVM.Orders = OrderVM.Orders.OrderBy(p => p.AppointmentDate).Skip((shoesPage - 1) * PageSize).Take(PageSize).ToList();
            OrderVM.PagingInfo = new PagingInfo
            {
                CurrentPage = shoesPage,
                ItemsPerPage = PageSize,
                totalItems = count,
                urlParam = param.ToString()
            };
             return View(OrderVM);
        }
        public async Task<IActionResult> ExxportPDF()
        {
            System.Security.Claims.ClaimsPrincipal currentAdmin = this.User;
            OrderViewModel OrderVM = new OrderViewModel()
            {
                Orders = new List<Models.Order>()
            };
            OrderVM.Orders = _db.Orders.Include(x=>x.SalesPerson).ToList();
            return new ViewAsPdf(OrderVM);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();
            //   var shoe = _db.Shoes.Include(m => m.ShoeTypes).Include(n => n.Brands);
            var shoesList = _db.OrderDetails.Include(m => m.Shoes).Include(a => a.Shoes.ShoeTypes).Include(a => a.Shoes.Brands).Where(a => a.OrderId == id);
            DateTime toDay = DateTime.Now;
            OrderDetailsViewModel ojDetailVM = new OrderDetailsViewModel()
            {
                Order = _db.Orders.Include(x => x.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),                
                SalePersons = _db.ApplicationUsers.Where(p=>(p.LockoutEnd==null||p.LockoutEnd<toDay)).ToList(),
                OrderDetails = shoesList.ToList()
            };
            return View(ojDetailVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,OrderDetailsViewModel ojOrderViewModel)
        {
            if (ModelState.IsValid)
            {
                ojOrderViewModel.Order.AppointmentDate = ojOrderViewModel.Order.AppointmentDate
                                                        .AddHours(ojOrderViewModel.Order.AppointmentTime.Hour)
                                                        .AddMinutes(ojOrderViewModel.Order.AppointmentTime.Minute);
                var orderFormDB = _db.Orders.Where(a => a.Id == ojOrderViewModel.Order.Id).FirstOrDefault();
                orderFormDB.CustomerName = ojOrderViewModel.Order.CustomerName;
                orderFormDB.CustomerEmail = ojOrderViewModel.Order.CustomerEmail;
                orderFormDB.CustomerPhoneNumber = ojOrderViewModel.Order.CustomerPhoneNumber;
                orderFormDB.address = ojOrderViewModel.Order.address;
                orderFormDB.AppointmentDate = ojOrderViewModel.Order.AppointmentDate;
                orderFormDB.isConfirmed = ojOrderViewModel.Order.isConfirmed;
                if(User.IsInRole(SD.SuperAdminEndUser))
                {
                    orderFormDB.SalesPersonId = ojOrderViewModel.Order.SalesPersonId;

                }
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            
            return View(ojOrderViewModel);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();
            var shoesList = _db.OrderDetails.Include(m => m.Shoes).Include(a => a.Shoes.ShoeTypes).Include(a => a.Shoes.Brands).Where(a => a.OrderId == id);
            DateTime toDay = DateTime.Now;
            OrderDetailsViewModel ojDetailVM = new OrderDetailsViewModel()
            {
                Order = _db.Orders.Include(x => x.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalePersons = _db.ApplicationUsers.Where(p => (p.LockoutEnd == null || p.LockoutEnd < toDay)).ToList(),
                OrderDetails = shoesList.ToList()
            };
            return View(ojDetailVM);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();
            var shoesList = _db.OrderDetails.Include(m => m.Shoes).Include(a => a.Shoes.ShoeTypes).Include(a => a.Shoes.Brands).Where(a => a.OrderId == id);
            DateTime toDay = DateTime.Now;
            OrderDetailsViewModel ojDetailVM = new OrderDetailsViewModel()
            {
                Order = _db.Orders.Include(x => x.SalesPerson).Where(a => a.Id == id).FirstOrDefault(),
                SalePersons = _db.ApplicationUsers.Where(p => (p.LockoutEnd == null || p.LockoutEnd < toDay)).ToList(),
                OrderDetails = shoesList.ToList()
            };
            return View(ojDetailVM);
        }
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteComfirmed(int id)
        {
            var orderDetails = _db.OrderDetails.Where(d => d.OrderId == id);
            foreach (var detail in orderDetails)
            {
                _db.OrderDetails.Remove(detail);
            }
            var order = await _db.Orders.FindAsync(id);
            _db.Orders.Remove(order);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}