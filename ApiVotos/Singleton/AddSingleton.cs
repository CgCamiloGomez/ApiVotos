using Microsoft.Extensions.DependencyInjection;
using Seguridad.Clases;
using Seguridad.Interfaces;
using System;

namespace Singleton
{
    public static class AddSingleton
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services) 
        {
            services.AddSingleton<IAutenticacion, Autenticacion>();
            return services;
        }
    }
}
