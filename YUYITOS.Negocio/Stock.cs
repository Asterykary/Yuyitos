using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Stock
    {
        public decimal ID_STOCK { get; set; }
        public System.DateTime FECHA_VENCIMIENTO { get; set; }
        public decimal CODIGO_BARRA { get; set; }
        public int PRODUCTO_ID_PRODUCTO { get; set; }
        public decimal PROVEEDOR_ID_PROVEEDOR { get; set; }

        public Stock()
        {

        }

        public int getLastId()
        {
            Coleccion col = new Coleccion();
            decimal aux;
            try
            {
                aux = col.ListadoStock().Max(em => em.ID_STOCK);
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
                Dato.STOCK unStock = new Dato.STOCK()
                {
                    ID_STOCK = ID_STOCK,
                    FECHA_VENCIMIENTO = FECHA_VENCIMIENTO,
                    CODIGO_BARRA = CODIGO_BARRA,
                    PRODUCTO_ID_PRODUCTO = PRODUCTO_ID_PRODUCTO,
                    PROVEEDOR_ID_PROVEEDOR = PROVEEDOR_ID_PROVEEDOR
                };
                Conexion.YuyitosDB.STOCK.Add(unStock);
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
                Dato.STOCK unStock = Conexion.YuyitosDB.STOCK.First(em => em.ID_STOCK == ID_STOCK);
                ID_STOCK = unStock.ID_STOCK;
                FECHA_VENCIMIENTO = unStock.FECHA_VENCIMIENTO;
                CODIGO_BARRA = unStock.CODIGO_BARRA;
                PROVEEDOR_ID_PROVEEDOR = unStock.PROVEEDOR_ID_PROVEEDOR;
                PRODUCTO_ID_PRODUCTO = unStock.PRODUCTO_ID_PRODUCTO;

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
                Dato.STOCK unStock = Conexion.YuyitosDB.STOCK.First(em => em.ID_STOCK == ID_STOCK);
                unStock.ID_STOCK = ID_STOCK;
                unStock.FECHA_VENCIMIENTO = FECHA_VENCIMIENTO;
                unStock.CODIGO_BARRA = CODIGO_BARRA;
                unStock.PROVEEDOR_ID_PROVEEDOR = PROVEEDOR_ID_PROVEEDOR;
                unStock.PRODUCTO_ID_PRODUCTO = PRODUCTO_ID_PRODUCTO;
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
                Dato.STOCK unStock = Conexion.YuyitosDB.STOCK.First(em => em.ID_STOCK == ID_STOCK);
                Conexion.YuyitosDB.STOCK.Remove(unStock);
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
