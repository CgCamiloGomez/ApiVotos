using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Usuario : Persona
    {
        public long IdUsuario { get; set; }
        [Required(ErrorMessage = "Campo IdRol Requerido")]
        public int IdRol { get; set; }
        [Required(ErrorMessage = "Campo PassWord Requerido")]
        public string PassWord { get; set; }
        public bool RegistroVoto { get; set; }
    }
}
