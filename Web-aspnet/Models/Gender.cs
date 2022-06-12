using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Workers = new HashSet<Worker>();
        }

        public int IdGender { get; set; }
        public string GenderName { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
