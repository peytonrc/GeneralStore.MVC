﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GeneralStore.MVC.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="# In Stock")]
        public int InventoryCount { get; set; }

        [Required]
        public decimal Price { get; set; } //-m

        [Required]
        [Display(Name="It Is Food")]
        public bool IsFood { get; set; }


    }
}