using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<long>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvaiable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
