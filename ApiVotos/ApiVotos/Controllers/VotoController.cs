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
    public class VotoController : ControllerBase
    {
        internal INegocioVoto negocioVoto;
        public VotoController (INegocioVoto _negocioVoto)
        {
            negocioVoto = _negocioVoto;
        }


        [HttpPost]
        [Authorize]
        [Route("RegistrarVoto")]
        public ActionResult<long> RegistrarVoto(Voto voto)
        {
            return Ok(new { IdVoto = negocioVoto.RegistrarVoto(voto) });
        }
        [HttpGet]
        [Authorize]
        [Route("ObtenerVotosXEvento/{idEvento}")]
        public ActionResult<List<VotosEvento>> ObtenerVotosXEvento(long idEvento)
        {
            var ltsVotos = negocioVoto.ObtenerVotosXEvento(idEvento);
            if (ltsVotos.Count > 0) 
            {
                return Ok(ltsVotos);
            }
            else 
            {
                return NoContent();
            }   
        }
    }
}
