using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        [Required]
        [Display(Name = "ID отдела")]
        public int IdDepartment { get; set; }

        [Required]
        [Display(Name = "название отдела")]
        public string Department1 { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
