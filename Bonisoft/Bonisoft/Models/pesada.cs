//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonisoft.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class pesada
    {
        public int pesada_ID { get; set; }
        public string Origen_lugar { get; set; }
        public System.DateTime Origen_fecha { get; set; }
        public string Origen_nombre_balanza { get; set; }
        public decimal Origen_peso_bruto { get; set; }
        public decimal Origen_peso_neto { get; set; }
        public string Destino_lugar { get; set; }
        public System.DateTime Destino_fecha { get; set; }
        public string Destino_nombre_balanza { get; set; }
        public decimal Destino_peso_bruto { get; set; }
        public decimal Destino_peso_neto { get; set; }
        public string Comentarios { get; set; }
    }
}