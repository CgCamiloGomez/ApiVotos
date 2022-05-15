﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Evento
    {
        public long IdEvento { get; set; }
        [Required(ErrorMessage = "Campo IdTipoEveto Requerido")]
        public int IdTipoEveto { get; set; }
        [Required(ErrorMessage = "Campo DescripcionEvento Requerido")]
        public string DescripcionEvento { get; set; }
    }
}