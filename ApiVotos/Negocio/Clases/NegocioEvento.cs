using AccesoDatos.Interfaces;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class NegocioEvento : INegocioEvento
    {
        internal IDatosEvento iDatosEvento;

        public NegocioEvento(IDatosEvento _iDatosEvento)
        {
            iDatosEvento = _iDatosEvento;
        }
    }
}
