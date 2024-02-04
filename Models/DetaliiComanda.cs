﻿
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class OrderDetail
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
