using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DoAnWebBanGiay.Models
{
    public class Brands
    {
        [Key]
        [Display(Name = "Mã hiệu giày")]
        public int Id { set; get; }
        [Required]
        [Display(Name = "Tên hiệu giày")]
        public string Name { set; get; }
        [Required]
        [Display(Name = "Quốc gia")]
        public string Country { set; get; }
        public virtual ICollection<Shoes> Shoes { get; set; }

    }
}
