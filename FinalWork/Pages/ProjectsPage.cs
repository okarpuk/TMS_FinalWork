using OpenQA.Selenium;
using FinalWork.Core;
using FinalWork.Models;
using FinalWork.Tests.UI;
using FinalWork.Wrappers;

namespace FinalWork.Pages
{
    public class ProjectsPage : BasePage
    {
        private static string EndPoint = "admin/projects";

        private static readonly By CreateNewProjectButtonBy = By.CssSelector("button.ui.button");
        private static readonly By ProjectNameInputBy = By.XPath("//input[@placeholder='Project name']");
        private static readonly By ProjectNameIsRequiredMessageBy = By.ClassName("message-block");
        private static readonly By ProjectSummaryInputBy = By.TagName("textarea");
        private static readonly By ConfirmCreatedProjectButtonBy = By.XPath("//button[@class='ui button primary']");
        private static readonly By SelectFileButtonBy = By.CssSelector("button.ui.compact.fluid.button");
        private static readonly By UploadFileLinkBy = By.CssSelector("input[type=\"file\"]");
        private static readonly By DeleteProjectIconBy = By.CssSelector("[data-action=\"delete\"]");
        private static readonly By CheckboxToDeleteProjectBy = By.XPath("//label[@data-target='confirmationLabel']");
        private static readonly By ConfirmDeleteProjectButtonBy = By.CssSelector("button.ui.negative.button");
        private static readonly By ProjectDeletionProcessBy = By.XPath("//i[@class='fas fa-ban icon-deleted-entity']");
        private static readonly By TooltipOfDeletionBy = By.XPath("//div[@class='popup__tooltip__content']");
        private static readonly By ProjectNameInTableBy = By.XPath("//a[@data-action=\"edit\"]");
        private static readonly By ProjectSummaryInTableBy = By.XPath("//td[2]");
        private static readonly By ProjectLineBy = By.CssSelector("tr[data-id]");
        private static readonly By ProjectUploadedFileBy = By.XPath("//div/div/img");

        public ProjectsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
        {
            _logger.Info("Project page opened");

        }
        public ProjectsPage(IWebDriver driver) : base(driver, false)
        {
            _logger.Info("Project page opened");
        }

        public override bool IsPageOpened()
        {
            return WaitService.GetVisibleElement(CreateNewProjectButtonBy) != null;
        }

        public override void OpenPage()
        {
            Driver.Navigate().GoToUrl(BaseTest.BaseUrl + EndPoint);
        }

        public Button CreateProjectButton()
        {
            return new Button(Driver, CreateNewProjectButtonBy);
        }

        public Input NameInput()
        {
            return new Input(Driver, ProjectNameInputBy);
        }

        public Input SummaryInput()
        {
            return new Input(Driver, ProjectSummaryInputBy);
        }

        public Button ConfirmProjectButton()
        {
            return new Button(Driver, ConfirmCreatedProjectButtonBy);
        }

        public Button CheckboxToDelete()
        {
            return new Button(Driver, CheckboxToDeleteProjectBy);
        }

        public Button ConfirmDeleteButton()
        {
            return new Button(Driver, ConfirmDeleteProjectButtonBy);
        }

        public Button SelectFileButton()
        {
            return new Button(Driver, SelectFileButtonBy);
        }

        public void UploadFileButton(string file)
        {
            Driver.FindElement(UploadFileLinkBy).SendKeys(file);
        }

        public void DeletingProcessIcon()
        {
            Driver.FindElement(ProjectDeletionProcessBy);
        }

        public void DeletingProcessIconClick()
        {
            Driver.FindElement(ProjectDeletionProcessBy).Click();
        }

        public void CheckDeletingProcessIcon()
        {
            while (WaitService.GetVisibleElement(ProjectDeletionProcessBy) != null)
            {
                OpenPage();
                continue;
            }
        }

        public IList<IWebElement> AllProjectsList()
        {
            return Driver.FindElements(ProjectNameInTableBy);
        }

        public IList<IWebElement> AllSummaryList()
        {
            return Driver.FindElements(ProjectSummaryInTableBy);
        }

        public IList<IWebElement> AllDeleteProjectIconsList()
        {
            return Driver.FindElements(DeleteProjectIconBy);
        }

        public List<Project> GetAllProjectsList()
        {
            List<Project> projects = new List<Project>();

            OpenPage();

            var elements = Driver.FindElements(ProjectLineBy);

            for (int i = 0; i < elements.Count; i++)
            {
                var names = AllProjectsList();

                for (int j = i; j == i; j++)
                {
                    var summaries = AllSummaryList();

                    for (int k = i; k == i; k++)
                    {
                        projects.Add(new Project(names[j].Text, summaries[k].Text));
                    }
                }
            }
            return projects;
        }

        public void ClickDeleteProjectIcon(string name)
        {
            OpenPage();

            var elements = Driver.FindElements(ProjectLineBy);

            for (int i = 0; i < elements.Count; i++)
            {
                var delete = AllDeleteProjectIconsList();

                for (int j = i; j == i; j++)
                {
                    var names = AllProjectsList();

                    for (int k = i; k == i; k++)
                    {
                        if (names[k].Text == name)
                        {
                            delete[k].Click();
                            break;
                        }
                    }
                }
            }
        }

        public string TooltipTextCapture()
        {
            return Driver.FindElement(TooltipOfDeletionBy).Text;
        }

        public string SummaryInputDialog()
        {
            return Driver.FindElement(ProjectSummaryInputBy).GetAttribute("value");
        }

        public string GetSrcPath()
        {
            return Driver.FindElement(ProjectUploadedFileBy).GetAttribute("src");
        }

        public string RequiredNameMessageCapture()
        {
            return Driver.FindElement(ProjectNameIsRequiredMessageBy).Text;
        }

        public bool WaitCreateProjectDialogWindow()
        {
            return WaitService.GetVisibleElement(ProjectNameInputBy) != null;
        }

        public bool WaitUploadedFile()
        {
            return WaitService.GetVisibleElement(ProjectUploadedFileBy) != null;
        }

        public bool WaitNameRequiredMessage()
        {
            return WaitService.GetVisibleElement(ProjectNameIsRequiredMessageBy) != null;
        }

        public void CreateProject(Project project)
        {
            OpenPage();
            CreateProjectButton().Click();
            WaitCreateProjectDialogWindow();
            NameInput().SendKeys(project.Name);
            SummaryInput().SendKeys(project.Note);
            ConfirmProjectButton().Click();
        }

        public void DeleteProject(Project project)
        {
            OpenPage();
            CheckDeletingProcessIcon();
            ClickDeleteProjectIcon(project.Name);
            CheckboxToDelete().Click();
            ConfirmDeleteButton().Click();
        }

        public void UploadFile(string file)
        {
            OpenPage();
            CreateProjectButton().Click();
            WaitCreateProjectDialogWindow();
            SelectFileButton().Click();
            UploadFileButton(file);
            WaitUploadedFile();
        }
    }
}