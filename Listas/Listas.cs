using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;

namespace Listas
{
    [TestClass]
    public class Listas
    {
        Ambiente amb = new Ambiente();

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
