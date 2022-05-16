using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Partido
    {
        public int IdPartido { get; set; }
        [Required(ErrorMessage = "Campo NombrePardito Requerido")]
        public string NombrePartido { get; set; }
    }
}
