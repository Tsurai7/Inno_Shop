using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public Guid UserId {  get; set; }
        public Guid Id { get; set; }
    }
}
