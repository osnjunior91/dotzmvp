using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class ScoreValidator : AbstractValidator<Score>
    {
        public ScoreValidator()
        {
            RuleFor(x => x.PersonID).NotNull().NotEmpty();
            RuleFor(x => x.CustomerID).NotNull().NotEmpty();
            RuleFor(x => x.Amount).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
