using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class ApplicationForVacation
    {
        public ApplicationForVacation()
        {
            Vacations = new HashSet<Vacation>();
        }

        [Required]
        [Display(Name = "ID заявки")]
        public int IdApplication { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата начала отпуска")]
        public DateTime DateBeginVacation { get; set; }

        [Required]
        [Display(Name = "Количество дней отпуска")]
        public int VacationCount { get; set; }

        [Required]
        [Display(Name = "Работник")]
        public int IdWorker { get; set; }

        [Required]
        [Display(Name = "Статус заявки")]
        public int StatusApplication { get; set; }

        [Required]
        [Display(Name = "Вид отпуска")]
        public int IdClassificationVacation { get; set; }

        public virtual ClassificationVacation IdClassificationVacationNavigation { get; set; }
        public virtual Worker IdWorkerNavigation { get; set; }
        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
