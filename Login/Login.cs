using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;
using UnitTestProject3;

namespace Login
{
    [TestClass]
    public class LogIn
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void LogInMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Menu");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.setState("failed", "Seccion --Mi perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Inicia sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            amb.setState("failed", "Error al ingresar el correo electronico", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "Error al ingresar la contrasena", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "No fue posible verificar que se haya registrado el usuario correcto", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Se inicio sesion de manera exitosa", driver);

            driver.Quit();
        }

        [TestMethod]
        public void LogInHome()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Home");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);


            //--------------------------Secuencia----------------------------------
            amb.StartTimer();

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);

            amb.setState("failed", "No se mostro o no se pudo presionar el boton de inicio", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            amb.setState("failed", "No se mostro o no se pudo llenar el campo de email", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "No se mostro o no se pudo llenar el campo de contraseña", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "No se mostro o no se pudo presionar boton de LogIn", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "No se mostro el nombre del usuario en la ventana home", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Se inicio sesion con exito", driver);
            
            driver.Quit();
        }

        [TestMethod]
        public void LogInCarrito()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Carrito");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);


            amb.setState("failed", "No se mostró o no se pudó presionar el icono de carrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "No se mostró o no se pudó presionar el boton de inicio", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            amb.setState("failed", "No se mostró o no se pudó llenar el campo de email", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "No se mostró o no se pudó llenar el campo de contraseña", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "No se mostró o no se pudó presionar boton de LogIn", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "No se mostró el nombre del usuario en la ventana home", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Iniciado sesion con exito", driver);
            
            driver.Quit();
        }
    }
}
