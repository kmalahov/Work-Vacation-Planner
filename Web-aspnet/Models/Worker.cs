using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Worker
    {
        public Worker()
        {
            ApplicationForVacations = new HashSet<ApplicationForVacation>();
            LogPasses = new HashSet<LogPass>();
            WorkersOnProjects = new HashSet<WorkersOnProject>();
        }

        public int IdWorker { get; set; }
        public string Surname { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Patronymic { get; set; }
        public string? ServiceNumber { get; set; }
        public int? Post { get; set; }
        public string? Email { get; set; }
        public int? Phone { get; set; }
        public DateTime DateHiring { get; set; }
        public int? Gender { get; set; }
        public int? Department { get; set; }

        public virtual Department? DepartmentNavigation { get; set; }
        public virtual Gender? GenderNavigation { get; set; }
        public virtual Post? PostNavigation { get; set; }
        public virtual ICollection<ApplicationForVacation> ApplicationForVacations { get; set; }
        public virtual ICollection<LogPass> LogPasses { get; set; }
        public virtual ICollection<WorkersOnProject> WorkersOnProjects { get; set; }
    }
}
