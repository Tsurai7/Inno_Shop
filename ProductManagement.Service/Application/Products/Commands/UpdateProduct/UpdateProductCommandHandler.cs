using Inno_Shop.Services.Products.Application.Common.Exceptions;
using Inno_Shop.Services.Products.Domain.Models;
using Inno_Shop.Services.Products.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Inno_Shop.Services.Products.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler
        : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly ProductsDbContext _context;

        public UpdateProductCommandHandler(ProductsDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(UpdateProductCommand command,
            CancellationToken cancellationToken)
        {

            var entity = await _context.Products.FirstOrDefaultAsync(product =>
                product.Id == command.Id, cancellationToken);

            if (entity == null || entity.UserId != command.UserId)
            {
                throw new NotFoundException(nameof(Product), command.Id);
            }

            entity.Title = command.Title;
            entity.Description = command.Description;
            entity.Price = command.Price;
            entity.IsAvaiable = command.IsAvailable;
            entity.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
