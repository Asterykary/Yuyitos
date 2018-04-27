using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Recepcion
    {
        public int ID_RECEPCION { get; set; }
        public System.DateTime FECHA { get; set; }
        public int PROVEEDOR_ID { get; set; }
        public int ORDEN_ID_ORDEN { get; set; }

        public Recepcion()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.RECEPCION unaRecepcion = Conexion.YuyitosDB.RECEPCION.First(em => em.ID_RECEPCION == ID_RECEPCION);
                ID_RECEPCION = (int)unaRecepcion.ID_RECEPCION;
                FECHA = unaRecepcion.FECHA;
                PROVEEDOR_ID = (int)unaRecepcion.PROVEEDOR_ID;
                ORDEN_ID_ORDEN = (int)unaRecepcion.ORDEN_ID_ORDEN;
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Create()
        {
            try
            {
                Dato.RECEPCION recepcion = new Dato.RECEPCION()
                {
                    ID_RECEPCION = ID_RECEPCION,
                    FECHA = FECHA,
                    PROVEEDOR_ID = PROVEEDOR_ID,
                    ORDEN_ID_ORDEN = ORDEN_ID_ORDEN
                };
                Conexion.YuyitosDB.RECEPCION.Add(recepcion);
                Conexion.YuyitosDB.SaveChanges();
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
                Dato.RECEPCION recepcion = Conexion.YuyitosDB.RECEPCION.First(p => p.ID_RECEPCION == ID_RECEPCION);
                recepcion.ID_RECEPCION = ID_RECEPCION;
                recepcion.FECHA = FECHA;
                recepcion.PROVEEDOR_ID = PROVEEDOR_ID;
                recepcion.ORDEN_ID_ORDEN = ORDEN_ID_ORDEN;
                
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
