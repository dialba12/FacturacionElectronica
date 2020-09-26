using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public class Exoneracion
    {
        public int Id_Exoneracion { get; set; }
        public int Tipo_Documento { get; set; }
        public int NumeroDocumento { get; set; }
        public string NombreInstitucion { get; set; }
        public DateTime FechaEmision { get; set; }
        public int PorcentajeExoneracion { get; set; }
        public double MontoExoneracion { get; set; }
    }
}
