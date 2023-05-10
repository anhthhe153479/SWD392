using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Quiz
    {
        public Quiz()
        {
            Questions = new HashSet<Question>();
            UserQuizzes = new HashSet<UserQuiz>();
        }

        public int QuizId { get; set; }
        public float? Mark { get; set; }
        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<UserQuiz> UserQuizzes { get; set; }
    }
}
