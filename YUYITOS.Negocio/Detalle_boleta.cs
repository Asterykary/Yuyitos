using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Detalle_boleta
    {
        public int ID_DETALLE_BOLETA { get; set; }
        public int BOLETA_ID { get; set; }
        public int DETALLE_STOCK_ID { get; set; }

        public Detalle_boleta()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.DETALLE_BOLETA unDetalleBoleta = Conexion.YuyitosDB.DETALLE_BOLETA.First(em => em.ID_DETALLE_BOLETA == ID_DETALLE_BOLETA);
                ID_DETALLE_BOLETA = (int)unDetalleBoleta.ID_DETALLE_BOLETA;
                BOLETA_ID = unDetalleBoleta.BOLETA_ID;
                DETALLE_STOCK_ID = unDetalleBoleta.DETALLE_STOCK_ID;

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
                Dato.DETALLE_BOLETA detBoleta = new Dato.DETALLE_BOLETA()
                {
                    ID_DETALLE_BOLETA = ID_DETALLE_BOLETA,
                    BOLETA_ID = BOLETA_ID,
                    DETALLE_STOCK_ID = DETALLE_STOCK_ID
                };
                Conexion.YuyitosDB.DETALLE_BOLETA.Add(detBoleta);
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
                Dato.DETALLE_BOLETA detBoleta = Conexion.YuyitosDB.DETALLE_BOLETA.First(p => p.ID_DETALLE_BOLETA == ID_DETALLE_BOLETA);
                detBoleta.ID_DETALLE_BOLETA = ID_DETALLE_BOLETA;
                detBoleta.BOLETA_ID = BOLETA_ID;
                detBoleta.DETALLE_STOCK_ID = DETALLE_STOCK_ID;
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
