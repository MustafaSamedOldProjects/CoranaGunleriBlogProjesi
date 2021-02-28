using DTOs.Concrete.YaziDtoS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.ValidationRules
{
    public class YaziListValidator : AbstractValidator<YaziListDto>
    {
        public YaziListValidator()
        {
            RuleFor(i => i.Kategori).NotNull().WithMessage("Boş geçilemez");
            RuleFor(i => i.Tag).NotNull().WithMessage("Boş geçilemez");
            RuleFor(i => i.GorunurResmi).NotNull().WithMessage("Boş geçilemez");

        }
    }
}
