using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
<<<<<<< HEAD
using UnitTestProject3;
=======
using System.Diagnostics;
using System.Threading;
>>>>>>> BranchMamalonaDeIvan

namespace CarritoExtra
{
    [TestClass]
    public class CarritoExtra
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

        // 52 
        [TestMethod]
        public void ElegirCP()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito Cambio de Tienda - Elegir entrega a domicilio e ingresar CP");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Seccion --Tipo de entrega-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/textViewTipoEntrega", driver);

            setState("failed", "Seccion --A domicilio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Error al introducir el codigo postal", driver);
            InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            setState("failed", "No se realizo el cambio", driver);
            CheckText("Código Postal 27268", driver);

            setState("passed", "Se selecciono correctamente la entrega a domicilio mediante el CP", driver);

            driver.Quit();
        }

        // 53
        [TestMethod]
        public void NuevaDireccionCheckout()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Introducir nueva direccion desde checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            // Comprobar que no haya direcciones registradas
            setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            CheckText("No tienes direcciones agregadas", driver);

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            // Agregar articulos a carrito desde Mis Favoritos
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

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Boton --Continuar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Opcion --Agregar nueva direccion-- no encontrada", driver);
            ClickText("Agregar nueva", driver);

            // Agregar nueva direccion desde checkout
            setState("failed", "Error al introducir nueva direccion", driver);
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);

            setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada desde checkout
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

        // 54
        [TestMethod]
        public void SeleccionarDireccionExistenteDesdeCheckout()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Seleccionar direccion existente desde checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

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

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            // Agregar articulos a carrito desde Mis Favoritos
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

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Boton --Continuar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "No se encontro una direccion previamente registrada", driver);
            ClickText("Casa de prueba", driver);

            setState("failed", "No se procedio a la seleccion de Fecha/Hora", driver);
            CheckText("Mañana", driver);

            // Vaciar el carrito
            setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada 
            setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            setState("failed", "Direccion creada no encontrada", driver);
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

        // 55
        [TestMethod]
        public void ElegirEntregaEnTienda()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito Cambio de Tienda - Elegir entrega en tienda");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Seccion --Tipo de entrega-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/textViewTipoEntrega", driver);

            setState("failed", "No fue posible selecionar un estado", driver);
            ClickButton("com.soriana.appsoriana:id/spinnerEstado", driver);

            setState("failed", "Estado --BAJA CALIFORNIA SUR-- no encontrado", driver);
            ClickText("BAJA CALIFORNIA", driver);

            setState("failed", "No fue posible seleccionar una ciudad", driver);
            ClickButton("com.soriana.appsoriana:id/spinnerCiudad", driver);

            setState("failed", "Ciudad --MEXICALI-- no encontrada", driver);
            ClickText("MEXICALI", driver);

            setState("failed", "No fue posible seleccionar una sucursal", driver);
            ClickButton("com.soriana.appsoriana:id/spinnerSucursal", driver);

            setState("failed", "Sucursal --CALAFIA-- no encontrada", driver);
            ClickText("CALAFIA", driver);

            setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            setState("failed", "No se realizo el cambio de sucursal", driver);
            CheckText("Soriana Calafia", driver);

            setState("passed", "Se selecciono una sucursal correctamente", driver);

            driver.Quit();
        }

        // 56
        [TestMethod]
        public void SeleccionarFechaHoraDeEnvio()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Carrito - Seleccionar Fecha y Hora de Envio");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            // Agregar articulos a carrito desde Mis Favoritos
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

            setState("failed", "Seccion --Inicio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            setState("failed", "Boton --Carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            setState("failed", "Boton --Continuar-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            setState("failed", "Opcion --Agregar nueva direccion-- no encontrada", driver);
            ClickText("Agregar nueva", driver);

            // Agregar nueva direccion desde checkout
            setState("failed", "Error al introducir nueva direccion", driver);
            InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            ScrollDown(driver);
            InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);

            setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            // Seleccionar fecha y hora de envío
            setState("failed", "Seccion --Fecha/Hora de envio-- no encontrada", driver);
            ClickText("Fecha/Hora", driver);

            setState("failed", "Error al seleccionar la fecha de entrega", driver);
            ClickText("Mañana", driver);

            setState("failed", "Error al seleccionar el horario de entrega", driver);
            ClickText("PM", driver);

            setState("failed", "No se procedio al metodo de pago", driver);
            CheckText("Pagar al recibir", driver);

            //Vaciar el carrito
            setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            setState("failed", "Boton --Aceptar-- no encontrado", driver);
            ClickButton("android:id/button1", driver);

            setState("failed", "Boton --Regresar-- no encontrado", driver);
            ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada desde checkout
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
