using OpenQA.Selenium;
using FinalWork.Utilites.Configuration;

namespace FinalWork.Core
{
    public class Browser
    {
        public Browser()
        {
            Driver = Configurator.BrowserType?.ToLower() switch
            {
                "chrome" => new DriverFactory().GetChromeDriver(),
                "firefox" => new DriverFactory().GetFirefoxDriver(),
                _ => Driver
            };

            Driver.Manage().Window.Maximize();
            Driver.Manage().Cookies.DeleteAllCookies();
            if (Driver != null) Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(0);
        }

        public IWebDriver Driver { get; set; }
    }
}