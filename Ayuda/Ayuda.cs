using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Threading;
using UnitTestProject3;

namespace Ayuda
{
    [TestClass]
    public class Ayuda
    {
        Ambiente amb = new Ambiente();   

        /*
        [TestMethod]
        public void AyudaMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Ayuda - Fecha de Aceptacion Terminos y Condiciones");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
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
        }*/

        [TestMethod]
        public void VerMas()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Super en casa - Ver mas");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "No encontrado boton --Ver mas--", driver);
            amb.ClickText("Ver más", driver);

            amb.setState("passed", "Boton --Ver mas-- Funcionando", driver);

            driver.Quit();
        }

        [TestMethod]
        public void EnviarFeedback()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Feedback - Enviar Feedback");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);


            amb.setState("failed", "Boton --Menu-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("failed", "Seccion --Danos tu opinion-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_feedback", driver);

            amb.setState("failed", "No fue posible seleccionar un emoji para calificar la experiencia", driver);
            amb.ClickButton("com.soriana.appsoriana:id/moodNeutral", driver);

            amb.setState("failed", "No fue posible seleccionar el tipo de comentario", driver);
            amb.ClickButton("com.soriana.appsoriana:id/rbOtro", driver);

            amb.setState("failed", "No fue posible escribir un comentario", driver);
            amb.InputText("com.soriana.appsoriana:id/editMensaje", "Prueba feedback", driver);

            amb.setState("failed", "Boton --Enviar-- no encontrado", driver);
            amb.ScrollDown(driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnEnviarFeedback", driver);

            Thread.Sleep(2000);

            amb.setState("failed", "Fallo al enviar el comentario", driver);
            amb.CheckText("Inicio", driver);

            amb.setState("passed", "Se enviaron los comentarios correctamente", driver);

            driver.Quit();
        }

        // 89
        [TestMethod]
        public void VerificarFolletos()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Folletos - Verificar folletos disponibles y acceder");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("failed", "Seccion --Folletos-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_folletos", driver);

            amb.setState("failed", "Seccion --Soriana Super-- no encontrada", driver);
            amb.ClickText("Soriana Súper", driver);

            amb.ScrollDown(driver);
            Thread.Sleep(1000);
            amb.ScrollUp(driver);

            amb.setState("failed", "Folleto no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgFolleto", driver);

            amb.setState("failed", "Error al cambiar de pagina", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);


            amb.setState("failed", "Seccion --Soriana Hiper-- no encontrada", driver);
            amb.ClickText("Soriana Híper", driver);

            amb.ScrollDown(driver);
            Thread.Sleep(1000);
            amb.ScrollUp(driver);

            amb.setState("failed", "Folleto no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgFolleto", driver);

            amb.setState("failed", "Error al cambiar de pagina", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("passed", "Se verificaron los folletos correctamente", driver);

            driver.Quit();
        }
    }
}
