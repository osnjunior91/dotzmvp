using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Resume).NotNull().NotEmpty();
            RuleFor(x => x.CustomerID).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
