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

namespace Ayuda
{
    [TestClass]
    public class Ayuda
    {
        Stopwatch timer;
        double time;
        AppiumOptions caps;

        public void CapsInit()
        {
            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            caps = new AppiumOptions();
            caps.AddAdditionalCapability("newCommandTimeout", 20);
            caps.AddAdditionalCapability("browserstack.user", "ivnalejandrorodr1");
            caps.AddAdditionalCapability("browserstack.key", "CxgPJMGN4ip3NSunHFfT");
            caps.AddAdditionalCapability("autoAcceptAlerts", true);
            caps.AddAdditionalCapability("autoGrantPermissions", true);
            caps.AddAdditionalCapability("app", "bs://62e46a9f2171f17a2869efe8964bddda54644423");
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

        public void ClickText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );



            searchElement.Click();
        }

        public void InputText(string id, string text, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(20)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
            searchElement.Clear();
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

        public void CheckText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );
        }

        public void setState(string state, string arguments, AndroidDriver<AndroidElement> driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + state + "\", \"reason\": \" " + arguments + " \"}}");
        }

        public void LogIn(AndroidDriver<AndroidElement> driver)
        {
            ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);
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
        public void AyudaMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Ayuda - Fecha de Aceptacion Terminos y Condiciones");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            StartTimer();

            // Entramos al menú
            setState("failed", "Seccion --Menu-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            // Entramos a Ayuda
            setState("failed", "Seccion --Ayuda-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/item_ayuda", driver);

            // Verificar que estén todas las secciones
            setState("failed", "Seccion --Llamanos-- no encontrada", driver);
            CheckText("Llámanos al", driver);

            setState("failed", "Seccion --Envianos un mensaje-- no encontrada", driver);
            CheckText("un mensaje escrito", driver);

            setState("failed", "Seccion --Tipos de servicio-- no encontrada", driver);
            CheckText("Tipos de servicio", driver);

            setState("failed", "Seccion --Comparte la app-- no encontrada", driver);
            CheckText("Comparte la app", driver);

            // Entramos a la seccion términos y condiciones
            setState("failed", "Seccion --Terminos y condiciones-- no encontrada", driver);
            ClickText("condiciones", driver);

            setState("failed", "Boton --Fecha aceptacion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAceptaste", driver);

            setState("failed", "Fallo al verificar la fecha de aceptacion de los terminos y condiciones", driver);
            CheckText("Acerca de Soriana App", driver);

            setState("passed", "Se verifico correctamente la fecha de aceptacion de los terminos y condiciones", driver);

            driver.Quit();
        }
    }
}
