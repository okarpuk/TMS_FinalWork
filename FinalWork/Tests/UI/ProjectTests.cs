using OpenQA.Selenium;
using FinalWork.Models;
using FinalWork.Pages;
using FinalWork.Utilites.Configuration;

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

        [Test]
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

        [Test]
        public void POSITIVE_2_CreateNewProjectDialog()
        {
            var page = new ProjectsPage(Driver);
            page.OpenPage();
            page.CreateProjectButton().Click();

            Assert.That(page.WaitCreateProjectDialogWindow(), Is.EqualTo(true));
        }

        [Test]
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

        [Test]
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

        [Test]
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

        [Test]
        public void POSITIVE_6_FileUploading()
        {
            var startsUrl = "https://aleh.testmo.net/attachments/view/";
            var page = new ProjectsPage(Driver);

            string file = "D:/111aaa.jpg";
            page.UploadFile(file);
            page.GetSrcPath();
            Thread.Sleep(1000);

            var fileUrl = page.GetSrcPath().StartsWith(startsUrl);

            Assert.That(fileUrl, Is.EqualTo(true));
        }

        //NEGATIVE TESTS

        [Test]
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

        [Test]
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

        [Test]
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