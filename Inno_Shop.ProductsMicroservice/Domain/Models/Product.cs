using System.Text.Json.Serialization;

namespace Inno_Shop.Services.Products.Domain.Models
{
    public class Product
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public long Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
        public bool IsAvaiable { get; set; }

        [SwaggerSchema(ReadOnly = true)]
        public DateTime CreatedAt { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public DateTime? UpdatedAt { get; set; }


        [SwaggerSchema(ReadOnly = true)]
        public long UserId { get; set; }
    }
}
