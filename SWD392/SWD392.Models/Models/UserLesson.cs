using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class UserLesson
    {
        public int UserId { get; set; }
        public int LessonId { get; set; }
        public string? Status { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
