﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Chofer
    {
        [Key]
        public int Chofer_ID { get; set; }
        public int Persona_ID { get; set; }
        public int Empresa_pertenece_ID { get; set; }
        public string Comentarios { get; set; }
    }
}