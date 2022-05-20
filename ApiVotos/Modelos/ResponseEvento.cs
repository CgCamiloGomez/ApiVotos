using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class ResponseEvento
    {
        public Evento evento { get; set; }
        public List<CandidatoEvento> Candidatos { get; set; }
    }
}
