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

namespace TarjetaDeLealtad
{
    [TestClass]
    public class TarjetaDeLealtad
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void TarjetaLealtad()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Tarjeta de Lealtad - Actualizar, Verificar y Vincular tarjeta");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al presionar --Mi Perfil--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Error al presionar --Mi tarjeta--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_mi_tarjeta", driver);

            amb.ScrollDown(driver);
            amb.setState("failed", "Error al presionar boton --Actualizar tarjeta--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnEnlazarTarjeta", driver);

            amb.setState("failed", "Error al introducir numero de tarjeta", driver);
            amb.InputText("com.soriana.appsoriana:id/editNumTarjeta", "3086812845843860", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Numero de tarjeta no coincide", driver);
            amb.CheckText("3086-XXXX-XXXX-3860", driver);

            amb.setState("passed", "Registrada y verificada con exito", driver);

            driver.Quit();
        }
    }
}
