using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class ChangeRegisterItemValidator : AbstractValidator<ChangeRegisterItem>
    {
        public ChangeRegisterItemValidator()
        {
            RuleFor(x => x.ProductID).NotNull().NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThan(0);
            RuleFor(x => x.Amount).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
