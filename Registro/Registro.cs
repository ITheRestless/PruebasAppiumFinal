using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using System.Text.RegularExpressions;
using UnitTestProject3;

namespace Registro
{
    [TestClass]
    public class Registro
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

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

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

            amb.setState("failed", "Error al aceptar los terminos y condiciones", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnAceptar", driver);

            amb.ClickText("PruebaAuto", driver);
            amb.setState("passed", "Registrado con exito faltando confirmacion de email", driver);

            driver.Quit();
        }

        [TestMethod]
        public void RegistroNoAceptarTerminosYCondiciones()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Registro - No aceptar terminos y condiciones");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Registro)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            string date = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.setState("failed", "Boton --Inicio-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            amb.setState("failed", "Boton --Iniciar sesion-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciarSesion", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);

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

            amb.setState("failed", "Error al aceptar los terminos y condiciones", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnNoAceptar", driver);

            amb.setState("failed", "No regreso a la pantalla de inicio de sesion", driver);
            amb.ClickButton("com.soriana.appsoriana:id/btnRegistrate", driver);

            amb.setState("passed", "No registrado con exito", driver);

            driver.Quit();
        }
    }
}
