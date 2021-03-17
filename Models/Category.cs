using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace seafood_version_2.Models
{
    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("proTypeId")]
        public int ProTypeId { get; set; }
        [Required]
        [Column("proTypeName")]
        [StringLength(50)]
        public string ProTypeName { get; set; }

        [InverseProperty(nameof(Product.ProType))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
