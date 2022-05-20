using AccesoDatos.Interfaces;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio.Clases
{
    public class NegocioVoto : INegocioVoto
    {
        internal IDatosVoto datosVoto;
        int UNICO_VOTO = 1;

        public NegocioVoto(IDatosVoto _datosVoto) 
        {
            datosVoto = _datosVoto;
        }

        public long RegistrarVoto(Voto voto) 
        {
            long idVoto = 0;
            try 
            {
                using (TransactionScope scope = new TransactionScope()) 
                {
                    var idTipoEvento = datosVoto.ObtnerTipoEventoDeEvento(voto.IdEvento);
                    if (idTipoEvento == UNICO_VOTO) 
                    {
                        if (datosVoto.ValidarVotoUsuario(voto.IdUsuario, voto.IdEvento))
                        {
                            throw new InvalidOperationException("El usuario ya registro voto en el evento");
                        }
                    }
                    idVoto = datosVoto.RegistrarVoto(voto);
                    datosVoto.ActualizarUsuarioEvento(voto.IdUsuario, voto.IdEvento);
                    scope.Complete();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return idVoto;
        }

        public List<VotosEvento> ObtenerVotosXEvento(long idEvento)
        {
            return datosVoto.ObtenerVotosXEvento(idEvento);
        }
    }
}
