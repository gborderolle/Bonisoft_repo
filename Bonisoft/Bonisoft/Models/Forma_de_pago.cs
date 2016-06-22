using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Forma_de_pago
    {
        [Key]
        public int Forma_de_pago_ID { get; set; }
        public string Forma { get; set; }
        public string Comentarios { get; set; }
    }
}