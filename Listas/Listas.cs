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
