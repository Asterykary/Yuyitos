using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Tipo_producto
    {
        public int ID_TIPO_PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }

        public Tipo_producto()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.TIPO_PRODUCTO unDetalleR = Conexion.YuyitosDB.TIPO_PRODUCTO.First(em => em.ID_TIPO_PRODUCTO == ID_TIPO_PRODUCTO);
                ID_TIPO_PRODUCTO = (int)unDetalleR.ID_TIPO_PRODUCTO;
                DESCRIPCION = unDetalleR.DESCRIPCION;


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
                Dato.TIPO_PRODUCTO tproducto = new Dato.TIPO_PRODUCTO()
                {
                    ID_TIPO_PRODUCTO = ID_TIPO_PRODUCTO,
                    DESCRIPCION = DESCRIPCION
                };
                Conexion.YuyitosDB.TIPO_PRODUCTO.Add(tproducto);
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
                Dato.TIPO_PRODUCTO tproducto = Conexion.YuyitosDB.TIPO_PRODUCTO.First(p => p.ID_TIPO_PRODUCTO == ID_TIPO_PRODUCTO);
                tproducto.ID_TIPO_PRODUCTO = ID_TIPO_PRODUCTO;
                tproducto.DESCRIPCION = DESCRIPCION;

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
