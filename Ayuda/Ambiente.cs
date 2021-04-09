using System;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium;

namespace UnitTestProject3
{
    public class Ambiente
    {

        List<Dispositivo> DispositivosAndroid = new List<Dispositivo>();
        public string ApkPre;
        public AppiumOptions caps;

        // ------------------------------------------------------------------ Metodos de ambiente ---------------------------------------------------------------------
        public Ambiente()
        {
            ApkPre = "SorianaApp";

            // Celulares
            //Android 11
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S20", "11.0"));
            DispositivosAndroid.Add(new Dispositivo("Google Pixel 5", "11.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S21", "11.0"));

            //Android 10
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Note 20", "10.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Tab S7", "10.0"));
            DispositivosAndroid.Add(new Dispositivo("OnePlus 8", "10.0"));

            //Android 9
            DispositivosAndroid.Add(new Dispositivo("Google Pixel 3a XL", "9.0"));
            DispositivosAndroid.Add(new Dispositivo("Xiaomi Redmi Note 8", "9.0"));
            DispositivosAndroid.Add(new Dispositivo("Motorola Moto G7 Play", "9.0"));

            //Android 8
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S9", "8.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Tab S4", "8.1"));
            DispositivosAndroid.Add(new Dispositivo("Google Pixel 2", "8.0"));

            //Android 7
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S8", "7.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Note 8", "7.1"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Tab S3", "7.0"));

            //Android 6
            DispositivosAndroid.Add(new Dispositivo("Motorola Moto X 2nd Gen", "6.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S7", "6.0"));
            DispositivosAndroid.Add(new Dispositivo("Google Nexus 6", "6.0"));

            //Androids Previos
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy S6", "5.0"));
            DispositivosAndroid.Add(new Dispositivo("Google Nexus 6", "5.0"));
            DispositivosAndroid.Add(new Dispositivo("Samsung Galaxy Tab 4", "4.4"));


        }

        public void CapsInit()
        {

            Dispositivo device = getDevice();

            string fecha = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();
            caps = new AppiumOptions();

            caps.AddAdditionalCapability("newCommandTimeout", 10);
            caps.AddAdditionalCapability("browserstack.user", "mauricioemmanuel1");
            caps.AddAdditionalCapability("browserstack.key", "XZYh6tFKBx8KBDyBzbAy");
            caps.AddAdditionalCapability("autoAcceptAlerts", true);
            caps.AddAdditionalCapability("autoGrantPermissions", true);
            caps.AddAdditionalCapability("app", ApkPre);
            caps.AddAdditionalCapability("device", device.nombre);
            caps.AddAdditionalCapability("os_version", device.versionOs);
            caps.PlatformName = "Android";
            caps.AddAdditionalCapability("project", "AppSoriana");
        }

        public Dispositivo getDevice()
        {
            DateTime dateValue = DateTime.Now;
            int dia = (int)dateValue.DayOfWeek;
            string hora = dateValue.Hour.ToString();

            //Hora + 3
            switch (dia)
            {
                case 1:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[0];
                        case "21":
                            return DispositivosAndroid[1];
                        case "1":
                            return DispositivosAndroid[2];
                        default:
                            return DispositivosAndroid[0];
                    }
                case 2:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[3];
                        case "21":
                            return DispositivosAndroid[4];
                        case "1":
                            return DispositivosAndroid[5];
                        default:
                            return DispositivosAndroid[3];
                    }
                case 3:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[6];
                        case "21":
                            return DispositivosAndroid[7];
                        case "1":
                            return DispositivosAndroid[8];
                        default:
                            return DispositivosAndroid[6];
                    }
                case 4:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[9];
                        case "21":
                            return DispositivosAndroid[10];
                        case "1":
                            return DispositivosAndroid[11];
                        default:
                            return DispositivosAndroid[9];
                    }
                case 5:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[12];
                        case "21":
                            return DispositivosAndroid[13];
                        case "1":
                            return DispositivosAndroid[14];
                        default:
                            return DispositivosAndroid[12];
                    }
                case 6:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[15];
                        case "21":
                            return DispositivosAndroid[16];
                        case "1":
                            return DispositivosAndroid[17];
                        default:
                            return DispositivosAndroid[15];
                    }
                case 0:
                    switch (hora)
                    {
                        case "18":
                            return DispositivosAndroid[18];
                        case "21":
                            return DispositivosAndroid[19];
                        case "1":
                            return DispositivosAndroid[20];
                        default:
                            return DispositivosAndroid[18];
                    }
            }

            return new Dispositivo("Google Pixel 3", "9.0");
        }

        // ------------------------------------------------------------------ Metodos de Ejecucion ---------------------------------------------------------------------

        public void ScrollDown(AndroidDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 1000)
            .Wait(500)
            .MoveTo(200, 200)
            .Release();

            touchAction.Perform();
        }

        public void ScrollUp(AndroidDriver<AndroidElement> driver)
        {
            ITouchAction touchAction = new TouchAction(driver)
            .Press(200, 200)
            .Wait(500)
            .MoveTo(200, 1000)
            .Release();

            touchAction.Perform();
        }

        public void ClickText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );



            searchElement.Click();
        }

        public void InputText(string id, string text, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
            searchElement.Clear();
            searchElement.SendKeys(text);
            driver.HideKeyboard();
        }

        public void ClickButton(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            searchElement.Click();
        }

        public void ClickClass(string clss, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.ClassName(clss))
            );

            searchElement.Click();
        }

        public bool CheckElement(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement == null)
            {
                Console.WriteLine("Salida inesperada");
                return false;
            }
            else
            {
                Console.WriteLine("Salida correcta");
                return true;
            }
        }

        public bool CheckText(string txt, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.AndroidUIAutomator("new UiSelector().textContains(\"" + txt + "\")"))
            );

            if (searchElement == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetElemenText(string id, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            return searchElement.GetAttribute("text");
        }

        public bool CheckElementText(string id, string text, AndroidDriver<AndroidElement> driver)
        {
            AndroidElement searchElement = (AndroidElement)new WebDriverWait(
                driver, TimeSpan.FromSeconds(7)).Until(
                SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(
                    MobileBy.Id(id))
            );

            if (searchElement.GetAttribute("text") != text)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void setState(string state, string arguments, AndroidDriver<AndroidElement> driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"" + state + "\", \"reason\": \" " + arguments + " \"}}");
        }

        public void LogIn(AndroidDriver<AndroidElement> driver)
        {
            ClickButton("com.soriana.appsoriana:id/imgArrow", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar el boton de inicio \"}}");
            ClickButton("com.soriana.appsoriana:id/btnIniciaSesion", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de email \"}}");
            InputText("com.soriana.appsoriana:id/editEmail", "pruebasdevelopayuda@yopmail.com", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo llenar el campo de contraseña \"}}");
            InputText("com.soriana.appsoriana:id/editPass", "developmx12", driver);
            ((IJavaScriptExecutor)driver).ExecuteScript("browserstack_executor: {\"action\": \"setSessionStatus\", \"arguments\": {\"status\":\"failed\", \"reason\": \" No se mostro o no se pudo presionar boton de LogIn \"}}");
            ClickButton("com.soriana.appsoriana:id/btn_login", driver);
        }
    }
}
