using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Threading;
using UnitTestProject3;
namespace Folletos
{
    [TestClass]
    public class Folletos
    {
        Ambiente amb = new Ambiente();

        // 89
        [TestMethod]
        public void VerificarFolletos()
        {
            amb.CapsInit();
            amb.caps.AddAdditionalCapability("name", "Folletos - Verificar folletos disponibles y acceder");

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            amb.caps.AddAdditionalCapability("build", "Android (Extras)" + fecha + " - " + DateTime.Now.Hour.ToString() + ":00");

            AndroidDriver<AndroidElement> driver = new AndroidDriver<AndroidElement>(
                    new Uri("http://hub-cloud.browserstack.com/wd/hub"), amb.caps);

            amb.LogIn(driver);

            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("failed", "Seccion --Folletos-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/item_folletos", driver);

            amb.setState("failed", "Seccion --Soriana Super-- no encontrada", driver);
            amb.ClickText("Soriana Súper", driver);

            amb.ScrollDown(driver);
            Thread.Sleep(1000);
            amb.ScrollUp(driver);

            amb.setState("failed", "Folleto no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgFolleto", driver);

            amb.setState("failed", "Error al cambiar de pagina", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);


            amb.setState("failed", "Seccion --Soriana Hiper-- no encontrada", driver);
            amb.ClickText("Soriana Híper", driver);

            amb.ScrollDown(driver);
            Thread.Sleep(1000);
            amb.ScrollUp(driver);

            amb.setState("failed", "Folleto no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/imgFolleto", driver);

            amb.setState("failed", "Error al cambiar de pagina", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);
            amb.ClickButton("com.soriana.appsoriana:id/right", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Boton --Regresar-- no encontrado", driver);
            amb.ClickButton("com.soriana.appsoriana:id/activity_main_content_button_back", driver);

            amb.setState("failed", "Seccion --Menu-- no encontrada", driver);
            amb.ClickButton("com.soriana.appsoriana:id/menuFragment", driver);

            amb.setState("passed", "Se verificaron los folletos correctamente", driver);

            driver.Quit();
        }
    }
}
