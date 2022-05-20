using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Interfaces
{
    public interface IDatosEvento
    {
        int CrearPartido(Partido partido);

        List<Partido> ConsultarPartidos();

        long CrearEvento(RequestEvento evento);
        long InsertarCandidatoEvento(long idCandidato, long idEvento);
        public long InsertarUsuarioEvento(long idUsuario, long idEvento, bool esVotante);

        List<Evento> ObtenerEventosUsuario(long idUsuario, bool esVotante);
        Evento ObtenerEventoXId(long idEvento);
        List<CandidatoEvento> ObtenerCandidatosXIdEvento(long idEvento);
    }
}
