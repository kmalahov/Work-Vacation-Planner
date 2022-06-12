using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class ApplicationForVacation
    {
        public ApplicationForVacation()
        {
            Vacations = new HashSet<Vacation>();
        }

        public int IdApplication { get; set; }
        public DateTime DateBeginVacation { get; set; }
        public int VacationCount { get; set; }
        public int IdWorker { get; set; }
        public int StatusApplication { get; set; }
        public int IdClassificationVacation { get; set; }

        public virtual ClassificationVacation IdClassificationVacationNavigation { get; set; } = null!;
        public virtual Worker IdWorkerNavigation { get; set; } = null!;
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
