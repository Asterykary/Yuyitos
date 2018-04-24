using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Proveedor
    {
        public decimal ID_PROVEEDOR { get; set; }
        public string NOMBRE { get; set; }
        public int RUT { get; set; }
        public string DV { get; set; }
        public int TELEFONO { get; set; }
        public string RUBRO { get; set; }
        public int CIUDAD_ID_CIUDAD { get; set; }
        public string Nombre_Ciudad { get; set; }

        public Proveedor()
        {
            init();
        }

        private void init()
        {
            ID_PROVEEDOR = 0;
            NOMBRE = "";
            RUT = 0;
            DV = "7";
            TELEFONO = 123456;
            RUBRO = "MIAU";
            CIUDAD_ID_CIUDAD = 1;
        }

        public int GetId()
        {
            Coleccion col = new Coleccion();
            decimal aux;
            try
            {
                aux = col.ListadoDetalleOrden().Max(em => em.ID_DETALLE_ORDEN);
            }
            catch (Exception)
            {
                aux = 0;
            }

            return (int)aux;
        }


        public bool Read()
        {
            try
            {
                Dato.PROVEEDOR unProveedor = Conexion.YuyitosDB.PROVEEDOR.First(em => em.ID_PROVEEDOR == ID_PROVEEDOR);
                ID_PROVEEDOR = unProveedor.ID_PROVEEDOR;
                NOMBRE = unProveedor.NOMBRE;
                RUT = unProveedor.RUT;
                DV = unProveedor.DV;
                TELEFONO = unProveedor.TELEFONO;
                RUBRO = unProveedor.RUBRO;
                CIUDAD_ID_CIUDAD = unProveedor.CIUDAD_ID_CIUDAD;

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public bool Registrar()
        {
            try
            {
                Dato.PROVEEDOR prove = new Dato.PROVEEDOR()
                {
                    RUT = RUT,
                    DV = DV,
                    ID_PROVEEDOR = ID_PROVEEDOR,
                    NOMBRE = NOMBRE,
                    TELEFONO = TELEFONO,
                    RUBRO = RUBRO,
                    CIUDAD_ID_CIUDAD = CIUDAD_ID_CIUDAD
                };
                Conexion.YuyitosDB.PROVEEDOR.Add(prove);
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Actualizar()
        {
            try
            {
                Dato.PROVEEDOR prove = Conexion.YuyitosDB.PROVEEDOR.First(p => p.RUT == RUT && p.DV == DV);
                prove.ID_PROVEEDOR = ID_PROVEEDOR;
                prove.NOMBRE = NOMBRE;
                prove.TELEFONO = TELEFONO;
                prove.RUBRO = RUBRO;
                prove.CIUDAD_ID_CIUDAD = CIUDAD_ID_CIUDAD;
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
