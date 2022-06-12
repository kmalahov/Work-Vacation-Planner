using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Workers = new HashSet<Worker>();
        }

        [Required]
        [Display(Name = "ID гендера")]
        public int IdGender { get; set; }

        [Required]
        [Display(Name = "Название гендера")]
        public string GenderName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
