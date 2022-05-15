using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DatosAutenticacion : IDatosAutenticacion
    {
        private readonly string CadenaConexion; 
        public DatosAutenticacion(IConfiguration config) 
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }
    }
}
