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

namespace Banners
{
    [TestClass]
    public class Banners
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void BannersHome()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Banners - Acceder al Banner");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Vista --Banners-- no encontrada", driver);
            amb.ClickClass("android.view.View", driver);

            amb.setState("failed", "No fue posible acceder al Banner", driver);
            amb.CheckText("productos", driver);

            amb.setState("passed", "Se accedio al Banner de forma correcta", driver);

            driver.Quit();
        }
    }
}
