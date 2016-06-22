using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Pesada
    {
        [Key]
        public int Pesada_ID { get; set; }
        public string Lugar { get; set; }
        public DateTime Fecha{ get; set; }
        public string Nombre_balanza{ get; set; }
        public decimal Valor_pesada { get; set; }
        public string Comentarios { get; set; }
    }
}