using System;
using System.Collections.Generic;

#nullable disable

namespace praktika.Models
{
    public partial class WorkersOnProject
    {
        public int IdWorkerOnProject { get; set; }
        public int IdProject { get; set; }
        public int IdWorker { get; set; }
        public string ProjectRole { get; set; }
        public DateTime DateStartParticipate { get; set; }
        public DateTime DateEndParticipate { get; set; }

        public virtual Project IdProjectNavigation { get; set; }
        public virtual Worker IdWorkerNavigation { get; set; }
    }
}
