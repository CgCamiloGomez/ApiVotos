using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Evento
    {
        public long IdEvento { get; set; }
        [Required(ErrorMessage = "Campo IdTipoEveto Requerido")]
        public int IdTipoEvento { get; set; }
        [Required(ErrorMessage = "Campo DescripcionEvento Requerido")]
        public string DescripcionEvento { get; set; }
        [Required(ErrorMessage = "Campo IdUsuario Requerido")]
        public long IdUsuario { get; set; }
        [Required(ErrorMessage = "Campo FechaInicio Requerido")]
        public DateTime FechaInicio { get; set; }
        [Required(ErrorMessage = "Campo FechaFin Requerido")]
        public DateTime FechaFin { get; set; }
    }
}
