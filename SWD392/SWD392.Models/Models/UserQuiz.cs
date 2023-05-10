using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class UserQuiz
    {
        public UserQuiz()
        {
            UserAnswers = new HashSet<UserAnswer>();
        }

        public int UserQuizId { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public double? Mark { get; set; }
        public int? NumberOfRightQuestion { get; set; }
        public DateTime? Date { get; set; }

        public virtual Quiz Quiz { get; set; } = null!;
        public virtual User UserQuizNavigation { get; set; } = null!;
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
    }
}
