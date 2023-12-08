using MediatR;

namespace Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand : IRequest<Unit>
    {
        public long UserId {  get; set; }
        public long Id { get; set; }
    }
}
