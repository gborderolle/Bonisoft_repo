using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Mercaderia
    {
        [Key]
        public int Mercaderia_ID { get; set; }
        public int Variedad_ID { get; set; }
        public int Tipo_ID { get; set; }
        public string Medida { get; set; }
        public DateTime Fecha_corte{ get; set; }
        public string Comentarios { get; set; }
    }
}