using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Project
    {
        public Project()
        {
            WorkersOnProjects = new HashSet<WorkersOnProject>();
        }

        public int IdProject { get; set; }
        public string ProjectName { get; set; } = null!;
        public DateTime DateProjectBegin { get; set; }
        public DateTime DateProjectEnd { get; set; }
        public int LaborCount { get; set; }
        public DateTime DateProjectStatus { get; set; }
        public int ProjectManager { get; set; }

        public virtual ICollection<WorkersOnProject> WorkersOnProjects { get; set; }
    }
}
