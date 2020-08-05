using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models.ViewModel
{
    public class ShoesViewModel
    {
        public Shoes Shoes { set; get; }
        [Display(Name = "Loại giày")]
        public IEnumerable<ShoeTypes> shoeTypes { set; get; }
        [Display(Name = "Hiệu giày")]
        public IEnumerable<Brands> brands { set; get; }
        [Display(Name = "Nhà cung cấp")]
        public List<CheckBoxViewModel> providers { set; get; }
    }
}
