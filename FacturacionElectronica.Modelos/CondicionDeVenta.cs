using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public enum CondicionDeVenta
    {
        Contado                                     = 01,
        Credito                                     = 02,
        Consignación                                = 03,
        Apartado                                    = 04,
        Arrendamiento_Con_Opcion_De_Compra          = 05,
        Arrendamiento_En_Funcion_Financiera         = 06,
        Cobro_A_Favor_De_Un_Tercero                 = 07,
        Servicios_Prestados_Al_Estado_A_Credito     = 08,
        Pago_De_Servicios_Prestados_Al_Estado       = 09,
        Otros                                       = 10,
    }
}
