using DotzMVP.Lib.Infrastructure.Data.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Validator
{
    public class ChangeRegisterValidator : AbstractValidator<ChangeRegister>
    {
        public ChangeRegisterValidator()
        {
            RuleFor(x => x.Status).NotNull();
            RuleFor(x => x.PersonID).NotNull().NotEmpty();
            RuleFor(x => x.Itens).NotNull().NotEmpty();
        }
    }
}
