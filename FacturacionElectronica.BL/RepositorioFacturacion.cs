﻿using FacturacionElectronica.DA;
using FacturacionElectronica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FacturacionElectronica.BL
{
    public class RepositorioFacturacion : IRepositorioFacturacion
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
        public List<Cliente> ObtenerClientePorIdentificacion(int identificacion)
        {
            var resultado = from listaClientes in elContextoDeBaseDeDatos.Cliente
                            where listaClientes.Identificacion == identificacion
                            select listaClientes;
            return resultado.ToList();
        }

        public void ModificarCliente(int id, Cliente cliente)
        {
            Cliente ClientePorModificar = ObtenerClientePorId(id);
            ClientePorModificar.Nombre = cliente.Nombre;
            ClientePorModificar.PrimerApellido = cliente.PrimerApellido;
            ClientePorModificar.SegundoApellido = cliente.SegundoApellido;
            ClientePorModificar.Identificacion = cliente.Identificacion;
            ClientePorModificar.TipoIdentificacion = cliente.TipoIdentificacion;
            ClientePorModificar.Correo = cliente.Correo;
            ClientePorModificar.Provincia = cliente.Provincia;
            ClientePorModificar.Canton = cliente.Canton;
            ClientePorModificar.Distrito = cliente.Distrito;
            ClientePorModificar.OtrasSenas = cliente.OtrasSenas;
            ClientePorModificar.Telefono = cliente.Telefono;

            elContextoDeBaseDeDatos.Cliente.Update(ClientePorModificar);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public void EliminarCliente(Cliente cliente)
        {
            elContextoDeBaseDeDatos.Cliente.Remove(cliente);
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

            elContextoDeBaseDeDatos.Cierre.Update(cierrePorModificar);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public void EliminarCierre(Cierre cierre)
        {
            elContextoDeBaseDeDatos.Cierre.Remove(cierre);
            elContextoDeBaseDeDatos.SaveChanges();
        }

        public void AgregarInventario(Inventario inventario)
        {
            elContextoDeBaseDeDatos.Inventario.Add(inventario);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public List<Inventario> ObtenerInventario()
        {
            List<Inventario> ListaDeProductosYServicios;
            ListaDeProductosYServicios = elContextoDeBaseDeDatos.Inventario.ToList();

            return ListaDeProductosYServicios;
        }
        public Inventario ObtenerInventarioPorId(int id)
        {
            Inventario inventario;
            inventario = elContextoDeBaseDeDatos.Inventario.Find(id);
            return inventario;
        }
        public void ModificarInventario(int id, Inventario inventario)
        {
            Inventario productoPorModificar = ObtenerInventarioPorId(id);
            productoPorModificar.Codigo = inventario.Codigo;
            productoPorModificar.Descripcion = inventario.Descripcion;
            productoPorModificar.PrecioCosto = inventario.PrecioCosto;
            productoPorModificar.PrecioVenta = inventario.PrecioVenta;
            productoPorModificar.Existencia = inventario.Existencia;

            elContextoDeBaseDeDatos.Inventario.Update(productoPorModificar);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public void EliminarInventario(Inventario inventario)
        {
            elContextoDeBaseDeDatos.Inventario.Remove(inventario);
            elContextoDeBaseDeDatos.SaveChanges();
        }

        public List<Inventario> ObtenerInventarioPorCodigo(int codigo)
        {
            var resultado = from listaInventario in elContextoDeBaseDeDatos.Inventario
                            where listaInventario.Codigo == codigo
                            select listaInventario;
            return resultado.ToList();
        }

        public void AgregarFactura(Factura factura)
        {
            elContextoDeBaseDeDatos.Factura.Add(factura);
            elContextoDeBaseDeDatos.SaveChanges();
        }

        public void ModificarFactura(int clave, Factura factura)
        {
            Factura facturaPorModificar = ObtenerFacturaPorId(clave);
            facturaPorModificar.idFactura = facturaPorModificar.Clave;
            facturaPorModificar.NumeroConsecutivo = facturaPorModificar.Clave;
            
            elContextoDeBaseDeDatos.Factura.Update(facturaPorModificar);
            elContextoDeBaseDeDatos.SaveChanges();
        }



        public List<Factura> ObtenerFactura()
        {
            List<Factura> ListaDeFacturas;
            ListaDeFacturas = elContextoDeBaseDeDatos.Factura.ToList();

            return ListaDeFacturas;
        }

        public Factura ObtenerFacturaPorId(int Clave)
        {
            Factura factura;
            factura = elContextoDeBaseDeDatos.Factura.Find(Clave);
            return factura;
        }


        public List<Factura> ObtenerFacturaPorIdentificacion(int clave)
        {
            var resultado = from listaFacturas in elContextoDeBaseDeDatos.Factura
                            where listaFacturas.Clave == clave
                            select listaFacturas;
            return resultado.ToList();
        }

        public void EliminarFactura(Factura id)
        {
            elContextoDeBaseDeDatos.Factura.Remove(id);
            elContextoDeBaseDeDatos.SaveChanges();
        }

      

      
        public void AgregarLineaDetalle(LineaDetalle lineaDetalle)
        {
            elContextoDeBaseDeDatos.LineaDetalle.Add(lineaDetalle);
            elContextoDeBaseDeDatos.SaveChanges();
        }

     



            public List<LineaDetalle> ObtenerLineas()
            {
                List<LineaDetalle> ListaDeLineas;
                ListaDeLineas = elContextoDeBaseDeDatos.LineaDetalle.ToList();
                return ListaDeLineas;
            }


        public void AgregarEmisor(Emisor emisor)
        {
            elContextoDeBaseDeDatos.Emisor.Add(emisor);
            elContextoDeBaseDeDatos.SaveChanges();
        }
    }



    }
