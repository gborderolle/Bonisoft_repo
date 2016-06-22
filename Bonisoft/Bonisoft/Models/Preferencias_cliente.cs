using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Preferencias_cliente
    {
        [Key]
        public int Preferencias_cliente_ID { get; set; }
        public int Tipo_lena_ID { get; set; }
        public int Lena_tipo_1_ID { get; set; }
        public int Lena_tipo_2_ID { get; set; }
        public decimal Largo_lena { get; set; }
        public decimal Diametro_lena { get; set; }
        public string Comentarios { get; set; }
    }
}