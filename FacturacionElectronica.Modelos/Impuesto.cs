using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Impuesto
    {
        public CodigoDeImpuesto CodigoImpuesto { get; set; }
        public int CodigoTarifa { get; set; }
        public double Tarifa { get; set; }
        public double FactorIVA { get; set; }
        public double Monto { get; set; }
        public int Id_Exoneracion { get; set; }
    }
}
