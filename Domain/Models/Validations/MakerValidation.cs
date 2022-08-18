using FluentValidation;

namespace Domain.Models.Validations
{
    class MakerValidation : AbstractValidator<Maker>
    {
        public MakerValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength} characters");
        }        
    }
}
