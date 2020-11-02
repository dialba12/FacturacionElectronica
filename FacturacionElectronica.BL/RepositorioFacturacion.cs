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

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> ListaDeClientes;
            ListaDeClientes = elContextoDeBaseDeDatos.Cliente.ToList();

            return ListaDeClientes;
        }
        public void AgregarCliente(Cliente cliente)
        {
            elContextoDeBaseDeDatos.Cliente.Add(cliente);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public Cliente ObtenerClientePorId(int id)
        {
            Cliente cliente;
            cliente = elContextoDeBaseDeDatos.Cliente.Find(id);
            return cliente;
        }
        public void ModificarCliente(int id, Cliente cliente)
        {
            Cliente ClientePorModificar = ObtenerClientePorId(id);
            ClientePorModificar.Nombre = cliente.Nombre;
            ClientePorModificar.SegundoNombre = cliente.SegundoNombre;
            ClientePorModificar.PrimerApellido = cliente.PrimerApellido;
            ClientePorModificar.SegundoApellido = cliente.SegundoApellido;
            ClientePorModificar.Identificacion = cliente.Identificacion;
            ClientePorModificar.TipoIdentificacion = cliente.TipoIdentificacion;
            ClientePorModificar.Correo = cliente.Correo;
            ClientePorModificar.Provincia = cliente.Provincia;
            ClientePorModificar.Canton = cliente.Canton;
            ClientePorModificar.Distrito = cliente.Distrito;
            ClientePorModificar.Barrio = cliente.Barrio;
            ClientePorModificar.OtrasSenas = cliente.OtrasSenas;
            ClientePorModificar.Telefono = cliente.Telefono;

            elContextoDeBaseDeDatos.Cliente.Update(ClientePorModificar);
            elContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarCierre(Cierre cierre)
        {
            elContextoDeBaseDeDatos.Cierre.Add(cierre);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public List<Cierre> ObtenerCierre()
        {
            List<Cierre> ListaDeCierres;
            ListaDeCierres = elContextoDeBaseDeDatos.Cierre.ToList();
            return ListaDeCierres;
        }
        public Cierre ObtenerCierrePorId(int id)
        {
            Cierre cierre;
            cierre = elContextoDeBaseDeDatos.Cierre.Find(id);
            return cierre;
        }
        public void ModificarCierre(int id, Cierre cierre)
        {
            Cierre cierrePorModificar = ObtenerCierrePorId(id);
            cierrePorModificar.Monto = cierre.Monto;

            elContextoDeBaseDeDatos.Cierre.Update(cierrePorModificar) ;
            elContextoDeBaseDeDatos.SaveChanges();
        }
    }
}
