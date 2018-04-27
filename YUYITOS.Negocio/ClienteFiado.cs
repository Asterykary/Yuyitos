using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class ClienteFiado
    {
        public int ID_CLIENTE_FIADO { get; set; }
        public System.DateTime FECHA_CONVENIDA { get; set; }

        public int CLIENTE_RUT { get; set; }
        public int MONTO_TOTAL { get; set; }
        public int MONTO_PAGADO { get; set; }
        public int MONTO_ADEUDADO { get; set; }
        
        public int ESTADO_PAGADO { get; set; }

        public ClienteFiado()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.CLIENTE_FIADO unClienteF = Conexion.YuyitosDB.CLIENTE_FIADO.First(em => em.ID_CLIENTE_FIADO == ID_CLIENTE_FIADO);
                ID_CLIENTE_FIADO = (int)unClienteF.ID_CLIENTE_FIADO;
                FECHA_CONVENIDA = unClienteF.FECHA_CONVENIDA;
                CLIENTE_RUT = unClienteF.CLIENTE_RUT;
                MONTO_TOTAL = unClienteF.MONTO_TOTAL;
                MONTO_PAGADO = unClienteF.MONTO_PAGADO;
                MONTO_ADEUDADO = unClienteF.MONTO_ADEUDADO;
                ESTADO_PAGADO = unClienteF.ESTADO_PAGADO;


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
                Dato.CLIENTE_FIADO clientF = new Dato.CLIENTE_FIADO()
                {
                    ID_CLIENTE_FIADO = ID_CLIENTE_FIADO,
                    FECHA_CONVENIDA = FECHA_CONVENIDA,
                    CLIENTE_RUT = CLIENTE_RUT,
                    MONTO_TOTAL = MONTO_TOTAL,
                    MONTO_PAGADO = MONTO_PAGADO,
                    MONTO_ADEUDADO = MONTO_ADEUDADO,
                    ESTADO_PAGADO = (short)ESTADO_PAGADO
        
                };
                Conexion.YuyitosDB.CLIENTE_FIADO.Add(clientF);
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
                Dato.CLIENTE_FIADO clientF = Conexion.YuyitosDB.CLIENTE_FIADO.First(c => c.ID_CLIENTE_FIADO == ID_CLIENTE_FIADO);
                clientF.ID_CLIENTE_FIADO = ID_CLIENTE_FIADO;
                clientF.FECHA_CONVENIDA = FECHA_CONVENIDA;
                clientF.CLIENTE_RUT = CLIENTE_RUT;
                clientF.MONTO_TOTAL = MONTO_TOTAL;
                clientF.MONTO_PAGADO = MONTO_PAGADO;
                clientF.MONTO_ADEUDADO = MONTO_ADEUDADO;
                clientF.ESTADO_PAGADO = (short)ESTADO_PAGADO;
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
