using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace seafood_version_2.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        [Column("userId")]
        public int UserId { get; set; }
        [Required]
        [Column("userName")]
        [StringLength(40)]
        public string UserName { get; set; }
        [Required]
        [Column("password")]
        [StringLength(30)]
        public string Password { get; set; }
        [Column("roleId")]
        public int RoleId { get; set; }
        [Required]
        [Column("fullName")]
        [StringLength(50)]
        public string FullName { get; set; }
        [Column("phoneNumber")]
        [StringLength(15)]
        public string PhoneNumber { get; set; }
        [Column("address")]
        [StringLength(50)]
        public string Address { get; set; }
        [Column("status")]
        public int Status { get; set; }

        [ForeignKey(nameof(RoleId))]
        [InverseProperty("Users")]
        public virtual Role Role { get; set; }
        [InverseProperty(nameof(Order.User))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
