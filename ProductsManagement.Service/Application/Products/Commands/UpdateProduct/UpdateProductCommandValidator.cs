using FluentValidation;

namespace Inno_Shop.Services.Products.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator() 
        {
            RuleFor(createProductCommand =>
                createProductCommand.Title).NotEmpty().MaximumLength(50);
            RuleFor(createProductCommand =>
                createProductCommand.Description).NotEmpty().MaximumLength(300);
            RuleFor(createProductCommand =>
                createProductCommand.Price).GreaterThan(0).LessThan(decimal.MaxValue);
        }
    }
}
