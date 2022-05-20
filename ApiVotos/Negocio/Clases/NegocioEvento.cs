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
    public class NegocioEvento : INegocioEvento
    {
        internal IDatosEvento iDatosEvento;
        internal IDatosPersona iDatosPersona;
        INegocioPersona inegocioPersona;

        public NegocioEvento(IDatosEvento _iDatosEvento, IDatosPersona _iDatosPersona, INegocioPersona _negocioPersona)
        {
            iDatosEvento = _iDatosEvento;
            iDatosPersona = _iDatosPersona;
            inegocioPersona = _negocioPersona;
        }

        public int CrearPartido(Partido partido) 
        {
            int idPartidoCreado = 0;
            try
            {
                idPartidoCreado = iDatosEvento.CrearPartido(partido);
            }
            catch (Exception e) 
            {
                throw new Exception("Ocurrio un error insertanto un partido");
            }
            return idPartidoCreado;
        }

        public List<Partido> ConsultarPartidos() 
        {
            List<Partido> ltsPartidos = new List<Partido>();
            try 
            {
                ltsPartidos =  iDatosEvento.ConsultarPartidos();
            }
            catch(Exception e) 
            {
                throw new Exception("Ocurrio un error consultando los partidos");
            }
            return ltsPartidos;
        }

        public long CrearEvento(RequestEvento evento) 
        {
            long idEvento = 0;

            try 
            {
                using (TransactionScope scope = new TransactionScope()) 
                {
                    idEvento = iDatosEvento.CrearEvento(evento);
                    //Inserta al creador del evento
                    iDatosEvento.InsertarUsuarioEvento(evento.evento.IdUsuario, idEvento, false);
                    //Inserta la lista de candidatos y personas
                    foreach (var element in evento.Candidatos)
                    {
                        element.IdEvento = idEvento;
                        if (element.IdCandidato == 0) 
                        {
                            var persona = inegocioPersona.MapearCamposPersona(element);
                            element.IdPersona = iDatosPersona.CrearPersona(persona);
                            element.IdCandidato = iDatosPersona.CrearCandidato(element);
                            iDatosEvento.InsertarCandidatoEvento(element.IdCandidato, idEvento);
                        }
                        else 
                        {
                            iDatosEvento.InsertarCandidatoEvento(element.IdCandidato, idEvento);
                        }
                    }
                    //Inserta los usuarios que pueden votar en el evento creado
                    foreach (var element in evento.Invitados) 
                    {
                        iDatosEvento.InsertarUsuarioEvento(element, idEvento, true);
                    }
                    scope.Complete();
                }
            }
            catch (Exception e) 
            {
                throw new Exception("Ocurrio un error creando el evento");
            }
            return idEvento;
        }


        public List<Evento> ObtenerEventosUsuario(long idUsuario, bool esVotante)
        {
            return iDatosEvento.ObtenerEventosUsuario(idUsuario, esVotante);
        }

        public ResponseEvento ObtenerEventoXId (long idEvento) 
        {
            ResponseEvento responseEvento = new ResponseEvento();
            try 
            {
                var evento = iDatosEvento.ObtenerEventoXId(idEvento);
                if (evento == null) 
                {
                    throw new Exception("No se encontro el evento para el id "+ idEvento);
                }
                var ltsCandidatos = iDatosEvento.ObtenerCandidatosXIdEvento(idEvento);
                responseEvento.evento = evento;
                responseEvento.Candidatos = ltsCandidatos;
            }
            catch (Exception e) 
            {
                throw new Exception(e.Message);
            }
            return responseEvento;
        }
    }
}
