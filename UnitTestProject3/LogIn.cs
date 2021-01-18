using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;

namespace UnitTestProject3
{
    [TestClass]
    public class LogIn
    {
        Stopwatch timer;
        double time;
        AppiumOptions caps;

        public void CapsInit()
        {
            caps = new AppiumOptions();

            caps.AddAdditionalCapability("browserstack.user", "mauricioemmanuel1");
            caps.AddAdditionalCapability("browserstack.key", "XZYh6tFKBx8KBDyBzbAy");
            caps.AddAdditionalCapability("autoAcceptAlerts", true);
            caps.AddAdditionalCapability("autoGrantPermissions", true);
            caps.AddAdditionalCapability("app", "bs://f406cf05e3b731ce0fce429a6c4777237eaa6946");
            caps.AddAdditionalCapability("device", "Google Pixel 3");
            caps.AddAdditionalCapability("os_version", "9.0");
            caps.PlatformName = "Android";
            caps.AddAdditionalCapability("project", "LogIn - Nueva Interfaz");
            caps.AddAdditionalCapability("build", "Android - LogIn - Nueva Interfaz");
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

        public void StartTimer()
        {
            timer = Stopwatch.StartNew();
        }

        public double ExecTime()
        {
            return timer.Elapsed.Seconds;
        }

        [TestMethod]
        public void LogInMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn-Menu");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            if (CheckElement("com.soriana.appsoriana:id/txtNombreUsuario", driver))
            {
                Console.WriteLine("Ejecucion Exitosa");
            }

            Console.WriteLine("Tiempo de ejecucion : " + (time = ExecTime()));

            driver.Quit();
        }

        [TestMethod]
        public void LogInHome()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn-Home");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            if (CheckElement("com.soriana.appsoriana:id/txtNombreUsuario", driver))
            {
                Console.WriteLine("Ejecucion Exitosa");
            }

            Console.WriteLine("Tiempo de ejecucion : " + (time = ExecTime()));
            driver.Quit();
        }

        [TestMethod]
        public void LogInCarrito()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn-Carrito");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/imageCart", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            if (CheckElement("com.soriana.appsoriana:id/txtNombreUsuario", driver))
            {
                Console.WriteLine("Ejecucion Exitosa");
            }

            Console.WriteLine("Tiempo de ejecucion : " + (time = ExecTime()));

            driver.Quit();
        }

        /*
        [TestMethod]
        public void LogInError()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn-Menu");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);
            InputText("com.soriana.appsoriana:id/editPass", "adhjadgfj", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            if (CheckElement("com.soriana.appsoriana:id/txtNombreUsuario", driver))
            {
                Console.WriteLine("Ejecucion Exitosa");
            }

            Console.WriteLine("Tiempo de ejecucion : " + (time = ExecTime()));

            driver.Quit();
        }*/
    }
}
