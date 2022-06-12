using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Vacation
    {
        public int IdVacation { get; set; }
        public int IdApplication { get; set; }
        public int IdWorker { get; set; }
        public DateTime DataVacationReal { get; set; }
        public int VacationCountReal { get; set; }
        public int IdClassificationVacation { get; set; }

        public virtual ApplicationForVacation IdApplicationNavigation { get; set; } = null!;
    }
}
