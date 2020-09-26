using System;

namespace FacturacionElectronica.Modelos
{
    public class FacturaDeVenta
    {

        public int Clave { get; set; }
        public int Id_LineaDetalle { get; set; }
        public int NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public int Id_Emisor { get; set; }
        public int Id_Receptor { get; set; }
        public CondicionDeVenta CondicionVenta { get; set; }
        public MedioDePago MedioPago { get; set; }
        public int Id_Resumen { get; set; }
        public int NumeroResolucion { get; set; }

    }
}
