using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seguridad.Interfaces
{
    public interface IAutenticacion
    {
        InformacionUsuario AutenticarUsuarioAsync(UsuarioLogin usuario);

        string GenerarTokenJWT(InformacionUsuario usuarioInfo);
    }
}
