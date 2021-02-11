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
using System.Text.RegularExpressions;

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

        public string ObtenerCodigoRegistro(string usr)
        {

            int count1 = usr.Length;
            string count2 = Convert.ToString(Regex.Matches(usr, "a").Count);
            string count3 = Convert.ToString(Regex.Matches(usr, "e").Count);
            string count4 = Convert.ToString(Regex.Matches(usr, "i").Count);
            string count5 = Convert.ToString(Regex.Matches(usr, "o").Count);
            string count6 = Convert.ToString(Regex.Matches(usr, "u").Count);

            var strCode = count1 + count2 + count3 + count4 + count5 + count6;
            return strCode.Substring(0, 6);
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
        public void CrearTarjetaVirtual()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - Crear tarjeta virtual y aceptar los terminos y condiciones");

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

            setState("failed", "Error al introducir el codigo de confirmacion", driver);
            InputText("com.soriana.appsoriana:id/editCodigoConfirmacion", ObtenerCodigoRegistro("PruebaAuto" + date + "@yopmail.net"), driver);

            setState("failed", "Error al presionar el boton --Continuar--", driver);
            ClickButton("com.soriana.appsoriana:id/btnConfirmar", driver);

            setState("failed", "Error al presionar el boton --Finalizar Registro--", driver);
            ClickText("Finalizar registro", driver);

            setState("failed", "Error al presionar el boton --Comenzar-- en la pantalla de cuenta creada", driver);
            ClickButton("com.soriana.appsoriana:id/btnComenzar", driver);

            setState("failed", "Error al aceptar los terminos y condiciones", driver);
            ClickButton("com.soriana.appsoriana:id/btnAceptar", driver);

            ClickText("PruebaAuto", driver);
            setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroNoAceptarTerminosYCondiciones()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Registro - No aceptar terminos y condiciones");

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

            setState("failed", "Error al introducir el codigo de confirmacion", driver);
            InputText("com.soriana.appsoriana:id/editCodigoConfirmacion", ObtenerCodigoRegistro("PruebaAuto" + date + "@yopmail.net"), driver);

            setState("failed", "Error al presionar el boton --Continuar--", driver);
            ClickButton("com.soriana.appsoriana:id/btnConfirmar", driver);

            setState("failed", "Error al presionar el boton --Finalizar Registro--", driver);
            ClickText("Finalizar registro", driver);

            setState("failed", "Error al presionar el boton --Comenzar-- en la pantalla de cuenta creada", driver);
            ClickButton("com.soriana.appsoriana:id/btnComenzar", driver);

            setState("failed", "Error al aceptar los terminos y condiciones", driver);
            ClickButton("com.soriana.appsoriana:id/btnNoAceptar", driver);

            setState("failed", "No regreso a la pantalla de inicio de sesion", driver);
            ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            setState("passed", "No registrado con exito", driver);

            driver.Quit();
        }
    }
}
