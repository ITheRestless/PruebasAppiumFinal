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

namespace Perfil
{
    [TestClass]
    public class Pefil
    {
        Stopwatch timer;
        double time;
        AppiumOptions caps;

        public void CapsInit()
        {
            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            caps = new AppiumOptions();
            caps.AddAdditionalCapability("newCommandTimeout", 20);
            caps.AddAdditionalCapability("browserstack.user", "mauricioemmanuel1");
            caps.AddAdditionalCapability("browserstack.key", "XZYh6tFKBx8KBDyBzbAy");
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
        public void VerificarYActualizarDatos()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mi Perfil - Verificar y cambiar datos personales");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al acceder a --Mi Perfil--", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Error al acceder a --Mis datos--", driver);
            ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda", driver);
            ClickText("Laboratorio Pruebas Automatizadas", driver);

<<<<<<< HEAD
            amb.setState("failed", "--Numero de tarjeta-- en --Mis Datos-- no concuerda", driver);
            amb.ClickText("3086-XXXX-XXXX-3860", driver);
=======
            setState("failed", "--Numero de tarjeta-- en --Mis Datos-- no concuerda", driver);
            ClickText("2496000021042", driver);
>>>>>>> BranchMamalonaDeIvan

            setState("failed", "--Correo electronico-- en --Mis Datos-- no concuerda", driver);
            ClickText("autodevelopmx@gmail.com", driver);

            setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "123456789012345678901234567890", driver);

            setState("failed", "Campo --AP-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "123456789012345678901234567890", driver);

            setState("failed", "Campo --AM-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "123456789012345678901234567890", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "6182401601", driver);

            setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por primera vez", driver);
            ClickText("123456789012345678901234567890 123456789012345678901234567890 123456789012345678901234567890", driver);

            setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "Laboratorio", driver);

            setState("failed", "Campo --AP-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "Pruebas", driver);

            setState("failed", "Campo --AM-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Automatizadas", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por segunda ocasion", driver);
            ClickText("Laboratorio Pruebas Automatizadas", driver);

            setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarContraseña()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mi Perfil - Modificar contrasena");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al acceder a --Mi Perfil--", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Error al acceder a --Mis datos--", driver);
            ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            ScrollDown(driver);

            setState("failed", "Campo --Contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editOldPass", "developmx12", driver);

            setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNewPass", "contraseñanueva123.", driver);

            setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editConfirmPass", "contraseñanueva123.", driver);

            setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            setState("failed", "Campo --Contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editOldPass", "contraseñanueva123.", driver);

            setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNewPass", "developmx12", driver);

            setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editConfirmPass", "developmx12", driver);

            setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }
    }
}