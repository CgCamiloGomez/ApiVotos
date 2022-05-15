using AccesoDatos.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Clases
{
    public class DatosVoto : IDatosVoto
    {
        private readonly string CadenaConexion;
        public DatosVoto(IConfiguration config)
        {
            CadenaConexion = config.GetConnectionString("BdVotos");
        }
    }
}
