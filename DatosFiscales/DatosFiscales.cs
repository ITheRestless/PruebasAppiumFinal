using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium;
using UnitTestProject3;

namespace DatosFiscales
{
    [TestClass]
    public class DatosFiscales
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void DatosFiscalesAgregar()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Datos Fiscales");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Mi perfil-- no ecnontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            amb.setState("failed", "Boton -- + -- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_add", driver);

            amb.setState("failed", "Campo --Razon social-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtRazonSoc", "PruebasAutomatizadas", driver);

            amb.setState("failed", "Campo --RFC-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtRfc", "LAN7008173R5", driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            amb.setState("failed", "No se registraron los datos de facturacion", driver);
            amb.ClickText("PruebasAutomatizadas", driver);

            amb.setState("failed", "Error Boton --Eliminar--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("passed", "Datos fiscales registrados y eliminados con exito", driver);

            driver.Quit();
        }
    }
}
