using FinalWork.Pages;
using FinalWork.Utilites.Configuration;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace FinalWork.Tests.UI
{
    public class LoginTest : BaseTest
    {
        [Test(Description = "This test tries to login user with valid credentials via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("LoginWithValidCredentials")]
        [AllureIssue("TestmoIssue_5")]
        [AllureTms("TesmoTestCase_5")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void LoginWithValidCredentialsTest()
        {
            LoginPage.LoginAttempt(Configurator.Admin);
        }
    }
}