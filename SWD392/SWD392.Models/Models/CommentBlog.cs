using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class CommentBlog
    {
        public int CommentId { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CommentDate { get; set; }
        public int? Likes { get; set; }
        public int BlogId { get; set; }
        public bool IsReported { get; set; }

        public virtual Blog Blog { get; set; } = null!;
    }
}
