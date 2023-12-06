using FluentValidation;

namespace Inno_Shop.Services.Products.Application.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator() 
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).GreaterThanOrEqualTo(1);
        }
    }
}
