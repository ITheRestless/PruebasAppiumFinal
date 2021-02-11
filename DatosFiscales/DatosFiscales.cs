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

namespace DatosFiscales
{
    [TestClass]
    public class DatosFiscales
    {
        Stopwatch timer;
        double time;
        AppiumOptions caps;

        public void CapsInit()
        {
            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
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
            caps.AddAdditionalCapability("build", "Android " + fecha);
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

        public void ClickText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );



            searchElement.Click();
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
        public void DatosFiscalesAgregar()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Datos Fiscales");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            //--------------------------Secuencia----------------------------------
            StartTimer();

            setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Iniciar session-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "Boton --Iniciar session-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "campo --Correo Electronico-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            setState("failed", "campo --Contraseña-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            setState("failed", "Boton --Iniciar session-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            setState("failed", "Boton --Inicio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Mi perfil-- no ecnontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            setState("failed", "Boton -- + -- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_add", driver);

            setState("failed", "Campo --Razon social-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtRazonSoc", "PruebasAutomatizadas", driver);

            setState("failed", "Campo --RFC-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtRfc", "LAN7008173R5", driver);

            setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            setState("failed", "Boton --Guardar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            setState("failed", "No se registraron los datos de facturacion", driver);
            ClickText("PruebasAutomatizadas", driver);

            setState("failed", "Error Boton --Eliminar--", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("passed", "Datos fiscales registrados y eliminados con exito", driver);

            driver.Quit();
        }
    }
}
