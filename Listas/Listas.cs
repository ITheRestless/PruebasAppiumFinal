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

namespace Listas
{
    [TestClass]
    public class Listas
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void DetalleDeArticulo()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Listas - Detalle De Articulo");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "ListaPrueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.CheckText("ListaPrueba", driver);

            amb.ClickText("ListaPrueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/productosFragment", driver);
            amb.ClickText("DESPENSA", driver);
            amb.InputText("android:id/search_src_text", "atun", driver);
            amb.ClickText("LOMO DE ATÚN HERDEZ EN AGUA 130 GR", driver);
            amb.ScrollDown(driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);
            amb.ClickText("ListaPrueba", driver);
            driver.HideKeyboard();
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("ListaPrueba", driver);

            amb.CheckText("LOMO DE ATÚN", driver);

            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Lista registrada con exito", driver);

            driver.Quit();
        }
    }
}
