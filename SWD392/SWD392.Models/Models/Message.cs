using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Message
    {
        public int From { get; set; }
        public int To { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? Content { get; set; }

        public virtual User FromNavigation { get; set; } = null!;
        public virtual User ToNavigation { get; set; } = null!;
    }
}
