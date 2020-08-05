using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class ProviderShoesModel
    {
        public ProviderShoes providerShoes { set; get; }
        [Display(Name = "Giày")]
        public IEnumerable<Shoes> shoes { set; get; }
        [Display(Name = "Nhà cung cấp")]
        public IEnumerable<Providers> providers { set; get; }
    }
}
