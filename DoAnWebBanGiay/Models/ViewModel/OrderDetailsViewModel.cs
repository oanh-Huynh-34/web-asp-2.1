using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class OrderDetailsViewModel
    {
        public Order Order { set; get; }
        public List<ApplicationUser> SalePersons { set; get; }
        //[Display(Name = "Giày")]
        public List<OrderDetail> OrderDetails { set; get; }
    }
}
