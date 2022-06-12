using System;
using System.Collections.Generic;

namespace Practice.Models
{
    public partial class LogPass
    {
        public int UserId { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int IdWorker { get; set; }
        public int Admin { get; set; }

        public virtual Worker IdWorkerNavigation { get; set; } = null!;
    }
}
