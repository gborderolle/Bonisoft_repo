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
    
    public partial class descarga_viaje
    {
        public int Descarga_viaje_ID { get; set; }
        public int Viaje_ID { get; set; }
        public int Cuadrilla_ID { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Demora { get; set; }
        public string Comentarios { get; set; }
    }
}
