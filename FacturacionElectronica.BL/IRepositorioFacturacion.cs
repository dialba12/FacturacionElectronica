using System;
using System.Collections.Generic;
using System.Text;
using FacturacionElectronica.Modelos;

namespace FacturacionElectronica.BL
{
    public interface IRepositorioFacturacion
    {
        public void AgregarCliente(Cliente cliente);
        public List<Cliente> ObtenerClientes();
    }
}
