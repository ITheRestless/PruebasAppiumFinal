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

namespace Mis_Direcciones
{
    [TestClass]
    public class MisDirecciones
    {
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

        public bool CheckElement(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(5)).Until(
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
        public void MisDireccionesMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mis Direcciones - Menu");

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
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);
            ClickButton("com.soriana.appsoriana:id/action_add", driver);
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de Pruebas", driver);
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8711199728", driver);
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle Carrara", driver);
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "421", driver);
            InputText("com.soriana.appsoriana:id/txtNumInt", "15", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            InputText("com.soriana.appsoriana:id/txtColonia", "Torreon Residencial", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            driver.Quit();
        }

        [TestMethod]
        public void MisDireccionesCheckout()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mis Direcciones - Checkout");

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
            Thread.Sleep(2000);
            ScrollDown(driver);
            ClickButton("com.soriana.appsoriana:id/btnArt", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);
            Thread.Sleep(2000);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);
            ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            if (CheckElement("com.soriana.appsoriana:id/noHayDirecciones", driver))
            {
                ClickButton("com.soriana.appsoriana:id/noHayDirecciones", driver);
            } else {
                ClickButton("com.soriana.appsoriana:id/txtAgregarNueva", driver);
            }
            
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de Pruebas", driver);
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8711199728", driver);
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle Carrara", driver);
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "421", driver);
            InputText("com.soriana.appsoriana:id/txtNumInt", "15", driver);
            ScrollDown(driver);

            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            InputText("com.soriana.appsoriana:id/txtColonia", "Torreon Residencial", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            driver.Quit();
        }
    }
}
