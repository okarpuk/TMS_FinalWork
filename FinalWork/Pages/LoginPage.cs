using OpenQA.Selenium;
using FinalWork.Models;
using FinalWork.Tests.UI;
using FinalWork.Wrappers;

namespace FinalWork.Pages
{
    public class LoginPage : BasePage
    {
        private static string EndPoint = "auth/login";

        private static readonly By EmailInputBy = By.Name("email");
        private static readonly By PasswordInputBy = By.Name("password");
        private static readonly By LoginButtonBy = By.XPath("//button[text()='Log in']");

        public LoginPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("Login page opened");
        }

        public LoginPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("Login page opened");

        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(LoginButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoint);
        }

        public Input EmailInput()
        {
            return new Input(Driver, EmailInputBy);
        }

        public Input PasswordInput()
        {
            return new Input(Driver, PasswordInputBy);
        }

        public Button LoginButton()
        {
            return new Button(Driver, LoginButtonBy);
        }

        public void LoginAttempt(User user)
        {
            EmailInput().SendKeys(user.Username);
            PasswordInput().SendKeys(user.Password);
            LoginButton().Click();
        }
    }
}