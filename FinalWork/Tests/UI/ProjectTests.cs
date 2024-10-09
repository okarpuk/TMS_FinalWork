using OpenQA.Selenium;
using FinalWork.Models;
using FinalWork.Pages;
using FinalWork.Utilites.Configuration;
using Allure.Commons;
using NUnit.Allure.Attributes;

namespace FinalWork.Tests.UI
{
    public class ProjectTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            LoginPage.LoginAttempt(Configurator.Admin);
        }

        //POSITIVE TESTS

        [Test(Description = "This test creates new valid project via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("CreateValidProject")]
        [AllureIssue("TestmoIssueUI_1")]
        [AllureTms("TesmoTestCaseUI_1")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void POSITIVE_1_CreateNewProject()
        {
            Project project = new ProjectBuilder()
                .SetName("Name for Create Project Test")
                .SetSummary("Summary for Create Project Test")
                .Build();

            var page = new ProjectsPage(Driver);
            page.CreateProject(project);
            Thread.Sleep(1000);
            var createdProject = Driver.FindElement(By.XPath($"//tr[@data-name='{project.Name}']"));

            Assert.IsTrue(createdProject != null);
        }

        [Test(Description = "This test checks new project dialog window via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("CheckNewProjectDialogWindow")]
        [AllureIssue("TestmoIssueUI_2")]
        [AllureTms("TesmoTestCaseUI_2")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void POSITIVE_2_CreateNewProjectDialog()
        {
            var page = new ProjectsPage(Driver);
            page.OpenPage();
            page.CreateProjectButton().Click();

            Assert.That(page.WaitCreateProjectDialogWindow(), Is.EqualTo(true));
        }

        [Test(Description = "This test checks boundary values in Summary field via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("CheckSummaryFieldBoundaryValues")]
        [AllureIssue("TestmoIssueUI_3")]
        [AllureTms("TesmoTestCaseUI_3")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        [TestCase("")]
        [TestCase("1")]
        [TestCase("67-M%+@tH!MueoBtc8Hr1ofcy&@h#xSVnlC3@_GgIgU2&tKCdFvD5qFS&7A$lwiilii")]
        [TestCase("80-j924XqdX3j+#hxNkwNvhMiE5QJ5n6J+0V&6UT_9m!lINKbNwBrAe*H_^=93G*9U$Ub17VaNbjRK3i")]
        public void POSITIVE_3_SummaryFieldBoundaryValues(string summary)
        {
            var page = new ProjectsPage(Driver);
            page.OpenPage();
            page.CreateProjectButton().Click();
            page.WaitCreateProjectDialogWindow();
            page.SummaryInput().SendKeys(summary);

            Assert.That(page.SummaryInputDialog(), Is.EqualTo(summary));
        }

        [Test(Description = "This test deletes valid project via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("DeleteValidProject")]
        [AllureIssue("TestmoIssueUI_4")]
        [AllureTms("TesmoTestCaseUI_4")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void POSITIVE_4_DeleteProject()
        {
            Project project = new ProjectBuilder()
                .SetName("Name for Delete Project Test")
                .SetSummary("Summary for Delete Project Test")
                .Build();

            var page = new ProjectsPage(Driver);
            page.CreateProject(project);
            Thread.Sleep(1000);
            page.DeleteProject(project);
            Thread.Sleep(15000);

            Assert.IsTrue(page.DeletingProcessIcon != null);
        }

        [Test(Description = "This test checks tooltip notification whew project deleting via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("CheckToolTipNotification")]
        [AllureIssue("TestmoIssueUI_5")]
        [AllureTms("TesmoTestCaseUI_5")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void POSITIVE_5_ToolTipNotification()
        {
            string expectedNotificationText = "The project has been marked for deletion and will be removed shortly.";

            Project project = new ProjectBuilder()
                .SetName("Name for ToolTip Test")
                .SetSummary("Summary for ToolTip Test")
                .Build();

            var page = new ProjectsPage(Driver);
            page.CreateProject(project);
            page.DeleteProject(project);
            Thread.Sleep(1000);
            page.DeletingProcessIconClick();
            string actualNotificationText = page.TooltipTextCapture();

            Assert.That(actualNotificationText, Is.EqualTo(expectedNotificationText));
        }

        [Test(Description = "This test uploads file into project via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("PositiveTestsSuite")]
        [AllureSubSuite("UploadFileInToProject")]
        [AllureIssue("TestmoIssueUI_6")]
        [AllureTms("TesmoTestCaseUI_6")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void POSITIVE_6_FileUploading()
        {
            var startsUrl = "https://aleh.testmo.net/attachments/view/";
            var page = new ProjectsPage(Driver);

            string file = "D:/TestFile/111aaa.jpg";
            page.UploadFile(file);
            page.GetSrcPath();
            Thread.Sleep(1000);

            var fileUrl = page.GetSrcPath().StartsWith(startsUrl);

            Assert.That(fileUrl, Is.EqualTo(true));
        }

        //NEGATIVE TESTS

        [Test(Description = "This test trying to create new project without Name via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("NegativeTestsSuite")]
        [AllureSubSuite("CreateValidProject")]
        [AllureIssue("TestmoIssueUI_7")]
        [AllureTms("TesmoTestCaseUI_7")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void NEGATIVE_1_EmptyNameField()
        {
            string expectWarning = "The name field is required.";
            Project project = new ProjectBuilder()
                .SetName("")
                .SetSummary("Empty Name field test")
                .Build();

            var page = new ProjectsPage(Driver);

            page.CreateProject(project);
            page.WaitNameRequiredMessage();
            string actualWarning = page.RequiredNameMessageCapture();

            Assert.That(actualWarning, Is.EqualTo(expectWarning));
        }

        [Test(Description = "This test checks boundary values in Summary field via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("NegativeTestsSuite")]
        [AllureSubSuite("CheckSummaryFieldBoundaryValues")]
        [AllureIssue("TestmoIssueUI_8")]
        [AllureTms("TesmoTestCaseUI_8")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void NEGATIVE_2_SummaryFieldBoundaryValues()
        {
            var expectText = "81-j924XqdX3j+#hxNkwNvhMiE5QJ5n6J+0V&6UT_9m!lINKbNwBrAe*H_^=93G*9U$Ub17VaNbjRK3i";
            var actualText = "81-j924XqdX3j+#hxNkwNvhMiE5QJ5n6J+0V&6UT_9m!lINKbNwBrAe*H_^=93G*9U$Ub17VaNbjRK3i1";

            var page = new ProjectsPage(Driver);

            page.OpenPage();
            page.CreateProjectButton().Click();
            page.WaitCreateProjectDialogWindow();
            page.SummaryInput().SendKeys(actualText);

            Assert.Multiple(() =>
            {
                Assert.That(page.SummaryInputDialog().Length, Is.EqualTo(80));
                Assert.That(page.SummaryInputDialog(), Is.EqualTo(expectText));
            });
        }

        [Test(Description = "This test imitates bug with boundary values in Summary field via UI")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureOwner("Aleh Karpuk")]
        [AllureSuite("NegativeTestsSuite")]
        [AllureSubSuite("CheckSummaryFieldBoundaryValues")]
        [AllureIssue("TestmoIssueUI_9")]
        [AllureTms("TesmoTestCaseUI_9")]
        [AllureTag("Smoke")]
        [AllureLink("https://aleh.testmo.net/")]
        public void NEGATIVE_3_Bug_imitation()
        {
            var expectText = "81-j924XqdX3j+#hxNkwNvhMiE5QJ5n6J+0V&6UT_9m!lINKbNwBrAe*H_^=93G*9U$Ub17VaNbjRK3i";
            var actualText = "81-j924XqdX3j+#hxNkwNvhMiE5QJ5n6J+0V&6UT_9m!lINKbNwBrAe*H_^=93G*9U$Ub17VaNbjRK3i1";

            var page = new ProjectsPage(Driver);
            page.OpenPage();
            page.CreateProjectButton().Click();
            page.WaitCreateProjectDialogWindow();
            page.SummaryInput().SendKeys(actualText);

            Assert.Multiple(() =>
            {
                Assert.That(page.SummaryInputDialog().Length, Is.EqualTo(81));
                Assert.That(page.SummaryInputDialog(), Is.EqualTo(actualText));
            });
        }
    }
}