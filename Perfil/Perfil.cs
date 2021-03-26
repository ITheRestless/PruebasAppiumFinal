using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Appium.Android;
using UnitTestProject3;

namespace Perfil
{
    [TestClass]
    public class Pefil
    {
        Ambiente amb = new Ambiente();

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
    }
}