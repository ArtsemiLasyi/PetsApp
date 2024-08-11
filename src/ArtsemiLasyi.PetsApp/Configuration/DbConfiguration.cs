namespace ArtsemiLasyi.PetsApp.Configuration;

using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

public static class DbConfiguration
{
    public static void Configure(
        IServiceCollection services,
        IConfiguration configuration
    )
    {
        services.AddDbContext<PetsAppDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString(
                    "PetsAppDbContext"
                )
            );
        });
    }
}