namespace ArtsemiLasyi.PetsApp.Validators;

using Requests;
using FluentValidation;

public class AddPetRequestValidator : AbstractValidator<AddPetRequest>
{
    public AddPetRequestValidator()
    {
        RuleFor(r => r.BirthDate)
            .NotNull()
            .NotEmpty()
            .LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
        RuleFor(r => r.Weight).NotNull().NotEmpty().GreaterThan(0);
    }
}