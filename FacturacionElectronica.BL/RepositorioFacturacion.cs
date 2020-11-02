using FacturacionElectronica.DA;
using FacturacionElectronica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void AgregarCliente(Cliente cliente)
        {
            elContextoDeBaseDeDatos.Cliente.Add(cliente);
            elContextoDeBaseDeDatos.SaveChanges();
           
        }
        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = elContextoDeBaseDeDatos.Cliente.ToList();

            return ListaDeClientes;
        }
    }
}
