using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
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
            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Ayuda - Fecha de Aceptacion Terminos y Condiciones");
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            // Entramos al menú
            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            // Entramos a Ayuda
            amb.setState("failed", "Seccion --Ayuda-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_ayuda", driver);

            // Verificar que estén todas las secciones
            amb.setState("failed", "Seccion --Llamanos-- no encontrada", driver);
            amb.CheckText("Llámanos al", driver);

            amb.setState("failed", "Seccion --Envianos un mensaje-- no encontrada", driver);
            amb.CheckText("un mensaje escrito", driver);

            amb.setState("failed", "Seccion --Tipos de servicio-- no encontrada", driver);
            amb.CheckText("Tipos de servicio", driver);

            amb.setState("failed", "Seccion --Comparte la app-- no encontrada", driver);
            amb.CheckText("Comparte la app", driver);

            // Entramos a la seccion términos y condiciones
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
