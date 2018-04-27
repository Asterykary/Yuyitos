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
                    FECHA_VENCIMIENTO = FECHA_VENCIMIENTO
                    
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
