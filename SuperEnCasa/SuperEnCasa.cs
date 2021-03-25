using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;

namespace SuperEnCasa
{
    [TestClass]
    public class SuperEnCasa
    {
        Ambiente amb = new Ambiente();

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
    }
}