using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace seafood_version_2.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("proId")]
        public int ProId { get; set; }
        [Column("proTypeId")]
        public int ProTypeId { get; set; }
        [Required]
        [Column("proName")]
        [StringLength(50)]
        public string ProName { get; set; }
        [Column("proQuantity")]
        public int ProQuantity { get; set; }
        [Column("proPrice")]
        public double ProPrice { get; set; }
        [Required]
        [Column("imgUrl")]
        [StringLength(100)]
        public string ImgUrl { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(ProTypeId))]
        [InverseProperty(nameof(Category.Products))]
        public virtual Category ProType { get; set; }
        [InverseProperty(nameof(OrderDetail.Pro))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
