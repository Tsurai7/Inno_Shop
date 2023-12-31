﻿using Inno_Shop.Services.Products.Domain.Models;
using Inno_Shop.Services.Products.Infrastructure.Data;
using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler
        : IRequestHandler<CreateProductCommand, long>
    {
        private readonly ProductsDbContext _context;

        public CreateProductCommandHandler(ProductsDbContext context) =>       
            _context = context;
        

        public async Task<long> Handle(CreateProductCommand command,
            CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Id = command.Id,
                UserId = command.UserId,
                Title = command.Title,
                Description = command.Description,
                IsAvaiable = command.IsAvaiable,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = null,
            };

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }
}
