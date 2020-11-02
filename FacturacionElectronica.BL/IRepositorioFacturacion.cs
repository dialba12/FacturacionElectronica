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
        public Cliente ObtenerClientePorId(int id);
        public void ModificarCliente(int id, Cliente cliente);


        public void AgregarCierre(Cierre cierre);
        public List<Cierre> ObtenerCierre();
        public Cierre ObtenerCierrePorId(int id);
        public void ModificarCierre(int id, Cierre cierre);

        public void AgregarInventario(Inventario inventario);
        public List<Inventario> ObtenerInventario();
        public Inventario ObtenerInventarioPorId(int id);
        public void ModificarInventario(int id, Inventario inventario);

    }
}
