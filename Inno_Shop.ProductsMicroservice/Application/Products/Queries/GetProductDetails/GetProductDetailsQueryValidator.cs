using FluentValidation;

namespace Inno_Shop.Services.Products.Application.Products.Queries.GetProductDetails
{
    public class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
    {
        public GetProductDetailsQueryValidator() 
        {
            RuleFor(deleteProductCommand => deleteProductCommand.Id).GreaterThanOrEqualTo(1);
        }
    }
}
