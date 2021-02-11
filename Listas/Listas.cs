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

namespace Listas
{
    [TestClass]
    public class Listas
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

        public void StartTimer()
        {
            timer = Stopwatch.StartNew();
        }

        public double ExecTime()
        {
            return timer.Elapsed.Seconds;
        }

        [TestMethod]
        public void DetalleDeArticulo()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Listas - DetalleDeArticulo");

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
            
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "ListaPrueba", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            if (CheckText("ListaPrueba", driver))
            {
                logs.Add("Se añadió correctamente la lista");
            } else
            {
                logs.Add("No se añadió correctamente la lista");
            }

            ClickText("ListaPrueba", driver);
            ClickButton("com.soriana.appsoriana:id/productosFragment", driver);
            ClickText("DESPENSA", driver);
            InputText("android:id/search_src_text", "atun", driver);
            ClickText("LOMO DE ATÚN HERDEZ EN AGUA 130 GR", driver);
            ScrollDown(driver);
            ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);
            ClickText("ListaPrueba", driver);
            driver.HideKeyboard();
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickText("ListaPrueba", driver);

            if(!CheckText("LOMO DE ATÚN", driver))
            {
                logs.Add("No se registró el articulo esperado");
            } else {
                logs.Add("Se registró el articulo esperado");
            }

            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);

            if (CheckText("ListaPrueba", driver))
            {
                logs.Add("No se eliminó correctamente la lista");
            } else
            {
                logs.Add("Se eliminó correctamente la lista");
            }

            setState("pass", "Lista registrada con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void CarritoBotonGuardarLista()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Listas - CarritoBotonGuardar");

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

            setState("failed", "Pestaña --Departamentos-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/productosFragment", driver);
            
            ClickText("DESPENSA", driver);
            InputText("android:id/search_src_text", "atun", driver);
            ClickText("LOMO DE ATÚN HERDEZ EN AGUA 130 GR", driver);
            ScrollDown(driver);
            ClickButton("com.soriana.appsoriana:id/bntAgregarACarrito", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);
            driver.HideKeyboard();
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);
            ClickButton("com.soriana.appsoriana:id/action_save", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "ListaPruebaDesdeCarrito", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);
            ClickClass("android.widget.ImageButton", driver);
            driver.HideKeyboard();
            driver.HideKeyboard();
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickText("ListaPruebaDesdeCarrito", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);

            setState("pass", "Lista registrada con exito", driver);
            driver.Quit();
        }
    }
}
