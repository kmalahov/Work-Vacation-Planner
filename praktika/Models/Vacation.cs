using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class Vacation
    {

        [Required]
        [Display(Name = "ID отпуска")]
        public int IdVacation { get; set; }


        [Required]
        [Display(Name = "ID заявки")]
        public int IdApplication { get; set; }


        [Required]
        [Display(Name = "ID сотрудника")]
        public int IdWorker { get; set; }


        [Required]
        [Display(Name = "Дата начала отпуска")]
        public DateTime DataVacationReal { get; set; }


        [Required]
        [Display(Name = "Количество дней")]
        public int VacationCountReal { get; set; }


        [Required]
        [Display(Name = "Вид отпуска")]
        public int IdClassificationVacation { get; set; }

        public virtual ApplicationForVacation IdApplicationNavigation { get; set; }
    }
}
