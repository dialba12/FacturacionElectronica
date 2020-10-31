using System;

namespace FacturacionElectronica.Modelos
{
    public class FacturaDeVenta
    {

        public int Clave { get; set; }
        public int idLineaDetalle { get; set; }
        public int NumeroConsecutivo { get; set; }
        public DateTime FechaEmision { get; set; }
        public int idUsuario { get; set; }
        public int idCliente { get; set; }
        public CondicionDeVenta CondicionVenta { get; set; }
        public MedioDePago MedioPago { get; set; }
        public int idResumen { get; set; }
        public int NumeroResolucion { get; set; }

    }
}
