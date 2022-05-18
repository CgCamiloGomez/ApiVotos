using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class RequestEvento
    {
        [Required(ErrorMessage = "Objeto Evento es requerido")]
        public Evento evento { get; set; }
        [Required(ErrorMessage = "Lista de candidatos es requerida")]
        public List<Candidato> Candidatos { get; set; }
        [Required(ErrorMessage = "Lista de invitados es Requerida")]
        public List<long> Invitados { get; set; }
    }
}
