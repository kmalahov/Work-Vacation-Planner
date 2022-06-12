using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class ClassificationVacation
    {
        public ClassificationVacation()
        {
            ApplicationForVacations = new HashSet<ApplicationForVacation>();
        }

        [Required]
        [Display(Name = "ID классивификации")]
        public int IdClassificationVacation { get; set; }

        [Required]
        [Display(Name = "Код классификации")]
        public string CodeClassification { get; set; }

        [Required]
        [Display(Name = "вид отпуска")]
        public string NameClassification { get; set; }

        [Required]
        [Display(Name = "Период отпуска")]
        public int PeriodVacation { get; set; }

        [Required]
        [Display(Name = "Количество использований в год")]
        public int UsageCount { get; set; }

        public virtual ICollection<ApplicationForVacation> ApplicationForVacations { get; set; }
    }
}
