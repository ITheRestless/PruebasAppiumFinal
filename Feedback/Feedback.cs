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

namespace Feedback
{
    [TestClass]
    public class Feedback
    {
        Ambiente amb = new Ambiente();

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
            amb.CheckText("Folletos", driver);

            amb.setState("passed", "Se enviaron los comentarios correctamente", driver);

            driver.Quit();
        }
    }
}
