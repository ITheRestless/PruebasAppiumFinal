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
using OpenQA.Selenium;

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
            caps.AddAdditionalCapability("app", "bs://c23a88d88edd54c9d25811a2eed508f30f9ae1e7");
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

        public void setState(string state, string arguments, AndroidDriver<AndroidElement> driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + state + "\", \"reason\": \" " + arguments + " \"}}");
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

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            //--------------------------Secuencia----------------------------------
            StartTimer();

            setState("failed", "Boton --Inicio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "Boton --Registrate-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);

            setState("failed", "Campo --Apellido paterno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);

            setState("failed", "Campo --Apellido materno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);

            setState("failed", "Campo --Email-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            setState("failed", "Campo --Contraseña-- no encontrado", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);

            setState("failed", "Boton --Registrar-- no encontrado", driver);
            ClickClass("android.widget.Button", driver);

            setState("failed", "Proceso de registro completado con error al final", driver);
            ClickText("PruebaAuto" + date + "@yopmail.net", driver);

            setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroHome()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Menu sin tarjeta");

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            //--------------------------Secuencia----------------------------------
            StartTimer();

            setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Iniciar Sesion o Registrarse-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "Boton --Registrate-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);

            setState("failed", "Campo --Apellido paterno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);

            setState("failed", "Campo --Apellido materno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);

            setState("failed", "Campo --Email-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            setState("failed", "Campo --Contraseña-- no encontrado", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);

            setState("failed", "Boton --Registrar-- no encontrado", driver);
            ClickClass("android.widget.Button", driver);

            setState("failed", "Proceso de registro completado con error al final", driver);
            ClickText("PruebaAuto" + date + "@yopmail.net", driver);

            setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroCarrito()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Carrito");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            //--------------------------Secuencia----------------------------------
            StartTimer();

            setState("failed", "No se pudo presionar el boton de carrito", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Boton --Registrate-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);

            setState("failed", "Campo --Apellido paterno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);

            setState("failed", "Campo --Apellido materno-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);

            setState("failed", "Campo --Email-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            setState("failed", "Campo --Contraseña-- no encontrado", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);

            setState("failed", "Boton --Registrar-- no encontrado", driver);
            ClickClass("android.widget.Button", driver);

            setState("failed", "Proceso de registro completado con error al final", driver);
            ClickText("PruebaAuto" + date + "@yopmail.net", driver);

            setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }
    }
}
