using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Familia
    {
        public int ID_FAMILIA { get; set; }
        public string DESCRIPCION { get; set; }

        public Familia()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.FAMILIA unaFamilia = Conexion.YuyitosDB.FAMILIA.First(em => em.ID_FAMILIA == ID_FAMILIA);
                ID_FAMILIA = (int)unaFamilia.ID_FAMILIA;
                DESCRIPCION = unaFamilia.DESCRIPCION;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


    }
}
