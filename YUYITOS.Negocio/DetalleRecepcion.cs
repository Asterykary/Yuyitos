using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class DetalleRecepcion
    {
        public int ID_DETALLE_RECEPCION { get; set; }
        public int CANT_DETALLE_RECEP { get; set; }
        public int STOCK_ID_STOCK { get; set; }
        public int RECEPCION_ID { get; set; }

        public DetalleRecepcion()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.DETALLE_RECEPCION unDetalleR = Conexion.YuyitosDB.DETALLE_RECEPCION.First(em => em.ID_DETALLE_RECEPCION == ID_DETALLE_RECEPCION);
                ID_DETALLE_RECEPCION = unDetalleR.ID_DETALLE_RECEPCION;
                CANT_DETALLE_RECEP = unDetalleR.CANT_DETALLE_RECEP;
                STOCK_ID_STOCK = (int)unDetalleR.STOCK_ID_STOCK;
                RECEPCION_ID = unDetalleR.RECEPCION_ID;


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
                Dato.DETALLE_RECEPCION drecepcion = new Dato.DETALLE_RECEPCION()
                {
                    ID_DETALLE_RECEPCION = ID_DETALLE_RECEPCION,
                    CANT_DETALLE_RECEP = CANT_DETALLE_RECEP,
                    STOCK_ID_STOCK = STOCK_ID_STOCK,
                    RECEPCION_ID = RECEPCION_ID
                };
                Conexion.YuyitosDB.DETALLE_RECEPCION.Add(drecepcion);
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
                Dato.DETALLE_RECEPCION drecepcion = Conexion.YuyitosDB.DETALLE_RECEPCION.First(p => p.ID_DETALLE_RECEPCION == ID_DETALLE_RECEPCION);
                drecepcion.ID_DETALLE_RECEPCION = ID_DETALLE_RECEPCION;
                drecepcion.CANT_DETALLE_RECEP = CANT_DETALLE_RECEP;
                drecepcion.STOCK_ID_STOCK = STOCK_ID_STOCK;
                drecepcion.RECEPCION_ID = RECEPCION_ID;

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
