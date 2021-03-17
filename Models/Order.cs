using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace seafood_version_2.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("orderId")]
        public int OrderId { get; set; }
        [Column("userId")]
        public int UserId { get; set; }
        [Required]
        [Column("fullName")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column("orderTotal")]
        public double OrderTotal { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Orders")]
        public virtual User User { get; set; }
        [InverseProperty(nameof(OrderDetail.Order))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
