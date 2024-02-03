﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Colecția pentru relația Many-to-Many cu Order
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
