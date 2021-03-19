using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;

namespace Carrito
{
    [TestClass]
    public class Carrito
    {
        Ambiente amb = new Ambiente();

        [TestMethod]
        public void VerificarArticulos()
        {
            

            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Verificar listado de articulos");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("Mis Favoritos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);


            if (!amb.CheckElementText("com.soriana.appsoriana:id/txtItems", "2", driver))
            {
                amb.setState("failed", "Cantidad de productos no concuerda o no se agregaron todos los productos", driver);
                driver.Quit();
            }

            amb.ClickButton("com.soriana.appsoriana:id/txtItems", driver);

            amb.setState("failed", "PAPAS SABRITAS no agregado o encontrado", driver);
            amb.CheckText("PAPAS SABRITAS", driver);

            amb.setState("failed", "AGUA NATURAL CIEL no agregado o encontrado", driver);
            amb.CheckText("AGUA NATURAL CIEL", driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);
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

            amb.setState("failed", "PAPAS SABRITAS no agregado o encontrado", driver);
            amb.ClickText("PAPAS SABRITAS", driver);

            double precioSabritas = double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.setState("failed", "AGUA NATURAL CIEL no agregado o encontrado", driver);
            amb.ClickText("AGUA NATURAL CIEL", driver);

            double precioCiel = double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/artPrecio", driver).Remove(0, 1));
            amb.ClickClass("android.widget.ImageButton", driver);

            amb.ScrollDown(driver);
            amb.ScrollDown(driver);

            if (double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosCompra", driver)) + double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosAdicionales", driver)) != double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/puntosTotales", driver)))
            {
                amb.setState("failed", "Las cantidades en la seccion --Puntos-- no concuerdan", driver);
                driver.Quit();
            }

            amb.ScrollDown(driver);
            amb.ScrollDown(driver);

            if (double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/subtotal", driver).Remove(0, 1)) + double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/envio", driver).Remove(0, 1)) - double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/descuento", driver).Remove(0, 1)) != double.Parse(amb.GetElemenText("com.soriana.appsoriana:id/totalAPagar", driver).Remove(0, 1)))
            {
                amb.setState("failed", "Las cantidades en --Total a pagar-- no concuerdan", driver);
            }

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);
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

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("Mis Favoritos", driver);
            amb.ClickButton("com.soriana.appsoriana:id/select_all", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAddCart", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "PAPAS SABRITAS no agregado o encontrado", driver);
            amb.ClickText("PAPAS SABRITAS", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnMas", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtButtonAddCarrito", driver);

            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);

            amb.ClickClass("android.widget.ImageButton", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);
            amb.setState("passed", "Productos agregados y verificados con exito", driver);

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

        [TestMethod]
        public void VerificarPromociones()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Carrito - Verificar Promociones");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Carrito)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Error al eliminar o presionar el boton de eliminar", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);

            amb.ClickButton("android:id/button1", driver);

            amb.setState("passed", "Productos agregados y verificados con exito", driver);

            driver.Quit();
        }
    }
}
