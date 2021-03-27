using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;

namespace AgregarACarrito
{
    [TestClass]
    public class AgregarACarrito
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
    }
}
