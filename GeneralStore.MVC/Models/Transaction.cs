using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Transaction
    {
        [Key]
        [Display(Name = "Transaction ID")]
        public int TransactionId { get; set; }

        [Required]
        [ForeignKey("Customer")] // Foreign Key
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; } 
        public virtual Customer Customer { get; set; }

        [Required]
        [ForeignKey("Product")] // Foreign Key
        [Display(Name = "Product ID")]
        public int ProductId { get; set; } 
        public virtual Product Product { get; set; }

        [Required]
        [Display(Name = "Item Count")]
        public int ItemCount { get; set; }

        [Required]
        [Display(Name = "Date of Transaction")]
        public DateTime DateOfTransaction { get; } = DateTime.UtcNow;
    }
}