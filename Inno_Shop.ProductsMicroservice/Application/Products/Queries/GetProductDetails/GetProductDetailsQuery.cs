using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
    }
}
