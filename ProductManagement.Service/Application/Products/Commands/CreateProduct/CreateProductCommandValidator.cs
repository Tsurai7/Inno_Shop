using FluentValidation;

namespace Inno_Shop.Services.Products.Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator() 
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
