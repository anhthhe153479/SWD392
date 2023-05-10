using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Lesson
    {
        public Lesson()
        {
            Docs = new HashSet<Doc>();
            Quizzes = new HashSet<Quiz>();
            UserLessons = new HashSet<UserLesson>();
            Videos = new HashSet<Video>();
        }

        public int LessonId { get; set; }
        public int SectionId { get; set; }
        public string? LessonName { get; set; }
        public bool IsDisable { get; set; }
        public string? Types { get; set; }
        public int? Time { get; set; }

        public virtual Section Section { get; set; } = null!;
        public virtual ICollection<Doc> Docs { get; set; }
        public virtual ICollection<Quiz> Quizzes { get; set; }
        public virtual ICollection<UserLesson> UserLessons { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}
