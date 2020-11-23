using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(x => x.ZipCode).NotNull().NotEmpty();
            RuleFor(x => x.Street).NotNull().NotEmpty();
            RuleFor(x => x.Number).NotNull().NotEmpty();
            RuleFor(x => x.Neighborhood).NotNull().NotEmpty();
            RuleFor(x => x.City).NotNull().NotEmpty();
        }
    }
}
