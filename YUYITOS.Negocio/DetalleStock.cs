using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class DetalleStock
    {
        public int ID_DETALLE_STOCK { get; set; }
        public int CANT_DETALLE_STOCK { get; set; }
        public int CODIGO_BARRA { get; set; }
        public int STOCK_ID_STOCK { get; set; }

        public int PRODUCTO_PROVEEDOR_ID { get; set; }

        public DetalleStock()
        {

        }

        public int getLastId()
        {
            Coleccion col = new Coleccion();
            decimal aux;
            try
            {
                aux = col.ListadoDetalleStock().Max(em => em.ID_DETALLE_STOCK);
            }
            catch (Exception)
            {
                aux = 0;
            }

            return (int)aux;
        }

        public bool Create()
        {
            try
            {
                Dato.DETALLE_STOCK unStock = new Dato.DETALLE_STOCK()
                {
                    ID_DETALLE_STOCK = ID_DETALLE_STOCK,
                    CANT_DETALLE_STOCK = CANT_DETALLE_STOCK,
                    CODIGO_BARRA = CODIGO_BARRA,
                    STOCK_ID_STOCK = STOCK_ID_STOCK,
                    PRODUCTO_PROVEEDOR_ID = PRODUCTO_PROVEEDOR_ID
                };
                Conexion.YuyitosDB.DETALLE_STOCK.Add(unStock);
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
                Dato.DETALLE_STOCK unStock = Conexion.YuyitosDB.DETALLE_STOCK.First(em => em.ID_DETALLE_STOCK == ID_DETALLE_STOCK);
                ID_DETALLE_STOCK = unStock.ID_DETALLE_STOCK;
                CANT_DETALLE_STOCK = unStock.CANT_DETALLE_STOCK;
                CODIGO_BARRA = unStock.CODIGO_BARRA;
                STOCK_ID_STOCK =(int)unStock.STOCK_ID_STOCK;
                PRODUCTO_PROVEEDOR_ID = unStock.PRODUCTO_PROVEEDOR_ID;

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
                Dato.DETALLE_STOCK unStock = Conexion.YuyitosDB.DETALLE_STOCK.First(em => em.ID_DETALLE_STOCK == ID_DETALLE_STOCK);
                unStock.ID_DETALLE_STOCK = ID_DETALLE_STOCK;
                unStock.CANT_DETALLE_STOCK = CANT_DETALLE_STOCK;
                unStock.CODIGO_BARRA = CODIGO_BARRA;
                unStock.STOCK_ID_STOCK = STOCK_ID_STOCK;
                unStock.PRODUCTO_PROVEEDOR_ID = PRODUCTO_PROVEEDOR_ID;
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete()
        {
            try
            {
                Dato.DETALLE_STOCK unStock = Conexion.YuyitosDB.DETALLE_STOCK.First(em => em.ID_DETALLE_STOCK == ID_DETALLE_STOCK);
                Conexion.YuyitosDB.DETALLE_STOCK.Remove(unStock);
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
