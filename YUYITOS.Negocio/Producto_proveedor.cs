using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Producto_proveedor
    {
        public int ID_PRODUCTO_P { get; set; }
        public int PRODUCTO_ID { get; set; }
        public int PROVEEDOR_ID { get; set; }
        public int PRECIO_VENTA { get; set; }

        public Producto_proveedor()
        {

        }

        public bool Read()
        {
            try
            {
                Dato.PRODUCTO_PROVEEDOR unProdProve = Conexion.YuyitosDB.PRODUCTO_PROVEEDOR.First(em => em.ID_PRODUCTO_P == ID_PRODUCTO_P);
                ID_PRODUCTO_P = unProdProve.ID_PRODUCTO_P;
                PRODUCTO_ID = unProdProve.PRODUCTO_ID;
                PROVEEDOR_ID = (int)unProdProve.PROVEEDOR_ID;
                PRECIO_VENTA = unProdProve.PRECIO_VENTA;



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
                Dato.PRODUCTO_PROVEEDOR prodprov = new Dato.PRODUCTO_PROVEEDOR()
                {
                    ID_PRODUCTO_P = ID_PRODUCTO_P,
                    PRODUCTO_ID = PRODUCTO_ID,
                    PROVEEDOR_ID = PROVEEDOR_ID,
                    PRECIO_VENTA = PRECIO_VENTA
                };
                Conexion.YuyitosDB.PRODUCTO_PROVEEDOR.Add(prodprov);
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
                Dato.PRODUCTO_PROVEEDOR prodprov = Conexion.YuyitosDB.PRODUCTO_PROVEEDOR.First(p => p.ID_PRODUCTO_P == ID_PRODUCTO_P);
                prodprov.ID_PRODUCTO_P = ID_PRODUCTO_P;
                prodprov.PRODUCTO_ID = PRODUCTO_ID;
                prodprov.PROVEEDOR_ID = PROVEEDOR_ID;
                prodprov.PRECIO_VENTA = PRECIO_VENTA;

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
