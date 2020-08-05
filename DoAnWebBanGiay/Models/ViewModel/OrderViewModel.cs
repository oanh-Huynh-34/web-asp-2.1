using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class OrderViewModel
    {
        public List<Order> Orders { set; get; }
        public PagingInfo PagingInfo { set; get; }
    }
}
