using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Login
{
    [TestClass]
    public class LogIn
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

        public void setState(string state, string arguments, AndroidDriver<AndroidElement> driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + state + "\", \"reason\": \" " + arguments + " \"}}");
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
        public void LogInMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn - Menu");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            setState("failed", "Seccion --Mi perfil-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Inicia sesion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            setState("failed", "Error al ingresar el correo electronico", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            setState("failed", "Error al ingresar la contrasena", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "No fue posible verificar que se haya registrado el usuario correcto", driver);
            CheckText("Hola Laboratorio", driver);

            setState("passed", "Se inicio sesion de manera exitosa", driver);

            driver.Quit();
        }

        [TestMethod]
        public void LogInHome()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn - Home");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            //--------------------------Secuencia----------------------------------
            StartTimer();

            ClickButton("com.soriana.appsoriana:id/imgArrow", driver);

            setState("failed", "No se mostro o no se pudo presionar el boton de inicio", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "No se mostro o no se pudo llenar el campo de email", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            setState("failed", "No se mostro o no se pudo llenar el campo de contraseña", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            setState("failed", "No se mostro o no se pudo presionar boton de LogIn", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            setState("failed", "No se mostro el nombre del usuario en la ventana home", driver);
            CheckText("Hola Laboratorio", driver);

            setState("passed", "Se inicio sesion con exito", driver);
            
            driver.Quit();
        }

        [TestMethod]
        public void LogInCarrito()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "LogIn - Carrito");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);


            setState("failed", "No se mostró o no se pudó presionar el icono de carrito", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "No se mostró o no se pudó presionar el boton de inicio", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            setState("failed", "No se mostró o no se pudó llenar el campo de email", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            setState("failed", "No se mostró o no se pudó llenar el campo de contraseña", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            setState("failed", "No se mostró o no se pudó presionar boton de LogIn", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            setState("failed", "No se mostró el nombre del usuario en la ventana home", driver);
            CheckText("Hola Laboratorio", driver);

            setState("passed", "Iniciado sesion con exito", driver);
            
            driver.Quit();
        }
    }
}
