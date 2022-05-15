using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
