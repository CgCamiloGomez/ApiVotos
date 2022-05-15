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
    public class UsuarioController : ControllerBase
    {
        internal INegocioPersona negocioPersona;
        public UsuarioController(INegocioPersona _negocioPersona)
        {
            negocioPersona = _negocioPersona;
        }

        [HttpPost]
        [Route("CrearUsuario")]
        public ActionResult<string> CrearPersona(Usuario usuario) 
        {
            return Ok("");
        }
    }
}
