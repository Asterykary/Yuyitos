using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Cliente
    {
        private int _rut_cliente;
        private string _dv;

        public string Rut
        {
            get
            {
                return string.Format("{0}-{1}", _rut_cliente.ToString("0,0"), _dv);
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
                if (!int.TryParse(value, out _rut_cliente) || (!int.TryParse(_dv, out dvn) && _dv != "k"))
                {
                    throw new ArgumentException("Rut no es válido");
                }

            }
        }

        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }

        public bool Read()
        {
            try
            {
                Dato.CLIENTE unCliente = Conexion.YuyitosDB.CLIENTE.First(em => em.RUT_CLIENTE == _rut_cliente && em.DV == _dv);
                Rut = unCliente.RUT_CLIENTE + unCliente.DV;
                NOMBRE = unCliente.NOMBRE;
                APELLIDOS = unCliente.APELLIDOS;
                

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
                Dato.CLIENTE client = new Dato.CLIENTE()
                {
                    RUT_CLIENTE = _rut_cliente,
                    DV = _dv,
                    NOMBRE = NOMBRE,
                    APELLIDOS = APELLIDOS
                };
                Conexion.YuyitosDB.CLIENTE.Add(client);
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
                Dato.CLIENTE client = Conexion.YuyitosDB.CLIENTE.First(c => c.RUT_CLIENTE == _rut_cliente && c.DV == _dv);
                client.RUT_CLIENTE = _rut_cliente;
                client.NOMBRE = NOMBRE;
                client.APELLIDOS = APELLIDOS;
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
