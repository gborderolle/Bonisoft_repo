using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Interno
    {
        [Key]
        public int Interno_ID { get; set; }
        public int Persona_ID { get; set; }
        public DateTime Fecha_ingreso { get; set; }
        public DateTime Fecha_egreso{ get; set; }
        public string Cargo { get; set; }
        public string Comentarios { get; set; }
    }
}