using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Proveedor
    {
        public decimal ID_PROVEEDOR { get; set; }
        public string NOMBRE { get; set; }
        public int RUT { get; set; }
        public string DV { get; set; }
        public int TELEFONO { get; set; }
        public string RUBRO { get; set; }
        public int CIUDAD_ID_CIUDAD { get; set; }

        public Proveedor()
        {
            init();
        }

        private void init()
        {
            ID_PROVEEDOR = 0;
            NOMBRE = "";
            RUT = 0;
            DV = "7";
            TELEFONO = 123456;
            RUBRO = "MIAU";
            CIUDAD_ID_CIUDAD = 1;
        }

        public string GetId()
        {
            int ID = (int)ID_PROVEEDOR;
            return ID.ToString();
        }


        public bool Read()
        {
            try
            {
                Dato.PROVEEDOR unProveedor = Conexion.YuyitosDB.PROVEEDOR.First(em => em.ID_PROVEEDOR == ID_PROVEEDOR);
                ID_PROVEEDOR = unProveedor.ID_PROVEEDOR;
                NOMBRE = unProveedor.NOMBRE;
                RUT = unProveedor.RUT;
                DV = unProveedor.DV;
                TELEFONO = unProveedor.TELEFONO;
                RUBRO = unProveedor.RUBRO;
                CIUDAD_ID_CIUDAD = unProveedor.CIUDAD_ID_CIUDAD;

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
    }
}
