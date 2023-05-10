using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Reports = new HashSet<Report>();
            UserComments = new HashSet<UserComment>();
        }

        public int CommentId { get; set; }
        public int VideoId { get; set; }
        public int UserId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? Likes { get; set; }
        public bool IsReported { get; set; }
        public int? ParentId { get; set; }
        public bool? IsDisable { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Video Video { get; set; } = null!;
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
    }
}
