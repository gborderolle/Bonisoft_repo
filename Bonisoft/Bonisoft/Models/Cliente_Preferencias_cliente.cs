using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Bonisoft.Models
{
    public class Cliente_Preferencias_cliente
    {
        [Key]
        public int Cliente_ID { get; set; }
        public int Preferencias_cliente_ID { get; set; }
    }
}