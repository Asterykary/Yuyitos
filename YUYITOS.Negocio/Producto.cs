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
        public int Id_producto { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Id_tipo_producto { get; set; }
        public int Id_familia { get; set; }
        public int? Id_tipo_alimento { get; set; }
        private int? _Cantidad;

        public int? Cantidad
        {
            get { return _Cantidad; }
            set {
                if (value > 0)
                    _Cantidad = value;
                else
                    throw new ArgumentException("La cantidad debe ser mayor a 0");
            }
        }


        public string Nombre_Ciudad { get; set; }

        public Producto()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.PRODUCTO unProducto = Conexion.YuyitosDB.PRODUCTO.First(em => em.ID_PRODUCTO == Id_producto);
                Id_producto = unProducto.ID_PRODUCTO;
                Descripcion = unProducto.DESCRIPCION;
                Precio = (int)unProducto.PRECIO;
                Id_tipo_producto = (int)unProducto.TIPO_PRODUCTO_ID_TIPO_PRODUCTO;
                Id_familia = (int)unProducto.FAMILIA_ID_FAMILIA;
                Id_tipo_alimento = (int)unProducto.TIPO_ALIMENTO_ID_TIPO_ALIMENTO;

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }

    }
}
