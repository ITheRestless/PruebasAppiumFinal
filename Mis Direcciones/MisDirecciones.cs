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
using OpenQA.Selenium;

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
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            AndroidElement searchElement = (AndroidElement)wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(MobileBy.Id(id)));

            try {
                searchElement.Click();
            } catch (OpenQA.Selenium.NoSuchElementException e) {
                throw e;
                Console.WriteLine("Exception: {0}", e);
            }
        }

        public void ClickText(string txt, AndroidDriver<AndroidElement> driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            AndroidElement searchElement = (AndroidElement)wait.Until(
                    SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                        MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")")
                    )
                );

            try {
                searchElement.Click();
            } catch (OpenQA.Selenium.NoSuchElementException e) {
                throw e;
                Console.WriteLine("Exception: {0}", e);
            }
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

        public void setState(string state, string arguments, AndroidDriver<AndroidElement> driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + state + "\", \"reason\": \" " + arguments + " \"}}");
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

        [TestMethod]
        public void MisDireccionesMenu()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mis Direcciones - Menu");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

           LogIn(driver);

            // Registrar nueva dirección
            setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            setState("failed", "Boton --Agregar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_add", driver);

            setState("failed", "Error al registrar nueva direccion", driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            driver.HideKeyboard();
            InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);
            driver.HideKeyboard();
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            driver.HideKeyboard();
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            driver.HideKeyboard();
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            driver.HideKeyboard();
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            driver.HideKeyboard();

            setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "Fallo al agregar nueva direcion", driver);
            CheckText("Casa de prueba", driver);
            // Nueva direccion registrada

            // Eliminar la direccion
            setState("failed", "Direccion creada no encontrada", driver);
            ClickText("Casa de prueba", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);
            // direccion eliminada

            setState("passed", "Se agrego y elimino la direccion con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void MisDireccionesCheckout()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mis Direcciones - Checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"),
                    caps
                );

            //--------------------------Secuencia----------------------------------
            StartTimer();

            setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            setState("failed", "campo --Correo Electronico-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            setState("failed", "campo --Contraseña-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            setState("failed", "Boton --Inicio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);


            Thread.Sleep(2000);
            ScrollDown(driver);

            setState("failed", "articulo no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnArt", driver);

            setState("failed", "Boton --Domicilio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);


            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);


            Thread.Sleep(2000);

            setState("failed", "Boton --carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Boton --Comprar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);

            setState("failed", "Boton --Domicilo-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Texto --Agregar nueva-- no encontrado", driver);
            ClickText("Agregar", driver);


            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de Pruebas", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8711199728", driver);

            setState("failed", "Campo --Calle-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle Carrara", driver);

            setState("failed", "Campo --Numero Exterior-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "421", driver);

            setState("failed", "Campo --Numero Interior-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtNumInt", "15", driver);

            setState("failed", "Error al hacer scroll", driver);
            ScrollDown(driver);

            setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            setState("failed", "Campo --Colonia-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/txtColonia", "Torreon Residencial", driver);

            setState("failed", "Boton --Guardar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "No se registro la direccion", driver);
            ClickText("Casa de Pruebas", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Se pudo aceptar el alert", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada 
            setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            setState("failed", "Direccion creada desde checkout no encontrada", driver);
            ClickText("Casa de prueba", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);
            // direccion eliminada

            setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            CheckText("No tienes direcciones agregadas", driver);

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }
    }
}
