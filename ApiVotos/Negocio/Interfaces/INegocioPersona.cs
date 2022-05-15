using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface INegocioPersona
    {
        public long CrearUsuario(Usuario usuario);
    }
}
