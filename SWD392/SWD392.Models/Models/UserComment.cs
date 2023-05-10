using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class UserComment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public bool? IsLiked { get; set; }

        public virtual Comment Comment { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
