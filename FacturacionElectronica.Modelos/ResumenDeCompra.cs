using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class ResumenDeCompra
    {
        [Display(Name = "Fecha:")]
        public int idFactura { get; set; }
        [Display(Name = "Fecha:")]
        public DateTime fecha { get; set; }

        [Display(Name = "Cliente:")]
        public string cliente { get; set; }

        [Display(Name = "Consecutivo:")]
        public int consecutivo { get; set; }

        public List<LineaDetalle> lineasDetalle { get; set; }

        [Display(Name = "Condición de Pago:")]
        public string CondicionVenta { get; set; }

        [Display(Name = "Medio de Pago:")]
        public string MedioPago { get; set; }

        [Display(Name = "Total Impuestos:")]
        public double TotalImpuestos { get; set; }


        [Display(Name = "Total:")]
        public double Total { get; set; }
    }

}
