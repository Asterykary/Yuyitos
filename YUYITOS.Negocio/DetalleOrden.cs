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
        public int ORDEN_ID { get; set; }
        private int _CANT_DETALLE_O;

        public int CANT_DETALLE_O
        {
            get { return _CANT_DETALLE_O; }
            set {
                if (value > 0)
                    _CANT_DETALLE_O = value;
                else
                    throw new ArgumentException("La cantidad debe ser mayor a 0");
            }
        }

        public string ESTADO_DET_ORDEN { get; set; }
        public int PRODUCTO_PROVEEDOR_ID { get; set; }


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
                    ORDEN_ID = ORDEN_ID,
                    CANT_DETALLE_O = CANT_DETALLE_O,
                    ESTADO_DET_ORDEN = ESTADO_DET_ORDEN,
                    PRODUCTO_PROVEEDOR_ID = PRODUCTO_PROVEEDOR_ID


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
                ORDEN_ID = (int)unDetalleOrden.ORDEN_ID;
                CANT_DETALLE_O = unDetalleOrden.CANT_DETALLE_O;
                ESTADO_DET_ORDEN = unDetalleOrden.ESTADO_DET_ORDEN;
                PRODUCTO_PROVEEDOR_ID = unDetalleOrden.PRODUCTO_PROVEEDOR_ID;

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
                unDetalleOrden.ORDEN_ID = (decimal)ORDEN_ID;
                unDetalleOrden.CANT_DETALLE_O = CANT_DETALLE_O;
                unDetalleOrden.ESTADO_DET_ORDEN = ESTADO_DET_ORDEN;
                unDetalleOrden.PRODUCTO_PROVEEDOR_ID = PRODUCTO_PROVEEDOR_ID;
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
