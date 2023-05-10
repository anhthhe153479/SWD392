using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Notification
    {
        public int NoticeId { get; set; }
        public int UserId { get; set; }
        public string? NoticeContent { get; set; }
        public DateTime? NoticeDate { get; set; }
        public bool IsSeen { get; set; }
        public string? Action { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
