using FluentValidation;
using Inno_Shop.Services.Products.Application.Dto;

namespace Inno_Shop.Services.Products.Presentation.Validators
{
    public class ProductFilterDtoValidator : AbstractValidator<ProductFilterDto>
    {
        public ProductFilterDtoValidator() 
        {
            RuleFor(dto => dto.Title).MaximumLength(50).WithMessage("Title length should be less than 50 chars");
            RuleFor(dto => dto.MinPrice)
                .GreaterThan(0).WithMessage("Min price should be greater than 0");
            RuleFor(dto => dto.MaxPrice)
                .LessThan(decimal.MaxValue).WithMessage($"Max price should be leass than {decimal.MaxValue}");
        }

    }
}
