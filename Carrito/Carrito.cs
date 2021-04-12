using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using System.Collections.Generic;
using UnitTestProject3;
using OpenQA.Selenium;

namespace Carrito
{
    [TestClass]
    public class Carrito
    {
        Ambiente amb = new Ambiente();
        

        [TestMethod]
        public void DetalleDeArticulo()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Detalle de Articulo");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "No se mostro o pudo llenar el campo para buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "agua natural ciel", driver);

            amb.setState("failed", "No se mostro o encontro el producto --AGUA NATURAL CIEL 1LT--", driver);
            amb.ClickText("AGUA NATURAL CIEL 1 LT", driver);

            amb.setState("failed", "No se pudo hacer scroll de pantalla", driver);
            amb.ScrollDown(driver);

            amb.setState("failed", "No se mostro o pudo presionar el boton --Agregar al carrito--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtButtonAddCarrito", driver);

            amb.setState("failed", "No se  mostro o pudo presionar el boton --Domicilio--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "No se encontro o pudo llenar el campo --Codigo Postal--", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            amb.setState("failed", "No se  mostro o pudo presionar el boton --Seleccionar--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            amb.setState("failed", "No se  mostro o pudo presionar el icono de carrito", driver);
            driver.HideKeyboard();
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "No se agrego el articulo al carrito", driver);
            amb.CheckText("AGUA NATURAL CIEL 1 LT", driver);

            amb.setState("failed", "No se pudo borrar el articulo agregado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("passed", "El articulo se agrego y removio del carrito con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void MisListas()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Mis Listas");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "No se pudo acceder o encontrar la pestaña --Listas--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "No se encontro o pudo acceder a la lista --Mis Favoritos--", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "No se pudo marcar los articulos de la lista", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "No se pudó presionar el boton --Añadir al carrito--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "No se pudó aceptar la confirmacion de agregar al carrito", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "No se encontro el boton de volver", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "No se encontro el boton de home", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "No se  mostro o pudo presionar el icono de carrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "No se agrego el articulo al carrito", driver);
            amb.CheckText("BOTANA RUFFLES", driver);

            amb.setState("failed", "No se agrego el articulo al carrito", driver);
            amb.CheckText("AGUA NATURAL", driver);

            amb.setState("failed", "No se logro vaciar el carrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("passed", "El articulo se agrego y removio del carrito con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void VerificarArticulos()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Verificar articulos");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --Mis Favoritos-- no encontrada", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "Opcion --Seleccionar todo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Carrito-- no enontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Cantidad de productos no concuerda o no se agregaron todos los productos", driver);
            amb.CheckText("JUGO DEL VALLE", driver);
            amb.CheckText("BOTANA RUFFLES", driver);

            amb.setState("failed", "Boton --Eliminar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void VerificarPrecios()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Verificar precios");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al añadir lista a carrito", driver);

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("Mis Favoritos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Error al verificar articulos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "BOTANA RUFFLES no agregado o encontrado", driver);
            amb.ClickText("BOTANA RUFFLES", driver);

            double precioSabritas = double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.setState("failed", "JUGO DEL VALLE no agregado o encontrado", driver);
            amb.ClickText("JUGO DEL VALLE", driver);

            double precioCiel = double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.ScrollDown(driver);
            amb.ScrollDown(driver);

            if (double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosCompra", driver)) + double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosAdicionales", driver)) != double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosTotales", driver)))
            {
                amb.setState("passed", "Las cantidades en la seccion --Puntos-- no concuerdan", driver);
                driver.Quit();
            }

            amb.ScrollDown(driver);
            amb.ScrollDown(driver);

            if (double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/subtotal", driver).Remove(0, 1)) + double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/envio", driver).Remove(0, 1)) - double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/descuento", driver).Remove(0, 1)) != double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/totalAPagar", driver).Remove(0, 1)))
            {
                amb.setState("passed", "Las cantidades en --Total a pagar-- no concuerdan", driver);
                driver.Quit();
            }
            
            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickText("Aceptar", driver);
            amb.setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarCantidad()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Modificar cantidad");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Listas-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);

            amb.setState("failed", "Lista --Mis Favoritos-- no encontrada", driver);
            amb.ClickText("Mis Favoritos", driver);

            amb.setState("failed", "Boton --Seleccinar todo-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Boton --Carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "BOTANA RUFFLES no agregado o encontrado", driver);
            amb.ClickText("BOTANA RUFFLES", driver);

            amb.setState("failed", "Boton --Mas-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnMas", driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtButtonAddCarrito", driver);

            amb.setState("failed", "Fallo al seleccionar entrega A Domicilio", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Fallo al introducir Codigo Postal", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            amb.setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.setState("failed", "Boton --Aceptar-- no encontrado", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Se modifico la cantidad con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void AñadirALista()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Anadir a lista");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al agregar lista", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "ListaCarrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);
            amb.setState("failed", "Lista no agregada", driver);
            amb.CheckText("ListaCarrito", driver);

            amb.setState("failed", "Error al añadir lista a carrito", driver);
            amb.ClickText("Mis Favoritos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Error al verificar articulos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgOptions", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddList", driver);
            amb.ClickText("ListaCarrito", driver);
            amb.ClickClass("android.widget.ImageButton", driver);
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("ListaCarrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Añadido y eliminado con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ComentarArticulo()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Comentar Articulo");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al añadir lista a carrito", driver);

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

            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Error al verificar articulos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Error al comentar articulo", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgComment", driver);
            amb.InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un comentario de prueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            amb.ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            amb.setState("failed", "No se guardo el comentario", driver);
            amb.CheckText("Esto es un comentario de prueba", driver);

            amb.ClickButton("com.soriana.appsoriana:id/deleteComment", driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarComentario()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Modificar Comentario");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Error al añadir lista a carrito", driver);

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("Mis Favoritos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "Error al verificar articulos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "Error al comentar articulo", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgComment", driver);
            amb.InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un comentario de prueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            amb.ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            amb.setState("failed", "No se guardo el comentario", driver);
            amb.CheckText("Esto es un comentario de prueba", driver);

            amb.InputText("com.soriana.appsoriana:id/editMensaje", "Esto es un segundo comentario de prueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardarComentario", driver);

            amb.ClickButton("com.soriana.appsoriana:id/imgComment", driver);

            amb.setState("failed", "No se modifico el comentario", driver);
            amb.CheckText("Esto es un segundo comentario de prueba", driver);

            amb.ClickButton("com.soriana.appsoriana:id/deleteComment", driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }
    }
}
