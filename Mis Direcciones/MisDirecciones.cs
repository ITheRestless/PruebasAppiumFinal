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
using System.Threading;
using OpenQA.Selenium;
using UnitTestProject3;

namespace Mis_Direcciones
{
    [TestClass]
    public class MisDirecciones
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void MisDireccionesMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mis Direcciones - Menu");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            // Registrar nueva dirección
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Boton --Agregar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_add", driver);

            amb.setState("failed", "Error al registrar nueva direccion", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            driver.HideKeyboard();
            amb.ScrollDown(driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            driver.HideKeyboard();

            amb.setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Fallo al agregar nueva direcion", driver);
            amb.CheckText("Casa de prueba", driver);
            // Nueva direccion registrada

            // Eliminar la direccion
            amb.setState("failed", "Direccion creada no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada

            amb.setState("passed", "Se agrego y elimino la direccion con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void MisDireccionesCheckout()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mis Direcciones - Checkout");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"),
                    amb.caps
                );

            amb.setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            amb.setState("failed", "campo --Correo Electronico-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "campo --Contraseña-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);


            Thread.Sleep(2000);
            amb.ScrollDown(driver);

            amb.setState("failed", "articulo no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnArt", driver);

            amb.setState("failed", "Boton --Domicilio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);


            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);


            Thread.Sleep(2000);

            amb.setState("failed", "Boton --carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Boton --Comprar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);

            amb.setState("failed", "Boton --Domicilo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Texto --Agregar nueva-- no encontrado", driver);
            amb.ClickText("Agregar", driver);


            amb.setState("failed", "Campo --Nombre-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de Pruebas", driver);

            amb.setState("failed", "Campo --Telefono-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8711199728", driver);

            amb.setState("failed", "Campo --Calle-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle Carrara", driver);

            amb.setState("failed", "Campo --Numero Exterior-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "421", driver);

            amb.setState("failed", "Campo --Numero Interior-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumInt", "15", driver);

            amb.setState("failed", "Error al hacer scroll", driver);
            amb.ScrollDown(driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            amb.setState("failed", "Campo --Colonia-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Torreon Residencial", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "No se registro la direccion", driver);
            amb.ClickText("Casa de Pruebas", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Se pudo aceptar el alert", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada 
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Direccion creada desde checkout no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }
    }
}
