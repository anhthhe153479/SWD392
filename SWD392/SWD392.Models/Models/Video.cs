using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Video
    {
        public Video()
        {
            Comments = new HashSet<Comment>();
        }

        public int VideoId { get; set; }
        public int LessonId { get; set; }
        public string? VideoName { get; set; }
        public string? VideoLink { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
