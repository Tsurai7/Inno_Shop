using AutoMapper;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductList
{
    public class GetProductListQueryHandler
        : IRequestHandler<GetProductListQuery, ProductListVm>
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(ProductsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductListVm> Handle(GetProductListQuery request,
            CancellationToken cancellationToken)
        {
            var productsQuery = await _context.Products
                .Where(product => product.UserId == request.UserId)
        }
    }
}
