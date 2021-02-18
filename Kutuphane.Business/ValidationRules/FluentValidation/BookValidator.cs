using FluentValidation;
using Kutuphane.Business.Constant;
using Kutuphane.Entities.Concrete;

namespace Kutuphane.Business.ValidationRules.FluentValidation
{
    public class BookValidator : AbstractValidator<Book>
    {
        public BookValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage(Messages.BosHata);
            RuleFor(p => p.Id).LessThanOrEqualTo(0).WithMessage(Messages.IdKontrol);
        }
    }
}