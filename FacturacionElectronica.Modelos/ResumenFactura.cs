using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    class ResumenFactura
    {
        public int idResumen { get; set; }
        public double TotalVenta { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalVentaNeto { get; set; }
        public double TotalImpuesto { get; set; }
        public double TotalComprobante { get; set; }
       
    }
}
