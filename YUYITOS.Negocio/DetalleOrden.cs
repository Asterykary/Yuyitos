using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class DetalleOrden
    {
        public int ID_DETALLE_ORDEN { get; set; }
        public string DESCRIPCION { get; set; }
        public int ORDEN_ID_ORDEN { get; set; }
        public int CANT_DETALLE_O { get; set; }
        public int PRODUCTO_ID_PRODUCTO { get; set; }


        public DetalleOrden()
        {

        }

        public int getLastId()
        {
            Coleccion col = new Coleccion();
            decimal aux;
            try
            {
                aux = col.ListadoDetalleOrden().Max(em => em.ID_DETALLE_ORDEN);
            }
            catch(Exception)
            {
                aux = 0;
            }

            return (int)aux;
        }
        public bool Create()
        {
            try
            {
                Dato.DETALLE_ORDEN unDetalleOrden = new Dato.DETALLE_ORDEN()
                {
                    ID_DETALLE_ORDEN = ID_DETALLE_ORDEN,
                    DESCRIPCION = DESCRIPCION,
                    ORDEN_ID_ORDEN = ORDEN_ID_ORDEN,
                    CANT_DETALLE_O = CANT_DETALLE_O,
                    PRODUCTO_ID_PRODUCTO = PRODUCTO_ID_PRODUCTO


                };
                Conexion.YuyitosDB.DETALLE_ORDEN.Add(unDetalleOrden);
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Dato.DETALLE_ORDEN unDetalleOrden = Conexion.YuyitosDB.DETALLE_ORDEN.First(em => em.ID_DETALLE_ORDEN == ID_DETALLE_ORDEN);
                ID_DETALLE_ORDEN = unDetalleOrden.ID_DETALLE_ORDEN;
                DESCRIPCION = unDetalleOrden.DESCRIPCION;
                ORDEN_ID_ORDEN = (int)unDetalleOrden.ORDEN_ID_ORDEN;
                CANT_DETALLE_O = unDetalleOrden.CANT_DETALLE_O;
                PRODUCTO_ID_PRODUCTO = unDetalleOrden.PRODUCTO_ID_PRODUCTO;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Dato.DETALLE_ORDEN unDetalleOrden = Conexion.YuyitosDB.DETALLE_ORDEN.First(em => em.ID_DETALLE_ORDEN == ID_DETALLE_ORDEN);
                unDetalleOrden.ID_DETALLE_ORDEN = ID_DETALLE_ORDEN;
                unDetalleOrden.DESCRIPCION = DESCRIPCION;
                unDetalleOrden.ORDEN_ID_ORDEN = (decimal)ORDEN_ID_ORDEN;
                unDetalleOrden.CANT_DETALLE_O = CANT_DETALLE_O;
                unDetalleOrden.PRODUCTO_ID_PRODUCTO = PRODUCTO_ID_PRODUCTO;
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                Dato.DETALLE_ORDEN unDetalleOrden = Conexion.YuyitosDB.DETALLE_ORDEN.First(em => em.ID_DETALLE_ORDEN == ID_DETALLE_ORDEN);
                Conexion.YuyitosDB.DETALLE_ORDEN.Remove(unDetalleOrden);
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
