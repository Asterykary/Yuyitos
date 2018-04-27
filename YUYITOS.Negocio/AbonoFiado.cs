using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class AbonoFiado
    {
        public int ID_ABONO { get; set; }
        public int CANTIDAD { get; set; }
        public int CLIENTE_FIADO_ID { get; set; }

        public AbonoFiado()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.ABONO_FIADO unAbono = Conexion.YuyitosDB.ABONO_FIADO.First(em => em.ID_ABONO == ID_ABONO);
                ID_ABONO = (int)unAbono.ID_ABONO;
                CANTIDAD = unAbono.CANTIDAD;
                CLIENTE_FIADO_ID = (int)unAbono.CLIENTE_FIADO_ID;
                

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
