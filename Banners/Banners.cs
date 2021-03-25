using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
using UnitTestProject3;

namespace Banners
{
    [TestClass]
    public class Banners
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void BannersHome()
        {
            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Banners - Acceder al Banner");
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Vista --Banners-- no encontrada", driver);
            amb.ClickClass("android.view.View", driver);

            amb.setState("failed", "No fue posible acceder al Banner", driver);
            amb.CheckElement("com.soriana.appsoriana:id/btnArt", driver);

            amb.setState("passed", "Se accedio al Banner de forma correcta", driver);

            driver.Quit();
        }
    }
}
