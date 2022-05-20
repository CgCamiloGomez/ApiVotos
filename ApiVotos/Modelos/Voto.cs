using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Voto
    {
        public long IdVoto { get; set; }
        [Required(ErrorMessage = "Campo IdCandidato Requerido")]
        public long IdCandidato { get; set; }
        [Required(ErrorMessage = "Campo IdUsuario Requerido")]
        public long IdUsuario { get; set; }
        [Required(ErrorMessage = "Campo IdEvento Requerido")]
        public long IdEvento { get; set; }

        [Required(ErrorMessage = "Campo FechaVoto Requerido")]
        public DateTime FechaVoto { get; set; }
    }
}
