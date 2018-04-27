using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class TipoAlimento
    {
        public int ID_TIPO_ALIMENTO { get; set; }
        public string DESCRIPCION { get; set; }

        public TipoAlimento()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.TIPO_ALIMENTO unAlimento = Conexion.YuyitosDB.TIPO_ALIMENTO.First(em => em.ID_TIPO_ALIMENTO == ID_TIPO_ALIMENTO);
                ID_TIPO_ALIMENTO = (int)unAlimento.ID_TIPO_ALIMENTO;
                DESCRIPCION = unAlimento.DESCRIPCION;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
