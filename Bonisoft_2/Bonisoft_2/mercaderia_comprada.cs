//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonisoft_2
{
    using System;
    using System.Collections.Generic;
    
    public partial class mercaderia_comprada
    {
        public int Mercaderia_ID { get; set; }
        public int Viaje_ID { get; set; }
        public int Variedad_ID { get; set; }
        public int Procesador_ID { get; set; }
        public System.DateTime Fecha_corte { get; set; }
        public decimal Precio_xTonelada_compra { get; set; }
        public decimal Precio_xTonelada_venta { get; set; }
        public string Comentarios { get; set; }
    }
}
