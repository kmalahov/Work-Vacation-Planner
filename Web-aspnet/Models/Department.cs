using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Department
    {
        public Department()
        {
            Workers = new HashSet<Worker>();
        }

        public int IdDepartment { get; set; }
        public string? Department1 { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
