using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
   public class LineaDetalle
    {
        [Key]
        public int idLineaDetalle { get; set; }
        public int NumeroLinea { get; set; }
        public int Codigo { get; set; }
        public int Cantidad { get; set; }
        public string UnidadMedida { get; set; }
        public string Detalle { get; set; }
        public double PrecioUnitario { get; set; }
        public double MontoTotal { get; set; }
        public double MontoImpuesto { get; set; }
        public double Subtotal { get; set; }
        public double MontoTotalLinea { get; set; }
    }
}
