using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using FinalWork.Core;
using FinalWork.Pages;
using FinalWork.Utilites.Configuration;

namespace FinalWork.Tests.UI
{
    public class BaseTest
    {
        public static readonly string? BaseUrl = Configurator.AppSettings.URL;

        protected IWebDriver Driver;
        protected WaitService WaitService;
        public LoginPage LoginPage { get; set; }

        [SetUp]
        public void Setup()
        {
            Driver = new Browser().Driver;
            WaitService = new WaitService(Driver);
            LoginPage = new LoginPage(Driver);
            LoginPage.OpenPage();
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
            Driver.Dispose();
        }
    }
}