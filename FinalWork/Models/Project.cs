using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWork.Models
{
    public class Project
    {
        public Project()
        {
        }

        public Project(string name, string summary)
        {
            Name = name;
            Summary = summary;
        }

        public string Name { get; set; }
        public string Summary { get; set; }
    }
}