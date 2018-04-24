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
        public List<Producto> ListadoProductos()
        {
            List<Producto> salida = new List<Producto>();
            foreach (Dato.PRODUCTO unProducto in Conexion.YuyitosDB.PRODUCTO)
            {
                salida.Add(new Producto()
                {
                    Id_producto = unProducto.ID_PRODUCTO,
                    Descripcion = unProducto.DESCRIPCION,
                    Precio = (int)unProducto.PRECIO,
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
                    ID_PROVEEDOR = unProveedor.ID_PROVEEDOR,
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
    }
}
