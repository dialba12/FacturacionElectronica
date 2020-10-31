using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class DetalleServicio
    {
        public int idLineaDetalle { get; set; }
        public int NumeroLinea { get; set; }
        public int Codigo { get; set; }
        public int CodigoComercial { get; set; }
        public int Cantidad { get; set; }
        public UnidadDeMedida UnidadMedida { get; set; }
        public int UnidadMedidaComercial { get; set; }
        public string Detalle { get; set; }
        public int PrecioUnitario { get; set; }
        public int MontoTotal { get; set; }

        public int idDescuento { get; set; }

        public int Subtotal { get; set; }

        public int BaseImpuesto { get; set; }

        public int CodigoImpuesto { get; set; }

        public int ImpuestoNeto { get; set; }

        public int MontoLinea { get; set; }

    }
}
