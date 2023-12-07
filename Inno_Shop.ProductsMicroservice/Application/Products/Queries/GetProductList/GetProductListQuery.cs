using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public long UserId { get; set; }
    }
}
