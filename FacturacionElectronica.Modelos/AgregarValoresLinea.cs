using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class AgregarValoresLinea
    {
        public int idInventario { get; set; }
        public int idFactura { get; set; }
        public int cantidad { get; set; }
        public UnidadDeMedida unidadMedida { get; set; }
    }
}
