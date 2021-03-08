using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Support.UI;
using System;
using System.Diagnostics;
using System.Threading;
using UnitTestProject3;

namespace Ayuda
{
    [TestClass]
    public class Ayuda
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void AyudaMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Ayuda - Fecha de Aceptacion Terminos y Condiciones");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("failed", "Seccion --Ayuda-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_ayuda", driver);

            amb.setState("failed", "Seccion --Llamanos-- no encontrada", driver);
            amb.CheckText("Llámanos al", driver);

            amb.setState("failed", "Seccion --Envianos un mensaje-- no encontrada", driver);
            amb.CheckText("un mensaje escrito", driver);

            amb.setState("failed", "Seccion --Tipos de servicio-- no encontrada", driver);
            amb.CheckText("Tipos de servicio", driver);

            amb.setState("failed", "Seccion --Comparte la app-- no encontrada", driver);
            amb.CheckText("Comparte la app", driver);

            amb.setState("failed", "Seccion --Terminos y condiciones-- no encontrada", driver);
            amb.ClickText("condiciones", driver);

            amb.setState("failed", "Boton --Fecha aceptacion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAceptaste", driver);

            amb.setState("failed", "Fallo al verificar la fecha de aceptacion de los terminos y condiciones", driver);
            amb.CheckText("Acerca de Soriana App", driver);

            amb.setState("passed", "Se verifico correctamente la fecha de aceptacion de los terminos y condiciones", driver);

            driver.Quit();
        }
    }
}
