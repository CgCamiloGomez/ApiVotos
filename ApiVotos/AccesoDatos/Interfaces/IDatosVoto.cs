using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDatosVoto
    {
        long RegistrarVoto(Voto voto);
        void ActualizarUsuarioEvento(long idUsuario, long idEvento);
        List<VotosEvento> ObtenerVotosXEvento(long idEvento);
        bool ValidarVotoUsuario(long idUsuario, long idEvento);
        long ObtnerTipoEventoDeEvento(long idEvento);
    }
}
