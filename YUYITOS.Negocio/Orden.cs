﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUYITOS.Negocio
{
    public class Orden
    {
        public decimal ID_ORDEN { get; set; }
        public decimal ID_USUARIO { get; set; }
        public System.DateTime CREADO_EN { get; set; }
        public decimal PROVEEDOR_ID_PROVEEDOR { get; set; }
        public short ESTADO_ORDEN { get; set; }

        public Orden()
        {

        }

        public int getLastId()
        {
            Coleccion col = new Coleccion();
            decimal aux;
            try
            {
                aux = col.ListadoOrden().Max(em => em.ID_ORDEN);
            }
            catch(Exception)
            {
                aux = 0;
            } 

            return (int)aux;
        }

        public bool Create()
        {
            try
            {
                Dato.ORDEN unaOrden = new Dato.ORDEN()
                {
                    ID_ORDEN = ID_ORDEN,
                    ID_USUARIO = ID_USUARIO,
                    CREADO_EN = CREADO_EN,
                    PROVEEDOR_ID_PROVEEDOR = PROVEEDOR_ID_PROVEEDOR,
                    ESTADO_ORDEN = ESTADO_ORDEN


                };
                Conexion.YuyitosDB.ORDEN.Add(unaOrden);
                Conexion.YuyitosDB.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Read()
        {
            try
            {
                Dato.ORDEN unaOrden = Conexion.YuyitosDB.ORDEN.First(em => em.ID_ORDEN == ID_ORDEN);
                ID_ORDEN = unaOrden.ID_ORDEN;
                ID_USUARIO = unaOrden.ID_USUARIO;
                CREADO_EN = unaOrden.CREADO_EN;
                PROVEEDOR_ID_PROVEEDOR = unaOrden.PROVEEDOR_ID_PROVEEDOR;
                ESTADO_ORDEN = unaOrden.ESTADO_ORDEN;


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
                Dato.ORDEN unaOrden = Conexion.YuyitosDB.ORDEN.First(em => em.ID_ORDEN == ID_ORDEN);
                unaOrden.ID_USUARIO = ID_USUARIO;
                unaOrden.ID_ORDEN = ID_ORDEN;
                unaOrden.CREADO_EN = CREADO_EN;
                unaOrden.PROVEEDOR_ID_PROVEEDOR = PROVEEDOR_ID_PROVEEDOR;
                unaOrden.ESTADO_ORDEN = ESTADO_ORDEN;
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
                Dato.ORDEN unaOrden = Conexion.YuyitosDB.ORDEN.First(em => em.ID_ORDEN == ID_ORDEN);
                Conexion.YuyitosDB.ORDEN.Remove(unaOrden);
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
