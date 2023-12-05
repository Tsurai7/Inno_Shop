namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public Guid UserId { get; set; }
    }
}
