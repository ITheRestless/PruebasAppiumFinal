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

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_agregar_lista", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "ListaPrueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            amb.CheckText("ListaPrueba", driver);

            amb.ClickText("ListaPrueba", driver);
            amb.ClickButton("com.soriana.appsoriana:id/productosFragment", driver);
            amb.ClickText("DESPENSA", driver);
            amb.InputText("android:id/search_src_text", "atun", driver);
            amb.ClickText("LOMO DE ATÚN HERDEZ EN AGUA 130 GR", driver);
            amb.ScrollDown(driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAgregarALista", driver);
            amb.ClickText("ListaPrueba", driver);
            driver.HideKeyboard();
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("ListaPrueba", driver);

            amb.CheckText("LOMO DE ATÚN", driver);

            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.CheckText("ListaPrueba", driver);

            amb.setState("pass", "Lista registrada con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void CarritoBotonGuardarLista()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Listas - Carrito Boton Guardar");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Departamentos-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/productosFragment", driver);

            amb.setState("failed", "Seccion --Despensa-- no encontrada", driver);
            amb.ClickText("DESPENSA", driver);

            amb.setState("failed", "Error al buscar un producto", driver);
            amb.InputText("android:id/search_src_text", "atun", driver);

            amb.setState("failed", "Producto --LOMO DE ATUN HERDEZ EN AGUA-- no encontrado", driver);
            amb.ClickText("LOMO DE ATÚN HERDEZ EN AGUA", driver);

            amb.ScrollDown(driver);

            amb.setState("failed", "Boton --Agregar al carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/bntAgregarACarrito", driver);

            amb.setState("failed", "Seccion --A domicilio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/txtDomicilio", driver);

            amb.setState("failed", "Error al ingresar el codigo postal", driver);
            amb.InputText("com.soriana.appsoriana:id/etCodigoPostal", "27268", driver);

            amb.setState("failed", "Boton --Seleccionar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnSeleccionar", driver);
            driver.HideKeyboard();

            amb.setState("failed", "Boton --Carrito-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);


            amb.ClickButton("com.soriana.appsoriana:id/action_save", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "ListaPruebaDesdeCarrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);
            amb.ClickClass("android.widget.ImageButton", driver);
            driver.HideKeyboard();
            driver.HideKeyboard();
            amb.ClickButton("com.soriana.appsoriana:id/misListasFragment", driver);
            amb.ClickText("ListaPruebaDesdeCarrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/action_delete", driver);
            amb.ClickButton("android:id/button1", driver);

            amb.setState("pass", "Lista registrada con exito", driver);
            driver.Quit();
        }

        // 85
        [TestMethod]
        public void EliminarArticulosDeLista()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Listas - Eliminar articulos de lista");

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

            amb.setState("failed", "Articulo --BOTANA 3D DORITOS 180-- no encontrado", driver);
            amb.ClickText("BOTANA 3D DORITOS", driver);

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
            amb.InputText("android:id/search_src_text", "AGUA", driver);

            amb.setState("failed", "Articulo --LOMO DE ATUN HERDEZ EN AGUA-- no encontrado", driver);
            amb.ClickText("LOMO DE ATÚN HERDEZ EN AGUA", driver);

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
            amb.ClickText("COCA COLA", driver);

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
