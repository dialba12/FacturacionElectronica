using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Descuento
    {
        public int Id_Descuento { get; set; }
        public double Monto_Descuento { get; set; }
        public string NaturalezaDesc { get; set; }
    }
}
