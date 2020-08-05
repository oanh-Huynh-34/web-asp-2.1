using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
        [ForeignKey("Shoes")]
        public int? ShoesID { get; set; }
        public virtual Shoes Shoes { get; set; }
        public DateTime ArriveDate { get; set; }
        public decimal Price { set; get; }
    }
}
