using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Persistence.Contexts;
using GestionTransferencias.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GestionTransferencias.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            // Register the DbContext with SQLite
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")
                //,
                //migrat=> migrat.MigrationsAssembly(nameof("GestionTransferencias.Api"))
                ));

            // Register repositories (if not already registered in Infrastructure)
            services.AddScoped<IBilleteraRepository, BilleteraRepository>();

            return services;
        }
    }
}
