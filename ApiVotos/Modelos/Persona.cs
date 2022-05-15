using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Persona
    {
        public long IdPersona { get; set; }
        [Required(ErrorMessage = "Campo Nombre Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Campo Apellidos Requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Campo Correo Requerido")]
        public string Correo { get; set; }
        [Required(ErrorMessage = "Campo Identificacion Requerido")]
        public string Identificacion { get; set; }
        public int IdTipoPersona { get; set; }
        [Required(ErrorMessage = "Campo FechaNacimiento Requerido")]
        public DateTime FechaNacimiento { get; set; }
    }
}
