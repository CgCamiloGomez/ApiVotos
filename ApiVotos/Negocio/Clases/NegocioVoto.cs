using AccesoDatos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class NegocioVoto : INegocioVoto
    {
        internal IDatosVoto datosVoto;

        public NegocioVoto(IDatosVoto _datosVoto) 
        {
            datosVoto = _datosVoto;
        }
    }
}
