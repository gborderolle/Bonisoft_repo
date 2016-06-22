using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Cuadrilla_descarga
    {
        [Key]
        public int Cuadrilla_descarga_ID { get; set; }
        public int Empresa_ID { get; set; }
        public string Comentarios { get; set; }
    }
}