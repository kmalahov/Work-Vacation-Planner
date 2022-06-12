using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class Worker
    {
        public Worker()
        {
            ApplicationForVacations = new HashSet<ApplicationForVacation>();
            LogPasses = new HashSet<LogPass>();
            WorkersOnProjects = new HashSet<WorkersOnProject>();
        }

        //[Required]
        [Display(Name = "ID Сотрудника")]
        public int IdWorker { get; set; }

        //[Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        //[Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        //[Required]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }

        //[Required]
        [Display(Name = "Табельный номер")]
        public string ServiceNumber { get; set; }

        //[Required]
        [Display(Name = "Должность")]
        public int? Post { get; set; }

        //[Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        //[Required]
        [Display(Name = "Номер телефона")]
        public int? Phone { get; set; }

        //[Required]
        [DataType(DataType.Date)]
        [Display(Name = "Дата трудоустройства")]
        public DateTime DateHiring { get; set; }

        //[Required]
        [Display(Name = "Пол")]
        public int? Gender { get; set; }

        //[Required]
        [Display(Name = "Отдел")]
        public int? Department { get; set; }

        public virtual Department DepartmentNavigation { get; set; }
        public virtual Gender GenderNavigation { get; set; }
        public virtual Post PostNavigation { get; set; }
        public virtual ICollection<ApplicationForVacation> ApplicationForVacations { get; set; }
        public virtual ICollection<LogPass> LogPasses { get; set; }
        public virtual ICollection<WorkersOnProject> WorkersOnProjects { get; set; }
    }
}
