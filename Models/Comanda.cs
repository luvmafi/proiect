using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace proiect.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        // Colecția pentru relația Many-to-Many cu Product
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
