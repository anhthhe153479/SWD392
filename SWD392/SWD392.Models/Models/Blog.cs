using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Blog
    {
        public Blog()
        {
            CommentBlogs = new HashSet<CommentBlog>();
        }

        public int BlogId { get; set; }
        public int UserId { get; set; }
        public DateTime? BlogDate { get; set; }
        public string? BlogContent { get; set; }
        public string? BlogTitle { get; set; }
        public string? BlogDescription { get; set; }
        public string? BlogImage { get; set; }
        public string? Category { get; set; }
        public string? Status { get; set; }
        public bool? IsReported { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<CommentBlog> CommentBlogs { get; set; }
    }
}
