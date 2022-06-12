using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class LogPass
    {

        [Required]
        [Display(Name = "ID сотрудника")]
        public int UserId { get; set; }


        [Display(Name = "Логин сотрудника")]
        [Required(ErrorMessage = "Не указан логин")]
        public string Login { get; set; }

        [Display(Name = "Пароль сотрудника")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string Password { get; set; }


        [Required]
        [Display(Name = "ID сотрудника")]
        public int IdWorker { get; set; }

        [Required]
        [Display(Name = "Роль сотрудника")]
        public int Admin { get; set; }
        public virtual Worker IdWorkerNavigation { get; set; }
    }
}
