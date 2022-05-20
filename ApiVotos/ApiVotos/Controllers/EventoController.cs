using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        internal INegocioEvento negocioEvento;
        public EventoController (INegocioEvento _negocioEvento)
        {
            negocioEvento = _negocioEvento;
        }

        [HttpPost]
        [Authorize]
        [Route("CrearPartido")]
        public ActionResult<int> CrearPartido(Partido partido) 
        {
            return Ok(new { IdPartido = negocioEvento.CrearPartido(partido)});
        }

        [HttpGet]
        [Authorize]
        [Route("ConsultarPartidos")]
        public ActionResult<List<Partido>> ConsultarPartidos()
        {
            var ltsPartidos = negocioEvento.ConsultarPartidos();
            if (ltsPartidos.Count() > 0) 
            {
                return Ok(ltsPartidos);
            }
            else 
            {
                return NoContent();
            }
        }

        [HttpPost]
        [Authorize]
        [Route("CrearEvento")]
        public ActionResult<int> CrearEvento(RequestEvento evento)
        {
            return Ok(new { IdEvento = negocioEvento.CrearEvento(evento)});
        }

        [HttpGet]
        [Authorize]
        [Route("ObtenerEventosUsuario/{idUsuario}/{esVotante}")]
        public ActionResult<List<Evento>> ObtenerEventosUsuario(long idUsuario, bool esVotante)
        {
            var ltsEventos = negocioEvento.ObtenerEventosUsuario(idUsuario, esVotante);
            if (ltsEventos.Count() > 0)
            {
                return Ok(ltsEventos);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet]
        [Authorize]
        [Route("ObtenerEventoXId/{idEvento}")]
        public ActionResult<ResponseEvento> ObtenerEventoXId(long idEvento)
        {
            if (idEvento == 0) 
            {
                return BadRequest();
            }
            else 
            {
                return negocioEvento.ObtenerEventoXId(idEvento);
            }   
        }
    }
}
