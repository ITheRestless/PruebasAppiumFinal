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
        public void DetalleDeArticulo()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Listas - Detalle De Articulo");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            
            //--------------------------Secuencia----------------------------------
            StartTimer();

            LogIn(driver);
            
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
            caps.AddAdditionalCapability("name", "Listas - Carrito Boton Guardar");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);
            
            StartTimer();

            LogIn(driver);

            setState("failed", "Seccion --Departamentos-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/productosFragment", driver);

            setState("failed", "Seccion --Despensa-- no encontrada", driver);
            ClickText("DESPENSA", driver);

            setState("failed", "Error al buscar un producto", driver);
            InputText("android:id/search_src_text", "atun", driver);

            setState("failed", "Producto --LOMO DE ATUN HERDEZ EN AGUA-- no encontrado", driver);
            ClickText("LOMO DE ATÚN HERDEZ EN AGUA", driver);

            ScrollDown(driver);

            setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/bntAgregarACarrito", driver);
            
            setState("failed", "Seccion --A domicilio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Error al ingresar el codigo postal", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);
            driver.HideKeyboard();

            setState("failed", "Boton --Carrito-- no encontrado", driver);
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

        // 85
        [TestMethod]
        public void EliminarArticulosDeLista()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Listas - Eliminar articulos de lista");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            StartTimer();

            LogIn(driver);

            setState("failed", "Seccion --Listas-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            setState("failed", "Boton --Agregar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);

            setState("failed", "Error al introducir el nombre de la lista", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "prueba", driver);

            setState("failed", "Boton --Guardar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Error al buscar un producto", driver);
            InputText("android:id/search_src_text", "DORITOS", driver);

            setState("failed", "Articulo --BOTANA 3D DORITOS 180-- no encontrado", driver);
            ClickText("BOTANA 3D DORITOS", driver);

            ScrollDown(driver);

            setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            setState("failed", "Lista --prueba-- no encontrada", driver);
            ClickText("prueba", driver);

            driver.HideKeyboard();

            setState("failed", "Boton --Retroceder-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnVolver", driver);

            setState("failed", "Boton --Eliminar Busqueda-- no encontrado", driver);
            ClickButton("android:id/search_close_btn", driver);

            setState("failed", "Error al buscar un producto", driver);
            InputText("android:id/search_src_text", "AGUA", driver);

            setState("failed", "Articulo --LOMO DE ATUN HERDEZ EN AGUA-- no encontrado", driver);
            ClickText("LOMO DE ATÚN HERDEZ EN AGUA", driver);

            ScrollDown(driver);

            setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            setState("failed", "Lista --prueba-- no encontrada", driver);
            ClickText("prueba", driver);

            driver.HideKeyboard();

            setState("failed", "Boton --Retroceder-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnVolver", driver);

            setState("failed", "Boton --Eliminar Busqueda-- no encontrado", driver);
            ClickButton("android:id/search_close_btn", driver);

            setState("failed", "Error al buscar un producto", driver);
            InputText("android:id/search_src_text", "COCA", driver);

            setState("failed", "Articulo --COCA COLA-- no encontrado", driver);
            ClickText("COCA COLA", driver);

            ScrollDown(driver);

            setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            setState("failed", "Lista --prueba-- no encontrada", driver);
            ClickText("prueba", driver);

            driver.HideKeyboard();

            setState("failed", "Seccion --Listas-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            setState("failed", "Lista --prueba-- no encontrada", driver);
            ClickText("prueba", driver);

            setState("failed", "Boton --Opciones-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imgOptions", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnDelete", driver);

            setState("failed", "Boton --Multiseleccion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnEliminar", driver);

            setState("failed", "Error al eliminar los articulos", driver);
            CheckText("No hay articulos en tu lista", driver);

            setState("failed", "Error al eliminar la lista", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("passed", "Se eliminaron los articulos de la lista correctamente", driver);

            driver.Quit();
        }
    }
}
