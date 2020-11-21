using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
   public class ResumenFactura
    {
        [Key]
        public int idResumen { get; set; }
        public double TotalVenta { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalVentaNeto { get; set; }
        public double TotalImpuesto { get; set; }
        public double TotalComprobante { get; set; }
       
    }
}
