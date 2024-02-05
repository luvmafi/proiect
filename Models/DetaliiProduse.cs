
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proiect.Models
{
    public class ProductDetail
    {
        [Key]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public int? StockQuantity { get; set; }

        public Product? Product { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
