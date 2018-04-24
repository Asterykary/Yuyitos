using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUYITOS.Dato;

namespace YUYITOS.Negocio
{
    public class Ciudad
    {
        public int ID_CIUDAD { get; set; }
        public string DESCRIPCION { get; set; }

        public Ciudad()
        {

        }

        public bool Buscar()
        {
            try
            {
                Dato.CIUDAD ciu = Conexion.YuyitosDB.CIUDAD.First(c => c.ID_CIUDAD == ID_CIUDAD);
                ID_CIUDAD = ciu.ID_CIUDAD;
                DESCRIPCION = ciu.DESCRIPCION;
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
