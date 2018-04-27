using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Boleta
    {
        public int ID_BOLETA { get; set; }
        public int TOTAL_NETO { get; set; }
        public int CLIENTE_RUT { get; set; }
        public System.DateTime FECHA_BOLETA { get; set; }

        public Boleta()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.BOLETA unaBoleta = Conexion.YuyitosDB.BOLETA.First(em => em.ID_BOLETA == ID_BOLETA);
                ID_BOLETA = (int)unaBoleta.ID_BOLETA;
                TOTAL_NETO = unaBoleta.TOTAL_NETO;
                CLIENTE_RUT = unaBoleta.CLIENTE_RUT;
                FECHA_BOLETA = unaBoleta.FECHA_BOLETA;
            
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
                Dato.BOLETA boleta = new Dato.BOLETA()
                {
                    ID_BOLETA = ID_BOLETA,
                    TOTAL_NETO = TOTAL_NETO,
                    CLIENTE_RUT = CLIENTE_RUT,
                    FECHA_BOLETA = FECHA_BOLETA
                };
                Conexion.YuyitosDB.BOLETA.Add(boleta);
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
                Dato.BOLETA boleta = Conexion.YuyitosDB.BOLETA.First(p => p.ID_BOLETA == ID_BOLETA);
                boleta.ID_BOLETA = ID_BOLETA;
                boleta.TOTAL_NETO = TOTAL_NETO;
                boleta.CLIENTE_RUT = CLIENTE_RUT;
                boleta.FECHA_BOLETA = FECHA_BOLETA;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
