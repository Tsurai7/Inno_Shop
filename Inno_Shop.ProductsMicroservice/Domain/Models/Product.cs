using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Inno_Shop.Services.Products.Domain.Models
{
    public class Product
    {
        [Key]
        [SwaggerSchema(ReadOnly = true)]
        public Guid Id { get; set; }
        [SwaggerSchema(ReadOnly = true)]
        public Guid UserId { get; set; }
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
    }
}
