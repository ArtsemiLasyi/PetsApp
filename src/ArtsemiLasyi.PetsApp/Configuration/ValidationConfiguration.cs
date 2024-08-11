namespace ArtsemiLasyi.PetsApp.Configuration;

using Validators;
using FluentValidation;

public static class ValidationConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<AddPetRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<PatchPetRequestValidator>();
    }
}