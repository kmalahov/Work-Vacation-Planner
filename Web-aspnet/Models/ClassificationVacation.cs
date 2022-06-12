using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class ClassificationVacation
    {
        public ClassificationVacation()
        {
            ApplicationForVacations = new HashSet<ApplicationForVacation>();
        }

        public int IdClassificationVacation { get; set; }
        public string CodeClassification { get; set; } = null!;
        public string NameClassification { get; set; } = null!;
        public int PeriodVacation { get; set; }
        public int UsageCount { get; set; }

        public virtual ICollection<ApplicationForVacation> ApplicationForVacations { get; set; }
    }
}
