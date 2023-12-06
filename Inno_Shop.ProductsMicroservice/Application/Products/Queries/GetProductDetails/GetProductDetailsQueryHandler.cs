using AutoMapper;
using Inno_Shop.Services.Products.Application.Common.Exceptions;
using Inno_Shop.Services.Products.Domain.Models;
using Inno_Shop.Services.Products.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryHandler
        : IRequestHandler<GetProductDetailsQuery, ProductDetailsVm>
    {
        private readonly ProductsDbContext _context;
        private readonly IMapper _mapper;

        public async Task<ProductDetailsVm> Handle(GetProductDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Products
                .FirstOrDefaultAsync(product =>
                product.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId) 
            { 
                throw new NotFoundException(nameof(Product), request.Id);
            }

            return _mapper.Map<ProductDetailsVm>(entity);
        }
    }
}
