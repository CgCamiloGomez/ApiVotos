using AccesoDatos;
using AccesoDatos.Clases;
using AccesoDatos.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Negocio.Clases;
using Negocio.Interfaces;
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
            
            ///Datos
            services.AddSingleton<IDatosEvento, DatosEvento>();
            services.AddSingleton<IDatosPersona, DatosPersona>();
            services.AddSingleton<IDatosVoto, DatosVoto>();
            services.AddSingleton<IDatosAutenticacion, DatosAutenticacion>();

            //Negocio
            services.AddSingleton<INegocioEvento, NegocioEvento>();
            services.AddSingleton<INegocioPersona, NegocioPersona>();
            services.AddSingleton<INegocioVoto, NegocioVoto>();


            return services;
        }
    }
}
