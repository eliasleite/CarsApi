using FluentValidation;

namespace Domain.Models.Validations
{
    public class CarValidation : AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
                .Length(2, 200).WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Description)
                .NotEmpty().WithMessage("The field {PropertyName} needs to be provided")
                .Length(2, 1000).WithMessage("The field {PropertyName} needs to be between {MinLength} and {MaxLength} characters");

            RuleFor(c => c.Price)
                .GreaterThan(0).WithMessage("The field {PropertyName} needs to be greater then {ComparisonValue}");
        }
    }
}
