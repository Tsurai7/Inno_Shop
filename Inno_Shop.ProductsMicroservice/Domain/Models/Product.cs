namespace Inno_Shop.Services.Products.Domain.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public bool IsAvaiable { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public long UserId { get; set; }
    }
}
