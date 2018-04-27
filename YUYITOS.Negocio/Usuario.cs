using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }

        public string CONTRASENHA { get; set; }

        public string TOKEN { get; set; }
        public int TIPO_USUARIO_ID { get; set; }


        public Usuario()
        {

        }


        public bool Read()
        {
            try
            {
                Dato.USUARIO unUsuario = Conexion.YuyitosDB.USUARIO.First(em => em.ID_USUARIO == ID_USUARIO);
                ID_USUARIO = (int)unUsuario.ID_USUARIO;
                NOMBRE_USUARIO = unUsuario.NOMBRE_USUARIO;
                CONTRASENHA = unUsuario.CONTRASENHA;
                TOKEN = unUsuario.TOKEN;
                TIPO_USUARIO_ID = unUsuario.TIPO_USUARIO_ID;

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
                Dato.USUARIO user = new Dato.USUARIO()
                {
                    ID_USUARIO = ID_USUARIO,
                    NOMBRE_USUARIO = NOMBRE_USUARIO,
                    CONTRASENHA = CONTRASENHA,
                    TOKEN = TOKEN,
                    TIPO_USUARIO_ID = TIPO_USUARIO_ID
                };
                Conexion.YuyitosDB.USUARIO.Add(user);
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
                Dato.USUARIO user = Conexion.YuyitosDB.USUARIO.First(p => p.ID_USUARIO == ID_USUARIO);
                user.ID_USUARIO = ID_USUARIO;
                user.NOMBRE_USUARIO = NOMBRE_USUARIO;
                user.CONTRASENHA = CONTRASENHA;
                user.TOKEN = TOKEN;
                user.TIPO_USUARIO_ID = TIPO_USUARIO_ID;
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
