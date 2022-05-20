using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface INegocioEvento
    {
        int CrearPartido(Partido partido);
        List<Partido> ConsultarPartidos();

        long CrearEvento(RequestEvento evento);

        List<Evento> ObtenerEventosUsuario(long idUsuario, bool esVotante);
    }
}
