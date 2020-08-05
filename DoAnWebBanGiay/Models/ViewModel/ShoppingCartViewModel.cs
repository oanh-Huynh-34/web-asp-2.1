using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Shoes> Shoes { set; get; }
        public Order Order { set; get; }
    }
}
