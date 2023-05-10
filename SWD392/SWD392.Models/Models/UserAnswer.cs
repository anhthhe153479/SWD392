using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class UserAnswer
    {
        public int UserId { get; set; }
        public int AnswerId { get; set; }
        public int UserQuizId { get; set; }

        public virtual Answer Answer { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual UserQuiz UserQuiz { get; set; } = null!;
    }
}
