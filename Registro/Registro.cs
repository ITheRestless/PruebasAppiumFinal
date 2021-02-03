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

namespace Registro
{
    [TestClass]
    public class Registro
    {
        List<string> logs = new List<string>();
        Stopwatch timer;
        double time;
        AppiumOptions caps;

        public void CapsInit()
        {
            caps = new AppiumOptions();
            caps.AddAdditionalCapability("newCommandTimeout", 30);
            caps.AddAdditionalCapability("browserstack.user", "mauricioemmanuel1");
            caps.AddAdditionalCapability("browserstack.key", "XZYh6tFKBx8KBDyBzbAy");
            caps.AddAdditionalCapability("autoAcceptAlerts", true);
            caps.AddAdditionalCapability("autoGrantPermissions", true);
            caps.AddAdditionalCapability("app", "bs://f406cf05e3b731ce0fce429a6c4777237eaa6946");
            caps.AddAdditionalCapability("device", "Google Pixel 3");
            caps.AddAdditionalCapability("os_version", "9.0");
            caps.PlatformName = "Android";
            caps.AddAdditionalCapability("project", "AppSoriana");
            caps.AddAdditionalCapability("build", "Android");
        }

        public void ScrollDown(AndroidDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 1000)
            .Wait(500)
            .MoveTo(200, 200)
            .Release();

            touchAction.Perform();
        }

        public void ScrollUp(AndroidDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 200)
            .Wait(500)
            .MoveTo(200, 1000)
            .Release();

            touchAction.Perform();
        }

        public void InputText(string id, string text, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
            searchElement.SendKeys(text);
            driver.HideKeyboard();
        }

        public void ClickButton(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
        }

        public void ClickText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );



            searchElement.Click();
        }

        public void ClickClass(string clss, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.ClassName(clss))
            );

            searchElement.Click();
        }

        public bool CheckElement(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement == null)
            {
                Console.WriteLine("Salida inesperada");
                return false;
            }
            else
            {
                Console.WriteLine("Salida correcta");
                return true;
            }
        }

        public bool CheckText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );

            if (searchElement == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void StartTimer()
        {
            timer = Stopwatch.StartNew();
        }

        public double ExecTime()
        {
            return timer.Elapsed.Seconds;
        }

        [TestMethod]
        public void RegistroMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Menu sin tarjeta");

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);
            ClickClass("android.widget.Button", driver);
            CheckText("PruebaAuto" + date + "@yopmail.net", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroHome()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Menu sin tarjeta");

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);
            ClickClass("android.widget.Button", driver);
            CheckText("PruebaAuto" + date + "@yopmail.net", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroCarrito()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Carrito");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString();

            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/imageCart", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);
            ClickClass("android.widget.Button", driver);
            CheckText("PruebaAuto" + date + "@yopmail.net", driver);

            driver.Quit();
        }
    }
}
