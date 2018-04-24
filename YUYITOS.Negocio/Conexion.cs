using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUYITOS.Dato;

namespace YUYITOS.Negocio
{
    internal class Conexion
    {
        private static Entities _yuyitosDB;
        public static Entities YuyitosDB
        {
            get
            {
                if (_yuyitosDB == null)
                {
                    _yuyitosDB = new Entities();
                }
                return _yuyitosDB;
            }
            set { _yuyitosDB = value; }
        }
    }

}
