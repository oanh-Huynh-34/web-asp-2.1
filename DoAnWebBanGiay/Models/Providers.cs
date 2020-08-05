using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace DoAnWebBanGiay.Models
{
    public class Providers
    {
        [Key]
        [Display(Name = "Mã nhà cùng cấp")]
        public int Id { set; get; }
        [Required]
        [Display(Name = "Tên nhà cùng cấp")]
        public string Name { set; get; }
        [Required]
        [Display(Name = "Địa chỉ")]
        public string Address { set; get; }
        public virtual ICollection<ProviderShoes> ProviderShoes { get; set; }
    }
}
