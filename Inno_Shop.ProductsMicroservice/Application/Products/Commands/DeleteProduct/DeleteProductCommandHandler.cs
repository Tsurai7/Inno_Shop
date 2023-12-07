using Inno_Shop.Services.Products.Application.Common.Exceptions;
using Inno_Shop.Services.Products.Domain.Models;
using Inno_Shop.Services.Products.Infrastructure.Data;
using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler
        : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ProductsDbContext _context;

        public DeleteProductCommandHandler(ProductsDbContext context) =>
            _context = context;

        public async Task<Unit> Handle(DeleteProductCommand command,
            CancellationToken cancellationToken)
        {

            var entity = await _context.Products
                .FindAsync(new object[] { command.Id }, cancellationToken);


            if (entity == null || entity.UserId != command.UserId)
            {
                throw new NotFoundException(nameof(Product), command.Id);
            }

            _context.Products.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
