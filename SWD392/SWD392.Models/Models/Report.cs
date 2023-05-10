using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Report
    {
        public int ReportId { get; set; }
        public int UserId { get; set; }
        public int CommentId { get; set; }
        public string? ReportContent { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
