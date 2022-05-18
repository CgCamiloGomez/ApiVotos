using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Candidato : Persona
    {
        public long IdCandidato { get; set; }
        [Required(ErrorMessage = "Campo IdPartido Requerido")]
        public int IdPartido { get; set; }
        public long IdEvento { get; set; }
        [Required(ErrorMessage = "Campo FotoCandidato Requerido")]
        public byte[] FotoCandidato { get; set; }

    }
}
