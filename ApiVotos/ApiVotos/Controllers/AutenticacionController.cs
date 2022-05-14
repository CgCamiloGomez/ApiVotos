using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Modelos;
using Seguridad.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVotos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacionController : ControllerBase
    {
        public readonly IConfiguration configuracion;
        private readonly IAutenticacion autenticacion;
        public AutenticacionController(IConfiguration config, IAutenticacion aut) 
        {
            this.configuracion = config;
            this.autenticacion = aut;
        }

        [HttpPost]
        public IActionResult Login(UsuarioLogin usuarioLogin) 
        {
            var usuario = autenticacion.AutenticarUsuarioAsync(usuarioLogin);
            if (usuario != null) 
            {
                return Ok( new { token = autenticacion.GenerarTokenJWT(usuario) });
            }
            else 
            {
                return Unauthorized();
            }
        }
    }
}
