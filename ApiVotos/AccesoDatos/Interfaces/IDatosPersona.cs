using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDatosPersona
    {
        long CrearPersona(Persona persona);
        long CrearUsuario(Usuario usuario);
        long CrearCandidato(Candidato candidato);
        List<Usuario> ObtenerUsuarios();

    }
}
