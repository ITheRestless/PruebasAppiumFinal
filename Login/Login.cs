using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;
using System.Text.RegularExpressions;

namespace Login
{
    [TestClass]
    public class LogIn
    {
        Ambiente amb = new Ambiente();
        
        public string ObtenerCodigoRegistro(string usr)
        {
            int count1 = usr.Length;
            string count2 = Convert.ToString(Regex.Matches(usr, "a").Count);
            string count3 = Convert.ToString(Regex.Matches(usr, "e").Count);
            string count4 = Convert.ToString(Regex.Matches(usr, "i").Count);
            string count5 = Convert.ToString(Regex.Matches(usr, "o").Count);
            string count6 = Convert.ToString(Regex.Matches(usr, "u").Count);

            var strCode = count1 + count2 + count3 + count4 + count5 + count6;
            return strCode.Substring(0, 6);
        }

        [TestMethod]
        public void CrearTarjetaVirtual()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Registro - Crear tarjeta virtual y aceptar los terminos y condiciones");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Registro)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Registrate-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            amb.setState("failed", "Campo --Nombre-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editNombre", "PruebaAuto" + date, driver);

            amb.setState("failed", "Campo --Apellido paterno-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAP", "Dev", driver);

            amb.setState("failed", "Campo --Apellido materno-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editAM", "Mx", driver);

            amb.setState("failed", "Campo --Email-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editMail", "PruebaAuto" + date + "@yopmail.net", driver);

            amb.setState("failed", "Campo --Telefono-- no encontrado", driver);
            amb.InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            amb.setState("failed", "Campo --Contraseña-- no encontrado", driver);
            amb.ScrollDown(driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "Contramamona12.", driver);
            amb.InputText("com.soriana.appsoriana:id/editConfirm", "Contramamona12.", driver);

            amb.ClickButton("com.soriana.appsoriana:id/checkBoxTerminos", driver);

            amb.setState("failed", "Boton --Registrar-- no encontrado", driver);
            amb.ClickClass("android.widget.Button", driver);

            amb.setState("failed", "Error al introducir el codigo de confirmacion", driver);
            amb.InputText("com.soriana.appsoriana:id/editCodigoConfirmacion", ObtenerCodigoRegistro("PruebaAuto" + date + "@yopmail.net"), driver);

            amb.setState("failed", "Error al presionar el boton --Continuar--", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnConfirmar", driver);

            amb.setState("failed", "Error al presionar el boton --Finalizar Registro--", driver);
            amb.ClickText("Finalizar registro", driver);

            amb.setState("failed", "Error al presionar el boton --Comenzar-- en la pantalla de cuenta creada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnComenzar", driver);

            amb.ClickText("PruebaAuto", driver);
            amb.setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }

        [TestMethod]
        public void LogInMenu()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Menu");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Login)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.setState("failed", "Seccion --Mi perfil-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Inicia sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);

            amb.setState("failed", "Error al ingresar el correo electronico", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "Error al ingresar la contrasena", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "Seccion --Inicio-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/nuevoInicioFragment", driver);

            amb.setState("failed", "No fue posible verificar que se haya registrado el usuario correcto", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Se inicio sesion de manera exitosa", driver);

            driver.Quit();
        }

        [TestMethod]
        public void LogInHome()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Home");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Login)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.ClickButton("com.soriana.appsoriana:id/imgArrow", driver);

            amb.setState("failed", "No se mostro o no se pudo presionar el boton de inicio", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            amb.setState("failed", "No se mostro o no se pudo llenar el campo de email", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "No se mostro o no se pudo llenar el campo de contraseña", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "No se mostro o no se pudo presionar boton de LogIn", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "No se mostro el nombre del usuario en la ventana home", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Se inicio sesion con exito", driver);
            
            driver.Quit();
        }

        [TestMethod]
        public void LogInCarrito()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "LogIn - Carrito");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Login)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);


            amb.setState("failed", "No se mostró o no se pudó presionar el icono de carrito", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imageCart", driver);

            amb.setState("failed", "No se mostró o no se pudó presionar el boton de inicio", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

            amb.setState("failed", "No se mostró o no se pudó llenar el campo de email", driver);
            amb.InputText("com.soriana.appsoriana:id/editEmail", "autodevelopmx@gmail.com", driver);

            amb.setState("failed", "No se mostró o no se pudó llenar el campo de contraseña", driver);
            amb.InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);

            amb.setState("failed", "No se mostró o no se pudó presionar boton de LogIn", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btn_login", driver);

            amb.setState("failed", "No se mostró el nombre del usuario en la ventana home", driver);
            amb.CheckText("Hola Laboratorio", driver);

            amb.setState("passed", "Iniciado sesion con exito", driver);
            
            driver.Quit();
        }
    }
}
