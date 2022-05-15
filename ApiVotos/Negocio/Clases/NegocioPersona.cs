using AccesoDatos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class NegocioPersona : INegocioPersona
    {
        internal IDatosPersona iDatosUsuario;

        public NegocioPersona(IDatosPersona _iDatosusuario)
        {
            iDatosUsuario = _iDatosusuario;
        }
    }
}
