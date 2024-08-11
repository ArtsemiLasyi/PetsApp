namespace ArtsemiLasyi.PetsApp.Configuration;

using DataAccess.Repositories.Abstractions;
using DataAccess.Repositories.Implementations;

public static class DiConfiguration
{
    public static void Configure(IServiceCollection services)
    {
        services.AddScoped<IPetRepository, PetRepository>();
        services.AddScoped<IPetBreedRepository, PetBreedRepository>();
    }
}