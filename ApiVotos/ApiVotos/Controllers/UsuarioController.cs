using Microsoft.AspNetCore.Cors;
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
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        internal INegocioPersona negocioPersona;
        public UsuarioController(INegocioPersona _negocioPersona)
        {
            negocioPersona = _negocioPersona;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public ActionResult<string> CrearUsuario(Usuario usuario) 
        {
            return Ok(new { IdUsuario  = negocioPersona.CrearUsuario(usuario)});
        }

        [HttpGet]
        [Route("ObtenerUsuarios")]
        public ActionResult<string> ObtenerUsuarios()
        {
            var ltsUsuarios = negocioPersona.ObtenerUsuarios();
            if (ltsUsuarios.Count > 0) 
            {
                return Ok(ltsUsuarios);
            }
            else 
            {
                return NoContent();
            }
            
        }
    }
}
