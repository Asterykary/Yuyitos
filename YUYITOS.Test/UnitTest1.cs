﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YUYITOS.Negocio;

namespace YUYITOS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string esperado = "LIMON 1kg";
            string resultado = "";
            //declaro el objeto
            Producto buscar = new Producto()
            {
                Id_producto = 1
            };

            buscar.Read();

            resultado = buscar.Descripcion;
            
            Assert.AreEqual(esperado, resultado);

        }
    }
}
