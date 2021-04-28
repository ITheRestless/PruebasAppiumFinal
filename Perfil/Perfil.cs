using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;
using System.Threading;

namespace Perfil
{
    [TestClass]
    public class Pefil
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void DatosFiscalesAgregar()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Datos Fiscales");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Mi perfil-- no ecnontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            amb.setState("failed", "Boton -- + -- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_add", driver);

            amb.setState("failed", "Campo --Razon social-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtRazonSoc", "PruebasAutomatizadas", driver);

            amb.setState("failed", "Campo --RFC-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtRfc", "LAN7008173R5", driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Mis datos de facturacion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_facturacion", driver);

            amb.setState("failed", "No se registraron los datos de facturacion", driver);
            amb.ClickText("PruebasAutomatizadas", driver);

            amb.setState("failed", "Error Boton --Eliminar--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("passed", "Datos fiscales registrados y eliminados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void VerificarYActualizarDatos()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mi Perfil - Verificar y cambiar datos personales");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al acceder a --Mi Perfil--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Error al acceder a --Mis datos--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            amb.setState("failed", "--Nombre-- en --Mis Datos-- no concuerda", driver);
            amb.ClickText("Laboratorio Pruebas Automatizadas", driver);
            
            amb.setState("failed", "--Numero de tarjeta-- en --Mis Datos-- no concuerda", driver);
            amb.ClickText("3086-XXXX-XXXX-3860", driver);

            amb.setState("failed", "--Correo electronico-- en --Mis Datos-- no concuerda", driver);
            amb.ClickText("autodevelopmx@gmail.com", driver);

            amb.setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            amb.setState("failed", "Campo --Nombre-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "123456789012345678901234567890", driver);

            amb.setState("failed", "Campo --AP-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAP", "123456789012345678901234567890", driver);

            amb.setState("failed", "Campo --AM-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAM", "123456789012345678901234567890", driver);

            amb.setState("failed", "Campo --Telefono-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editTel", "6182401601", driver);

            amb.setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por primera vez", driver);
            amb.ClickText("123456789012345678901234567890 123456789012345678901234567890 123456789012345678901234567890", driver);

            amb.setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            amb.setState("failed", "Campo --Nombre-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "Laboratorio", driver);

            amb.setState("failed", "Campo --AP-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAP", "Pruebas", driver);

            amb.setState("failed", "Campo --AM-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAM", "Automatizadas", driver);

            amb.setState("failed", "Campo --Telefono-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            amb.setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por segunda ocasion", driver);
            amb.ClickText("Laboratorio Pruebas Automatizadas", driver);

            amb.setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarContraseña()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mi Perfil - Modificar contrasena");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al acceder a --Mi Perfil--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Error al acceder a --Mis datos--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Campo --Contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editOldPass", "developmx12", driver);

            amb.setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editNewPass", "contraseñanueva123.", driver);

            amb.setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editConfirmPass", "contraseñanueva123.", driver);

            amb.setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            amb.setState("failed", "Campo --Contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editOldPass", "contraseñanueva123.", driver);

            amb.setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editNewPass", "developmx12", driver);

            amb.setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editConfirmPass", "developmx12", driver);

            amb.setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            amb.setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }


        [TestMethod]
        public void MisDireccionesMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mis Direcciones - Menu");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

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

            /*
            amb.setState("failed", "Fallo al agregar nueva direcion", driver);
            amb.CheckText("Casa de prueba", driver);
            // Nueva direccion registrada

            // Eliminar la direccion
            amb.setState("failed", "Direccion creada no encontrada", driver);
            amb.ClickText("Casa de prueba", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);
            // direccion eliminada
            */

            amb.setState("passed", "Se agrego y elimino la direccion con exito", driver);

            driver.Quit();
        }

        
        [TestMethod]
        public void MisDireccionesCheckout()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Mis Direcciones - Checkout");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"),
                    amb.caps
                );

            amb.setState("failed", "Boton --Mi Perfil-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            amb.setState("failed", "campo --Correo Electronico-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "campo --Contraseña-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);


            Thread.Sleep(2000);
            amb.ScrollDown(driver);

            amb.setState("failed", "articulo no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnArt", driver);

            amb.setState("failed", "Boton --Domicilio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);


            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);


            Thread.Sleep(2000);

            amb.setState("failed", "Boton --carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Boton --Comprar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/comprarLayout", driver);

            amb.setState("failed", "Boton --Domicilo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Texto --Agregar nueva-- no encontrado", driver);
            amb.ClickText("Agregar", driver);

            amb.setState("failed", "Campo --Codigo Postal-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCP", "27268", driver);

            amb.setState("failed", "Campo --Colonia-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtColonia", "Torreon Residencial", driver);

            amb.setState("failed", "Campo --Calle-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtCalle", "Calle Carrara", driver);

            amb.setState("failed", "Campo --Numero Exterior-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumeroExterior", "421", driver);

            amb.setState("failed", "Campo --Numero Interior-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNumInt", "15", driver);

            amb.setState("failed", "Error al hacer scroll", driver);
            amb.ScrollDown(driver);

            amb.setState("failed", "Campo --Nombre-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtNomDir", "Casa de Pruebas", driver);

            amb.setState("failed", "Campo --Telefono-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/txtTelefonoDomic", "8711199728", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Se pudo aceptar el alert", driver);
            amb.ClickButton("android:id/button1", driver);

            /*
            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            // Eliminar la direccion creada 
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
            */

            amb.setState("failed", "No fue posible comprobar que la direccion se elimino correctamente", driver);
            amb.CheckText("No tienes direcciones agregadas", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("passed", "Se registro satisfactoriamente una nueva direccion desde el checkout", driver);

            driver.Quit();
        }


        [TestMethod]
        public void DetalleDeArticulo()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Listas - Detalle De Articulo");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Listas)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Boton --Agregar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);

            amb.setState("failed", "Error al introducir el nombre de la lista", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "prueba", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Error al buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "DORITOS", driver);

            amb.setState("failed", "No fue posible anadir el articulo --DORITOS--", driver);
            amb.ClickText("BOTANA DORITOS", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            driver.HideKeyboard();

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            amb.setState("failed", "No se comprobo que el articulo fue agregado a la lista", driver);
            amb.CheckText("BOTANA DORITOS", driver);

            amb.setState("failed", "Error al eliminar la lista", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Se agrego correctamente el articulo a la lista", driver);

            driver.Quit();
        }

        // 85
        [TestMethod]
        public void EliminarArticulosDeLista()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Listas - Eliminar articulos de lista");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Listas)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Boton --Agregar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);

            amb.setState("failed", "Error al introducir el nombre de la lista", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "prueba", driver);

            amb.setState("failed", "Boton --Guardar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Error al buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "DORITOS", driver);

            amb.setState("failed", "Articulo --BOTANA DORITOS 155gr-- no encontrado", driver);
            amb.ClickText("BOTANA DORITOS 155", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            driver.HideKeyboard();

            amb.setState("failed", "Boton --Retroceder-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnVolver", driver);

            amb.setState("failed", "Boton --Eliminar Busqueda-- no encontrado", driver);
            amb.ClickButton("android:id/search_close_btn", driver);

            amb.setState("failed", "Error al buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "RUFFLES", driver);

            amb.setState("failed", "No fue posible anadir el articulo --RUFFLES--", driver);
            amb.ClickText("BOTANA RUFFLES", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            driver.HideKeyboard();

            amb.setState("failed", "Boton --Retroceder-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnVolver", driver);

            amb.setState("failed", "Boton --Eliminar Busqueda-- no encontrado", driver);
            amb.ClickButton("android:id/search_close_btn", driver);

            amb.setState("failed", "Error al buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "COCA", driver);

            amb.setState("failed", "Articulo --COCA COLA-- no encontrado", driver);
            amb.ClickText("REFRESCO COCA", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Boton --Anadir a lista-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            driver.HideKeyboard();

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --prueba-- no encontrada", driver);
            amb.ClickText("prueba", driver);

            amb.setState("failed", "Boton --Opciones-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgOptions", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnDelete", driver);

            amb.setState("failed", "Boton --Multiseleccion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnEliminar", driver);

            amb.setState("failed", "Error al eliminar los articulos", driver);
            amb.CheckText("No hay articulos en tu lista", driver);

            amb.setState("failed", "Error al eliminar la lista", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Se eliminaron los articulos de la lista correctamente", driver);

            driver.Quit();
        }
    }
}