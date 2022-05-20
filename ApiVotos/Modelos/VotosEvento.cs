using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class VotosEvento
    {
        public long IdCandidato { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public byte[] FotoCandidato { get; set; }
        public int IdPartido { get; set; }
        public string NombrePardito { get; set; }
        public int TotalVotos { get; set; }
    }
}
