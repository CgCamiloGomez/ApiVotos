using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Interfaces
{
    public interface INegocioVoto
    {
        long RegistrarVoto(Voto voto);
        List<VotosEvento> ObtenerVotosXEvento(long idEvento);
    }
}
