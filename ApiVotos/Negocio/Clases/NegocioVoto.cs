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
