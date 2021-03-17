using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace seafood_version_2.Models
{
    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column("orderItemId")]
        public int OrderItemId { get; set; }
        [Column("proId")]
        public int ProId { get; set; }
        [Column("orderId")]
        public int OrderId { get; set; }
        [Column("orderItemQuantity")]
        public int OrderItemQuantity { get; set; }
        [Column("orderItemPrice")]
        public double OrderItemPrice { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderDetails")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProId))]
        [InverseProperty(nameof(Product.OrderDetails))]
        public virtual Product Pro { get; set; }
    }
}
