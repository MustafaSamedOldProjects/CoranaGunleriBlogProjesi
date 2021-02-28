using DTOs.Concrete.YaziDtoS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness.ValidationRules
{
    public class YaziCreateValidator : AbstractValidator<YaziCreateDto>
    {
        public YaziCreateValidator()
        {
            RuleFor(i => i.KategoriId).NotNull().WithMessage("Boş geçilemez");
            RuleFor(i => i.TagId).NotNull().WithMessage("Boş geçilemez");
            RuleFor(i => i.Body).NotNull().WithMessage("Boş geçilemez");
        }
    }
}
