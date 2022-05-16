using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class InformacionUsuario
    {
        public long IdUsuario { get; set; }
        public long IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Ientificacion { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long IdTipoPersona { get; set; }
        public int IdRol { get; set; }
    }
}
