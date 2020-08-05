using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class HomeViewModel
    {
        public List<Shoes> Shoes { get; set; }
        public SelectList ShoeTypes { get; set; }
        public string ShoeType { get; set; }
        public string SearchString { get; set; }
        public PagingInfo PagingInfoVM { set; get; }

    }
}
