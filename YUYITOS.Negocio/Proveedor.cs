using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Proveedor
    {
        public int ID_PROVEEDOR { get; set; }
        public string NOMBRE { get; set; }
        private int _rut;
        private string _dv;

        /// Rut con validación
        public string Rut
        {
            get
            {
                return string.Format("{0}-{1}", _rut.ToString("0,0"), _dv);
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Rut no puede ir vacío");
                }
                value = value.Replace(" ", "").Replace(",", "").Replace(".", "").Replace("-", "").ToLower();
                _dv = value[value.Length - 1].ToString();
                value = value.Remove(value.Length - 1);
                int dvn;
                //Verificar
                if (!int.TryParse(value, out _rut) || (!int.TryParse(_dv, out dvn) && _dv != "k"))
                {
                    throw new ArgumentException("Rut no es válido");
                }

            }
        }

        public string EMAIL { get; set; }
        public int TELEFONO { get; set; }
        public string RUBRO { get; set; }
        public int CIUDAD_ID { get; set; }


        public Proveedor()
        {
            init();
        }

        private void init()
        {
            ID_PROVEEDOR = 0;
            NOMBRE = "";
            _rut = 0;
            EMAIL = "";
            TELEFONO = 123456;
            RUBRO = "MIAU";
            CIUDAD_ID = 1;
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
                ID_PROVEEDOR = (int)unProveedor.ID_PROVEEDOR;
                NOMBRE = unProveedor.NOMBRE;
                Rut = unProveedor.RUT + unProveedor.DV;
                EMAIL = unProveedor.EMAIL;
                TELEFONO = unProveedor.TELEFONO;
                RUBRO = unProveedor.RUBRO;
                CIUDAD_ID = unProveedor.CIUDAD_ID;

                return true;
            }
            catch (Exception )
            {
                return false;
            }
        }
        public bool Create()
        {
            try
            {
                Dato.PROVEEDOR prove = new Dato.PROVEEDOR()
                {
                    RUT = _rut,
                    DV = _dv,
                    ID_PROVEEDOR = ID_PROVEEDOR,
                    NOMBRE = NOMBRE,
                    EMAIL = EMAIL,
                    TELEFONO = TELEFONO,
                    RUBRO = RUBRO,
                    CIUDAD_ID = CIUDAD_ID
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

        public bool Update()
        {
            try
            {
                Dato.PROVEEDOR prove = Conexion.YuyitosDB.PROVEEDOR.First(p => p.ID_PROVEEDOR == ID_PROVEEDOR);
                prove.ID_PROVEEDOR = ID_PROVEEDOR;
                prove.NOMBRE = NOMBRE;
                prove.RUT = _rut;
                prove.EMAIL = EMAIL;
                prove.TELEFONO = TELEFONO;
                prove.RUBRO = RUBRO;
                prove.CIUDAD_ID = CIUDAD_ID;
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
