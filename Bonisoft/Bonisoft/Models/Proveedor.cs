using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bonisoft.Models
{
    public class Proveedor
    {
        [Key]
        public int Proveedor_ID { get; set; }
        public int Empresa_ID { get; set; }
        public string Comentarios { get; set; }
    }
}