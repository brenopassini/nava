using Microsoft.Extensions.DependencyInjection;
using ProvaConceito.Domain.Interfaces;
using ProvaConceito.Domain.Services;
using ProvaConceito.Domain.Services.Interfaces;
using ProvaConceito.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProvaConceito.Infra.CrossCutting.IoC
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IVendaService, VendaService>();
        }
    }
}
