using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDatosAutenticacion
    {
        InformacionUsuario ObtenerInfoUsuarioLogin(UsuarioLogin usuarioLogin);
    }
}
