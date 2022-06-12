using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class Post
    {
        public Post()
        {
            Workers = new HashSet<Worker>();
        }

        public int IdPost { get; set; }
        public string Post1 { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }
    }
}
