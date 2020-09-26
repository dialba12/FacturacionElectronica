using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.Modelos
{
    public enum TipoCodigoComercial
    {
        Codigo_Del_Producto_Del_Vendedor            = 01,
        Codigo_Del_Producto_Del_Comprador           = 02,
        Codigo_Del_Producto_Asignado_Por_Industria  = 03,
        Codigo_De_Uso_Interno                       = 04,
        Otros                                       = 99,
    }
}
