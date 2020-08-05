using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnWebBanGiay.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Display(Name = "Sales Person")]
        public string SalesPersonId { get; set; }

        [ForeignKey("SalesPersonId")]
        public virtual ApplicationUser SalesPerson { get; set; }
        [Display(Name = "Appointment Date")]

        public DateTime AppointmentDate { get; set; }
        [NotMapped]
        public DateTime AppointmentTime { get; set; }
        [Display(Name = "Customer Name")]

        public string CustomerName { get; set; }
        [Display(Name = "Customer Phone Number")]
        public string CustomerPhoneNumber { get; set; }
        [Display(Name = "Customer Email")]
        public string CustomerEmail { get; set; }
        [Display(Name = "Confirmed")]
        public bool isConfirmed { get; set; }
        [Display(Name = "Address")]
        public string address { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
