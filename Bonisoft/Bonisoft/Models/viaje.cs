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
    
    public partial class viaje
    {
        public int Viaje_ID { get; set; }
        public int Cliente_ID { get; set; }
        public int Proveedor_ID { get; set; }
        public decimal Precio_compra_por_tonelada { get; set; }
        public decimal Precio_valor_total { get; set; }
        public decimal Importe_viaje { get; set; }
        public decimal Saldo { get; set; }
        public int Empresa_de_carga_ID { get; set; }
        public System.DateTime Fecha_partida { get; set; }
        public System.DateTime Fecha_llegada { get; set; }
        public int Camion_ID { get; set; }
        public int Chofer_ID { get; set; }
        public string Carga { get; set; }
        public string Descarga { get; set; }
        public int Fletero_ID { get; set; }
        public decimal precio_compra { get; set; }
        public decimal precio_venta { get; set; }
        public decimal precio_flete { get; set; }
        public decimal precio_flete_total { get; set; }
        public decimal precio_descarga { get; set; }
        public decimal GananciaXTon { get; set; }
        public int IVA { get; set; }
        public string Comentarios { get; set; }
        public bool EnViaje { get; set; }
        public Nullable<System.DateTime> Fecha_registro { get; set; }
        public bool isFicticio { get; set; }
        public int Mercaderia_Lena_tipo_ID { get; set; }
        public int Mercaderia_Procesador_ID { get; set; }
        public System.DateTime Mercaderia_Fecha_corte { get; set; }
        public string Pesada_Origen_lugar { get; set; }
        public System.DateTime Pesada_Origen_fecha { get; set; }
        public decimal Pesada_Origen_peso_bruto { get; set; }
        public decimal Pesada_Origen_peso_neto { get; set; }
        public string Pesada_Destino_lugar { get; set; }
        public System.DateTime Pesada_Destino_fecha { get; set; }
        public decimal Pesada_Destino_peso_bruto { get; set; }
        public decimal Pesada_Destino_peso_neto { get; set; }
        public string Pesada_Comentarios { get; set; }
        public int Remito { get; set; }
        public decimal Mercaderia_Valor_Proveedor_PorTon { get; set; }
        public decimal Mercaderia_Valor_Cliente_PorTon { get; set; }
        public string Mercaderia_Proveedor_Comentarios { get; set; }
        public string Mercaderia_Cliente_Comentarios { get; set; }
    }
}
