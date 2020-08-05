using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models
{
    public class ProviderShoes
    {

        [ForeignKey("Providers")]
        [Display(Name = "Tên giày")]
        public int ProviderID { get; set; }
        public virtual Providers Provider { get; set; }
        [ForeignKey("Providers")]
        [Display(Name = "Nhà cung cấp")]
        public int ShoesID { get; set; }
        public virtual Shoes Shoes { get; set; }
    }
}
