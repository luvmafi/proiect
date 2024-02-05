using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace proiect.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        // Colecția pentru relația One-to-Many cu Product
        public List<Product>? Products { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
