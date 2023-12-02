namespace Inno_Shop.Services.Products.Presentation.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(product => product.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(50).WithMessage("Title cannot be longer than 50 characters");

            RuleFor(product => product.Description)
                .MaximumLength(500).WithMessage("Description cannot be longer than 500 characters");

            RuleFor(product => product.Price)
                .GreaterThanOrEqualTo(0).WithMessage("Price should be greater than or equal to 0");

            RuleFor(product => product.IsAvaiable)
                .NotNull().WithMessage("Availability is required");

            RuleFor(product => product.UserId)
                .GreaterThan(0).WithMessage("UserId should be greater than 0");
        }
    }
}
