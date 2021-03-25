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
            CapsInit();
            caps.AddAdditionalCapability("name", "Mi Perfil - Verificar y cambiar datos personales");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al acceder a --Mi Perfil--", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Error al acceder a --Mis datos--", driver);
            ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda", driver);
            ClickText("Laboratorio Pruebas Automatizadas", driver);

<<<<<<< HEAD
            amb.setState("failed", "--Numero de tarjeta-- en --Mis Datos-- no concuerda", driver);
            amb.ClickText("3086-XXXX-XXXX-3860", driver);
=======
            setState("failed", "--Numero de tarjeta-- en --Mis Datos-- no concuerda", driver);
            ClickText("2496000021042", driver);
>>>>>>> BranchMamalonaDeIvan

            setState("failed", "--Correo electronico-- en --Mis Datos-- no concuerda", driver);
            ClickText("autodevelopmx@gmail.com", driver);

            setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "123456789012345678901234567890", driver);

            setState("failed", "Campo --AP-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "123456789012345678901234567890", driver);

            setState("failed", "Campo --AM-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "123456789012345678901234567890", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "6182401601", driver);

            setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por primera vez", driver);
            ClickText("123456789012345678901234567890 123456789012345678901234567890 123456789012345678901234567890", driver);

            setState("failed", "Boton --Modificar informacion-- no encontrado o deshabilitado", driver);
            ClickButton("com.soriana.appsoriana:id/btnModificarPerfil", driver);

            setState("failed", "Campo --Nombre-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNombre", "Laboratorio", driver);

            setState("failed", "Campo --AP-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAP", "Pruebas", driver);

            setState("failed", "Campo --AM-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editAM", "Automatizadas", driver);

            setState("failed", "Campo --Telefono-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editTel", "8711199728", driver);

            setState("failed", "Error al presionar boton --Guardar informacion--", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardar", driver);

            setState("failed", "--Nombre-- en --Mis Datos-- no concuerda al cambiarlo por segunda ocasion", driver);
            ClickText("Laboratorio Pruebas Automatizadas", driver);

            setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }

        [TestMethod]
        public void ModificarContraseña()
        {
            CapsInit();
            caps.AddAdditionalCapability("name", "Mi Perfil - Modificar contrasena");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Perfil)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), caps);

            LogIn(driver);

            setState("failed", "Error al acceder a --Mi Perfil--", driver);
            ClickButton("com.soriana.appsoriana:id/menuPerfilFragment", driver);

            setState("failed", "Error al acceder a --Mis datos--", driver);
            ClickButton("com.soriana.appsoriana:id/item_perfil", driver);

            ScrollDown(driver);

            setState("failed", "Campo --Contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editOldPass", "developmx12", driver);

            setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNewPass", "contraseñanueva123.", driver);

            setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editConfirmPass", "contraseñanueva123.", driver);

            setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            setState("failed", "Campo --Contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editOldPass", "contraseñanueva123.", driver);

            setState("failed", "Campo --Nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editNewPass", "developmx12", driver);

            setState("failed", "Campo --Confirmar nueva contrasena-- no encontrado", driver);
            InputText("com.soriana.appsoriana:id/editConfirmPass", "developmx12", driver);

            setState("failed", "Boton --Guardar informacion-- no encontrado (Probablemente por obstruccion del teclado)", driver);
            ClickButton("com.soriana.appsoriana:id/btnGuardarPass", driver);

            setState("passed", "Se cambiaron y verificaron los datos con exito", driver);

            driver.Quit();
        }
    }
}