using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Bonisoft.Models
{
    public class Descarga_viaje
    {
        [Key]
        public int Descarga_viaje_ID { get; set; }
        public int Viaje_ID { get; set; }
        public int Cuadrilla_ID { get; set; }
        public DateTime Fecha { get; set; }
        public int Demora { get; set; }
        public string Comentarios { get; set; }
    }
}