namespace ArtsemiLasyi.PetsApp.Validators;

using ArtsemiLasyi.PetsApp.Requests;
using FluentValidation;

public class PatchPetRequestValidator : AbstractValidator<PatchPetRequest>
{
    public PatchPetRequestValidator()
    {
        RuleFor(r => r.BirthDate).NotEmpty().LessThanOrEqualTo(DateTime.UtcNow);
        RuleFor(r => r.Name).NotEmpty().MaximumLength(50);
        RuleFor(r => r.Weight).NotEmpty().GreaterThan(0);
    }
}