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

namespace Carrito
{
    [TestClass]
    public class Carrito
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

        public string GetElemenText(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            return searchElement.GetAttribute("text");
        }

        public bool CheckElementText(string id, string text, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(10)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement.GetAttribute("text") != text)
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
        public void VerificarArticulos()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Verificar listado de articulos");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Seccion --Listas-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            setState("failed", "Lista --Mis Favoritos-- no encontrada", driver);
            ClickText("Mis Favoritos", driver);

            setState("failed", "Opcion --Seleccionar todo-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);

            setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            setState("failed", "Seccion --Inicio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Carrito-- no enontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Cantidad de productos no concuerda o no se agregaron todos los productos", driver);
            CheckText("JUGO DEL VALLE", driver);
            CheckText("BOTANA RUFFLES", driver);

            setState("failed", "Boton --Eliminar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void VerificarPrecios()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Verificar precios");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al añadir lista a carrito", driver);

            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickText("Mis Favoritos", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            ClickButton("android:id/button1", driver);
            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Error al verificar articulos", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "PAPAS SABRITAS no agregado o encontrado", driver);
            ClickText("PAPAS SABRITAS", driver);

            double precioSabritas = double.Parse(GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            ClickClass("android.widget.ImageButton", driver);

            setState("failed", "AGUA NATURAL CIEL no agregado o encontrado", driver);
            ClickText("AGUA NATURAL CIEL", driver);

            double precioCiel = double.Parse(GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            ClickClass("android.widget.ImageButton", driver);
            
            ScrollDown(driver);
            ScrollDown(driver);

            if (double.Parse(GetElemenText("com.soriana.appsoriana:id/puntosCompra", driver)) + double.Parse(GetElemenText("com.soriana.appsoriana:id/puntosAdicionales", driver)) != double.Parse(GetElemenText("com.soriana.appsoriana:id/puntosTotales", driver)))
            {
                setState("failed", "Las cantidades en la seccion --Puntos-- no concuerdan", driver);
                driver.Quit();
            }

            ScrollDown(driver);
            ScrollDown(driver);

            if (double.Parse(GetElemenText("com.soriana.appsoriana:id/subtotal", driver).Remove(0, 1)) + double.Parse(GetElemenText("com.soriana.appsoriana:id/envio", driver).Remove(0, 1)) - double.Parse(GetElemenText("com.soriana.appsoriana:id/descuento", driver).Remove(0, 1)) != double.Parse(GetElemenText("com.soriana.appsoriana:id/totalAPagar", driver).Remove(0, 1)))
            {
                setState("failed", "Las cantidades en --Total a pagar-- no concuerdan", driver);
            }

            setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);
            setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarCantidad()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Modificar cantidad");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Seccion --Listas-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            setState("failed", "Lista --Mis Favoritos-- no encontrada", driver);
            ClickText("Mis Favoritos", driver);

            setState("failed", "Boton --Seleccinar todo-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);

            setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            setState("failed", "Seccion --Inicio-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "BOTANA RUFFLES no agregado o encontrado", driver);
            ClickText("BOTANA RUFFLES", driver);

            setState("failed", "Boton --Mas-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnMas", driver);

            setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/txtButtonAddCarrito", driver);

            setState("failed", "Fallo al seleccionar entrega A Domicilio", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Fallo al introducir Codigo Postal", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            ScrollDown(driver);
            
            setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("passed", "Se modifico la cantidad con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void AñadirALista()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Anadir a lista");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al agregar lista", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "ListaCarrito", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);
            setState("failed", "Lista no agregada", driver);
            CheckText("ListaCarrito", driver);

            setState("failed", "Error al añadir lista a carrito", driver);
            ClickText("Mis Favoritos", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            ClickButton("android:id/button1", driver);
            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Error al verificar articulos", driver);
            ClickButton("com.soriana.appsoriana:id/imgOptions", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddList", driver);
            ClickText("ListaCarrito", driver);
            ClickClass("android.widget.ImageButton", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickText("ListaCarrito", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);

            setState("passed", "Añadido y eliminado con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ComentarArticulo()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Comentar Articulo");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al añadir lista a carrito", driver);

            setState("failed", "Seccion --Listas-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            setState("failed", "Lista --Mis favoritos-- no encontrada", driver);
            ClickText("Mis Favoritos", driver);

            setState("failed", "Boton --Seleccionar todo-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);

            setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Error al verificar articulos", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Error al comentar articulo", driver);
            ClickButton("com.soriana.appsoriana:id/imgComment", driver);
            InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un comentario de prueba", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            setState("failed", "No se guardo el comentario", driver);
            CheckText("Esto es un comentario de prueba", driver);

            ClickButton("com.soriana.appsoriana:id/deleteComment", driver);

            setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);
            setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarComentario()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Modificar Comentario");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al añadir lista a carrito", driver);

            ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            ClickText("Mis Favoritos", driver);
            ClickButton("com.soriana.appsoriana:id/select_all", driver);
            ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            ClickButton("android:id/button1", driver);
            ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Error al verificar articulos", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Error al comentar articulo", driver);
            ClickButton("com.soriana.appsoriana:id/imgComment", driver);
            InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un comentario de prueba", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            setState("failed", "No se guardo el comentario", driver);
            CheckText("Esto es un comentario de prueba", driver);

            InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un segundo comentario de prueba", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            setState("failed", "No se modifico el comentario", driver);
            CheckText("Esto es un segundo comentario de prueba", driver);

            ClickButton("com.soriana.appsoriana:id/deleteComment", driver);

            setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            ClickButton("android:id/button1", driver);
            setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void VerificarPromociones()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Verificar Promociones");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            ScrollDown(driver);

            setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            
            ClickButton("android:id/button1", driver);
            
            setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }
    }
}
