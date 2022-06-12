using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace praktika.Models
{
    public partial class Post
    {
        public Post()
        {
            Workers = new HashSet<Worker>();
        }

        [Required]
        [Display(Name = "ID должности")]
        public int IdPost { get; set; }

        [Required]
        [Display(Name = "Название должности")]
        public string Post1 { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
