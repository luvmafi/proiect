namespace proiect.Models
{
    public class ProductWithDetailsDto
    {
        public Product Product { get; set; }
        public ProductDetail Detail { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
