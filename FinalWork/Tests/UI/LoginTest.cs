using FinalWork.Pages;
using FinalWork.Utilites.Configuration;

namespace FinalWork.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test]
        public void LoginWithValidCredentialsTest()
        {
            LoginPage.LoginAttempt(Configurator.Admin);
        }
    }
}