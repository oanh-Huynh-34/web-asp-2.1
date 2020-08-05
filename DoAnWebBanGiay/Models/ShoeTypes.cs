using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoAnWebBanGiay.Models
{
    public class ShoeTypes
    {
        [Key]
        public int Id { set; get; }
        [Required]
        [Display(Name = "Tên loại giày")]
        public string Name { set; get; }
        public virtual ICollection<Shoes> Shoes { get; set; }
    }
}
