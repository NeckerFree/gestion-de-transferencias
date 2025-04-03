using GestionTransferencias.Application.Interfaces;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using GestionTransferencias.Application.Products.Commands;

namespace GestionTransferencias.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR (if using CQRS)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetBilleteraCommand).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateBilleteraCommand).Assembly));
            services.AddScoped<IBilleteraService, BilleteraService>();

            return services;
        }
    }
}
