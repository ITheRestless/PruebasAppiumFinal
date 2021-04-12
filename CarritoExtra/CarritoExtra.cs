using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using UnitTestProject3;

namespace CarritoExtra
{
    [TestClass]
    public class CarritoExtra
    {
        Ambiente amb = new Ambiente();

        // 52 
        [TestMethod]
        public void ElegirCP()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito Cambio de Tienda - Elegir entrega a domicilio e ingresar CP");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            amb.InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopcarrito3@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Seccion --Tipo de entrega-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/textViewTipoEntrega", driver);

            amb.setState("failed", "Seccion --A domicilio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Error al introducir el codigo postal", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            amb.setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            amb.setState("failed", "No se realizo el cambio", driver);
            amb.CheckText("Código Postal 27268", driver);

            amb.setState("passed", "Se selecciono correctamente la entrega a domicilio mediante el CP", driver);

            driver.Quit();
        }

        // 53
        [TestMethod]
        public void NuevaDireccionCheckout()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Introducir nueva direccion desde checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            amb.InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopcarrito3@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            // Comprobar que no haya direcciones registradas
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            // Agregar articulos a carrito desde Mis Favoritos
            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --Mis favoritos-- no encontrada", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "Boton --Seleccionar todo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Boton --Continuar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            amb.setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Opcion --Agregar nueva direccion-- no encontrada", driver);
            amb.ClickText("Agregar nueva", driver);

            // Agregar nueva direccion desde checkout
            amb.setState("failed", "Error al introducir nueva direccion", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            amb.ScrollDown(driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);

            amb.setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada desde checkout
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Direccion creada desde checkout no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }

        // 54
        [TestMethod]
        public void SeleccionarDireccionExistenteDesdeCheckout()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Seleccionar direccion existente desde checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            amb.InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopcarrito3@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            // Registrar nueva dirección
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Boton --Agregar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_add", driver);

            amb.setState("failed", "Error al registrar nueva direccion", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            driver.HideKeyboard();
            amb.ScrollDown(driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            driver.HideKeyboard();
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            driver.HideKeyboard();

            amb.setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Fallo al agregar nueva direcion", driver);
            amb.CheckText("Casa de prueba", driver);
            // Nueva direccion registrada

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            // Agregar articulos a carrito desde Mis Favoritos
            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --Mis favoritos-- no encontrada", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "Boton --Seleccionar todo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Boton --Continuar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            amb.setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "No se encontro una direccion previamente registrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "No se procedio a la seleccion de Fecha/Hora", driver);
            amb.CheckText("Mañana", driver);

            // Vaciar el carrito
            amb.setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada 
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Direccion creada no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }

        // 55
        [TestMethod]
        public void ElegirEntregaEnTienda()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito Cambio de Tienda - Elegir entrega en tienda");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            amb.InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopcarrito3@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Seccion --Tipo de entrega-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/textViewTipoEntrega", driver);

            amb.setState("failed", "No fue posible selecionar un estado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/spinnerEstado", driver);

            amb.setState("failed", "Estado --BAJA CALIFORNIA SUR-- no encontrado", driver);
            amb.ClickText("BAJA CALIFORNIA", driver);

            amb.setState("failed", "No fue posible seleccionar una ciudad", driver);
            amb.ClickButton("com.soriana.appsoriana:id/spinnerCiudad", driver);

            amb.setState("failed", "Ciudad --MEXICALI-- no encontrada", driver);
            amb.ClickText("MEXICALI", driver);

            amb.setState("failed", "No fue posible seleccionar una sucursal", driver);
            amb.ClickButton("com.soriana.appsoriana:id/spinnerSucursal", driver);

            amb.setState("failed", "Sucursal --CALAFIA-- no encontrada", driver);
            amb.ClickText("CALAFIA", driver);

            amb.setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            amb.setState("failed", "No se realizo el cambio de sucursal", driver);
            amb.CheckText("Soriana Calafia", driver);

            amb.setState("passed", "Se selecciono una sucursal correctamente", driver);

            driver.Quit();
        }

        // 56
        [TestMethod]
        public void SeleccionarFechaHoraDeEnvio()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Seleccionar Fecha y Hora de Envio");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            amb.InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopcarrito3@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            // Agregar articulos a carrito desde Mis Favoritos
            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --Mis favoritos-- no encontrada", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "Boton --Seleccionar todo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Boton --Continuar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);
            // fin de agregar articulos a carrito dese mis favoritos

            amb.setState("failed", "Opcion --Entrega a domicilio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Opcion --Agregar nueva direccion-- no encontrada", driver);
            amb.ClickText("Agregar nueva", driver);

            // Agregar nueva direccion desde checkout
            amb.setState("failed", "Error al introducir nueva direccion", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de prueba", driver);
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8714851911", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle de prueba", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "344", driver);
            amb.ScrollDown(driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Colonia de prueba", driver);

            amb.setState("failed", "Boton --Guardar direccion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            // Seleccionar fecha y hora de envío
            amb.setState("failed", "Seccion --Fecha/Hora de envio-- no encontrada", driver);
            amb.ClickText("Fecha/Hora", driver);

            amb.setState("failed", "Error al seleccionar la fecha de entrega", driver);
            amb.ClickText("Mañana", driver);

            amb.setState("failed", "Error al seleccionar el horario de entrega", driver);
            amb.ClickText("PM", driver);

            amb.setState("failed", "No se procedio al metodo de pago", driver);
            amb.CheckText("Pagar al recibir", driver);

            //Vaciar el carrito
            amb.setState("failed", "Boton --Vaciar carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada desde checkout
            amb.setState("failed", "Seccion --Mi Perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Seccion --Mis direcciones-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_direcciones", driver);

            amb.setState("failed", "Direccion creada desde checkout no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }

    }
}
