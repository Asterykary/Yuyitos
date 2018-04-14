using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUYITOS.Datos;

namespace YUYITOS.Negocios
{
    internal class Conexion
    {
        private static Entities _dBYuyitos;

        public static Entities DByuyitos
        {
            get
            {
                if(_dBYuyitos == null)
                {
                    _dBYuyitos = new Entities();
                }
                return _dBYuyitos;
            }
            set
            {
                _dBYuyitos = value;
            }
        }

    }
}
