using FacturacionElectronica.DA;
using FacturacionElectronica.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
        public List<Cierre> ObtenerCierrePorCodigo(int codigo)
        {
            var resultado = from listaCierre in elContextoDeBaseDeDatos.Cierre
                            where listaCierre.idCierre == codigo
                            select listaCierre;
            return resultado.ToList();
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
            facturaPorModificar.idResumen = factura.idResumen;
            facturaPorModificar.MedioPago = factura.MedioPago;
            facturaPorModificar.CondicionVenta = factura.CondicionVenta;

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
        public List<LineaDetalle> ObtenerLineas(int idFactura)
        {
            var resultado = from listaLineas in elContextoDeBaseDeDatos.LineaDetalle
                            where listaLineas.idFactura == idFactura
                            select listaLineas;
            return resultado.ToList();
        }

        public void AgregarResumen(ResumenFactura resumen)
        {
            elContextoDeBaseDeDatos.ResumenFactura.Add(resumen);
            elContextoDeBaseDeDatos.SaveChanges();
        }
        public List<ResumenFactura> ObtenerResumenes()
        {
            List<ResumenFactura> ListaDeResumenes;
            ListaDeResumenes = elContextoDeBaseDeDatos.ResumenFactura.ToList();

            return ListaDeResumenes;
        }

        public void GenerarXml(int id)
        {
            Factura DatosFactura = ObtenerFacturaPorId(id);

            Cliente cliente = ObtenerClientePorId(DatosFactura.idCliente);

            ResumenFactura resumen = elContextoDeBaseDeDatos.ResumenFactura.Find(DatosFactura.idResumen);

            XDocument factura = new XDocument(new XDeclaration("1.0", "utf-16", null),
                                                new XElement("MensajeHacienda",
                                                    new XElement("annotation"),
                                                    new XElement("complexType",
                                                        new XElement("sequence",
                                                            new XElement("Clave"),
                                                            new XElement("NombreEmisor"),
                                                            new XElement("TipoIdentificacionEmisor"),
                                                            new XElement("NumeroCedulaEmisor"),
                                                            new XElement("NombreReceptor"),
                                                            new XElement("TipoIdentificacionReceptor"),
                                                            new XElement("NumeroCedulaReceptor"),
                                                            new XElement("Mensaje"),
                                                            new XElement("DetalleMensaje"),
                                                            new XElement("MontoTotalImpuesto"),
                                                            new XElement("TotalFactura")
                                                            ))));

            XElement bloqueClave = (factura.Descendants("Clave").Last());
            bloqueClave.Add(new XElement("annotation",
                                new XElement("documentation", "ClaveNumericaDelComprobante")),
                            new XElement("simpleType",
                                new XElement("restriction",
                                    new XElement("pattern"))));

            XElement bloqueNombreEmisor = (factura.Descendants("NombreEmisor").Last());
            bloqueNombreEmisor.Add(new XElement("annotation",
                                        new XElement("documentation", cliente.Nombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido)),
                                   new XElement("simpleType",
                                        new XElement("restriction",
                                            new XElement("pattern"))));

            XElement bloqueteTipoDeIdentificacionEmisor = (factura.Descendants("TipoIdentificacionEmisor").Last());
            bloqueteTipoDeIdentificacionEmisor.Add(new XElement("annotation",
                                                        new XElement("documentation", cliente.TipoIdentificacion)),
                                                    new XElement("simpleType",
                                                        new XElement("restriction",
                                                            new XElement("enumeration", "value=01",
                                                                new XElement("annotation",
                                                                    new XElement("documentation", "Cedula Fisica"))),
                                                            new XElement("enumeration", "value=02",
                                                                new XElement("annotation",
                                                                    new XElement("documentation", "Cedula Juridica"))),
                                                            new XElement("enumeration", "value=03",
                                                                new XElement("annotation",
                                                                    new XElement("documentation", "DIMEX"))),
                                                            new XElement("enumeration", "value=04",
                                                                new XElement("annotation",
                                                                    new XElement("documentation", "NITE"))),
                                                            new XElement("enumeration", "value=05",
                                                                new XElement("annotation",
                                                                    new XElement("documentation", "Otros"))))));

            XElement bloqueIdentificacionEmisor = (factura.Descendants("NumeroCedulaEmisor").Last());
            bloqueIdentificacionEmisor.Add(new XElement("annotation",
                                                new XElement("documentation", cliente.Identificacion)),
                                            new XElement("simpleType",
                                                new XElement("restriction",
                                                    new XElement("maxLength", "value=12"),
                                                    new XElement("pattern", ""))));

            XElement bloqueNombreReceptor = (factura.Descendants("NombreReceptor").Last());
            bloqueNombreReceptor.Add(new XElement("annotation",
                                            new XElement("documentation", cliente.Nombre + " " + cliente.PrimerApellido + " " + cliente.SegundoApellido)),
                                        new XElement("simpleType",
                                            new XElement("restriction",
                                                new XElement("maxLength", "value=100"),
                                                new XElement("maxLength", "value=0"))));

            XElement bloqueTipoIdentificacionReceptor = (factura.Descendants("TipoIdentificacionReceptor").Last());
            bloqueTipoIdentificacionReceptor.Add(new XElement("annotation",
                                                    new XElement("documentation", cliente.TipoIdentificacion)),
                                                new XElement("simpleType",
                                                    new XElement("restriction",
                                                    new XElement("enumeration", "value=01",
                                                        new XElement("annotation",
                                                            new XElement("documentation", "Cedula Fisica"))),
                                                    new XElement("enumeration", "value=02",
                                                        new XElement("annotation",
                                                            new XElement("documentation", "Cedula Juridica"))),
                                                    new XElement("enumeration", "value=03",
                                                        new XElement("annotation",
                                                            new XElement("documentation", "DIMEX"))),
                                                    new XElement("enumeration", "value=04",
                                                        new XElement("annotation",
                                                            new XElement("documentation", "NITE"))),
                                                    new XElement("enumeration", "value=05",
                                                        new XElement("annotation",
                                                            new XElement("documentation", "Otros"))))));

            XElement bloqueNumeroCedulaReceptor = (factura.Descendants("NumeroCedulaReceptor").Last());
            bloqueNumeroCedulaReceptor.Add(new XElement("annotation",
                                                new XElement("documentation", cliente.Identificacion)),
                                            new XElement("simpleType",
                                                new XElement("restriction", "",
                                                    new XElement("maxLength", "value=12"),
                                                    new XElement("pattern", ""))));

            XElement bloqueMontoTotalImpuesto = (factura.Descendants("MontoTotalImpuesto").Last());
            bloqueMontoTotalImpuesto.Add(new XElement("annotation",
                                             new XElement("documentation", resumen.TotalImpuesto)),
                                         new XElement("simpleType",
                                             new XElement("restriction",
                                                 new XElement("totalDigits"),
                                                 new XElement("fractionDigits"))));

            XElement bloqueTotalFactura = (factura.Descendants("TotalFactura").Last());
            bloqueTotalFactura.Add(new XElement("annotation",
                                       new XElement("documentation", resumen.TotalVenta)),
                                   new XElement("simpleType",
                                       new XElement("restriction", "",
                                           new XElement("totalDigits", "value=18"),
                                           new XElement("fractionDigits", "value=5"))));

            factura.Save(@"c:\Facturas\factura_" + id + ".xml");
        }

        
    }



}
