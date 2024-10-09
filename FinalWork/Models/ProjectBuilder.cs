namespace FinalWork.Models
{
    internal class ProjectBuilder
    {
        private Project project;
        public ProjectBuilder()
        {
            project = new Project();
        }

        public ProjectBuilder SetName(string name)
        {
            project.Name = name;
            return this;
        }

        public ProjectBuilder SetSummary(string summary)
        {
            project.Note = summary;
            return this;
        }

        public Project Build()
        {
            return project;
        }
    }
}
