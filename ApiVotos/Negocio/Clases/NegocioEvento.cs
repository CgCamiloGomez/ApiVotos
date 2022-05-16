using AccesoDatos.Interfaces;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Clases
{
    public class NegocioEvento : INegocioEvento
    {
        internal IDatosEvento iDatosEvento;

        public NegocioEvento(IDatosEvento _iDatosEvento)
        {
            iDatosEvento = _iDatosEvento;
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
    }
}
