using System;
using System.Collections.Generic;

#nullable disable

namespace praktika.Models
{
    public partial class StatusApplication
    {
        public int IdStatusApplication { get; set; }
        public string NameStatusClassification { get; set; }

        
        public virtual ICollection<ApplicationForVacation> ApplicationForVacations { get; set; }
    }
}
