using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Coleccion
    {
        public List<Producto> carrito = new List<Producto>();
        
        public List<Producto> carritoVenta = new List<Producto>();
        public List<Producto> ListadoProductos()
        {
            List<Producto> salida = new List<Producto>();
            foreach (Dato.PRODUCTO unProducto in Conexion.YuyitosDB.PRODUCTO)
            {
                salida.Add(new Producto()
                {
                    ID_PRODUCTO = unProducto.ID_PRODUCTO,
                    DESCRIPCION = unProducto.DESCRIPCION,
                    PRECIO_COMPRA = (int)unProducto.PRECIO_COMPRA,
                });
            }
            return salida;
        }

        public List<Proveedor> ListadoIdProveedor()
        {
            List<Proveedor> salida = new List<Proveedor>();
            foreach (Dato.PROVEEDOR unProveedor in Conexion.YuyitosDB.PROVEEDOR)
            {
                salida.Add(new Proveedor()
                {
                    ID_PROVEEDOR = (int)unProveedor.ID_PROVEEDOR,
                    NOMBRE = unProveedor.NOMBRE
                });
            }
            return salida;
        }

        public List<Orden> ListadoOrden()
        {
            List<Orden> salida = new List<Orden>();
            foreach (Dato.ORDEN unaOrden in Conexion.YuyitosDB.ORDEN)
            {
                salida.Add(new Orden()
                {
                    ID_ORDEN = unaOrden.ID_ORDEN
                });
            }
            return salida;
        }

        public List<DetalleOrden> ListadoDetalleOrden()
        {
            List<DetalleOrden> salida = new List<DetalleOrden>();
            foreach (Dato.DETALLE_ORDEN unaOrden in Conexion.YuyitosDB.DETALLE_ORDEN)
            {
                salida.Add(new DetalleOrden()
                {
                    ID_DETALLE_ORDEN = unaOrden.ID_DETALLE_ORDEN
                });
            }
            return salida;
        }

        public List<Stock> ListadoStock()
        {
            List<Stock> salida = new List<Stock>();
            foreach (Dato.STOCK unStock in Conexion.YuyitosDB.STOCK)
            {
                salida.Add(new Stock()
                {
                    ID_STOCK = unStock.ID_STOCK,
                    FECHA_VENCIMIENTO = unStock.FECHA_VENCIMIENTO
                });
            }
            return salida;
        }

        public List<DetalleStock> ListadoDetalleStock()
        {
            List<DetalleStock> salida = new List<DetalleStock>();
            foreach (Dato.DETALLE_STOCK unStock in Conexion.YuyitosDB.DETALLE_STOCK)
            {
                salida.Add(new DetalleStock()
                {
                    ID_DETALLE_STOCK = unStock.ID_DETALLE_STOCK,
                    CANT_DETALLE_STOCK = unStock.CANT_DETALLE_STOCK,
                    CODIGO_BARRA = unStock.CODIGO_BARRA,
                    PRODUCTO_PROVEEDOR_ID = unStock.PRODUCTO_PROVEEDOR_ID,
                    STOCK_ID_STOCK = (int)unStock.STOCK_ID_STOCK
                });
            }
            return salida;
        }


        public List<Proveedor> ObtenerRubroProveedor()
        {
            List<Proveedor> listaRubro = new List<Proveedor>();
            foreach (Dato.PROVEEDOR prove in Conexion.YuyitosDB.PROVEEDOR)
            {
                listaRubro.Add(new Proveedor()
                {
                    RUBRO = prove.RUBRO,
                });
            }
            return listaRubro;
        }

        public List<Ciudad> ObtenerCiudad()
        {
            List<Ciudad> listaCiudad = new List<Ciudad>();
            foreach (Dato.CIUDAD ciudad in Conexion.YuyitosDB.CIUDAD)
            {
                listaCiudad.Add(new Ciudad()
                {
                    ID_CIUDAD = ciudad.ID_CIUDAD,
                    DESCRIPCION = ciudad.DESCRIPCION
                });
            }
            return listaCiudad;
        }
    }
}
