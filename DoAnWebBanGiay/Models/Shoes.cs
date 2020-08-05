using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace DoAnWebBanGiay.Models
{
    public class Shoes
    {
        [Key]
        [Display(Name = "Mã giày")]
        public int Id { set; get; }
        [Required]
        [Display(Name = "Tên giày")]
        public string Name { set; get; }
        [Required]
        [Display(Name = "Màu sắc")]
        public string Color { set; get; }
        [Required]
        [Display(Name = "Giá")]
        public decimal Price { set; get; }
        [Required]
        [Display(Name = "Kích thước")]
        public int Size { set; get; }
        public string Image { set; get; }
        [Display(Name = "Tình trạng")]
        public bool Available { set; get; }
        [ForeignKey("Brands")]
        public int BrandID { get; set; }
        [Display(Name = "Hiệu giày")]
        public virtual Brands Brands { get; set; }
        [ForeignKey("ShoeTypes")]
        public int ShoeTypeID { get; set; }
        [Display(Name = "Loại giày")]
        public virtual ShoeTypes ShoeTypes { get; set; }
        [Display(Name = "Nhà cung cấp")]
        public virtual ICollection<ProviderShoes> ProviderShoes { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
