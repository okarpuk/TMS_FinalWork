using OpenQA.Selenium;
using FinalWork.Core;
using NLog;

namespace FinalWork.Pages
{
    public abstract class BasePage
    {
        protected static readonly Logger _logger = LogManager.GetCurrentClassLogger();
        protected IWebDriver Driver;
        protected WaitService WaitService;

        public BasePage(IWebDriver driver, bool openPageByUrl)
        {
            Driver = driver;
            WaitService = new WaitService(Driver);

            if (openPageByUrl)
            {
                OpenPage();
            }
        }

        public abstract void OpenPage();
        public abstract bool IsPageOpened();
    }
}