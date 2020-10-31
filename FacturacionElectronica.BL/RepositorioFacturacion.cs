using FacturacionElectronica.DA;
using System;
using System.Collections.Generic;
using System.Text;

namespace FacturacionElectronica.BL
{
    public class RepositorioFacturacion    : IRepositorioFacturacion
    {
        private ContextoDeBaseDeDatos elContextoDeBaseDeDatos;

        public RepositorioFacturacion(ContextoDeBaseDeDatos contexto)
        {
            elContextoDeBaseDeDatos = contexto;
        }

    }
}
