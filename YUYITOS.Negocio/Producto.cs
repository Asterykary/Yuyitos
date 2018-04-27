using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YUYITOS.Dato;

namespace YUYITOS.Negocio
{
    public class Producto
    {
        public int ID_PRODUCTO { get; set; }
        public string DESCRIPCION { get; set; }
        public int PRECIO_COMPRA { get; set; }
        public int TIPO_PRODUCTO_ID { get; set; }
        public int FAMILIA_ID { get; set; }
        public int? TIPO_ALIMENTO_ID { get; set; }
       

        public Producto()
        {

        }

        public bool Create()
        {
            try
            {
                Dato.PRODUCTO unProducto = new Dato.PRODUCTO()
                {
                    ID_PRODUCTO = ID_PRODUCTO,
                    DESCRIPCION = DESCRIPCION,
                    PRECIO_COMPRA = PRECIO_COMPRA,
                    TIPO_PRODUCTO_ID = TIPO_PRODUCTO_ID,
                    FAMILIA_ID = FAMILIA_ID,
                    TIPO_ALIMENTO_ID = TIPO_ALIMENTO_ID
                };
                Conexion.YuyitosDB.PRODUCTO.Add(unProducto);
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool Read()
        {
            try
            {
                Dato.PRODUCTO unProducto = Conexion.YuyitosDB.PRODUCTO.First(em => em.ID_PRODUCTO == ID_PRODUCTO);
                ID_PRODUCTO = unProducto.ID_PRODUCTO;
                DESCRIPCION = unProducto.DESCRIPCION;
                PRECIO_COMPRA = (int)unProducto.PRECIO_COMPRA;
                TIPO_PRODUCTO_ID = (int)unProducto.TIPO_PRODUCTO_ID;
                FAMILIA_ID = (int)unProducto.FAMILIA_ID;
                TIPO_ALIMENTO_ID = (int)unProducto.TIPO_ALIMENTO_ID;

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

        public bool Update()
        {
            try
            {
                Dato.PRODUCTO unProducto = Conexion.YuyitosDB.PRODUCTO.First(em => em.ID_PRODUCTO == ID_PRODUCTO);
                unProducto.ID_PRODUCTO = ID_PRODUCTO;
                unProducto.DESCRIPCION = DESCRIPCION;
                unProducto.PRECIO_COMPRA = PRECIO_COMPRA;
                unProducto.TIPO_PRODUCTO_ID = TIPO_PRODUCTO_ID;
                unProducto.FAMILIA_ID = FAMILIA_ID;
                unProducto.TIPO_ALIMENTO_ID = TIPO_ALIMENTO_ID;
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
