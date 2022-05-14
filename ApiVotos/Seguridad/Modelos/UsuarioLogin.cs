using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class UsuarioLogin
    {
        [Required(ErrorMessage ="Campo Usuario Requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "Campo PassWord Requerido")]
        public string PassWord { get; set; }
    }
}
