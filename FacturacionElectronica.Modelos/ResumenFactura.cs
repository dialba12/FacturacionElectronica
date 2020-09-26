using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class ResumenFactura
    {
        public int Id_Resumen { get; set; }
        public double TotalSerGravados { get; set; }
        public double TotalSerExonerado { get; set; }
        public double TotalSerExento { get; set; }
        public double TotlSerMercanciasGravadas { get; set; }
        public double TotalMercanciasExentas { get; set; }
        public double TotalMercExonerada { get; set; }
        public double TotalGravado { get; set; }
        public double TotalExento { get; set; }
        public double TotalExonerado { get; set; }
        public double TotalVenta { get; set; }
        public double TotalDescuento { get; set; }
        public double TotalVentaNeta { get; set; }
        public double TotalImpuesto { get; set; }
        public double TotalIVADevuelto { get; set; }
        public double TotalOtrosCargos { get; set; }
        public double TotalComprobante { get; set; }
        public CodigoDeMoneda CodigoMoneda { get; set; }

    }
}
