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
        long CrearUsuario(Usuario usuario);

        string CifrarPassWord(string password);
        Persona MapearCamposPersona(Candidato candidato);
    }
}
