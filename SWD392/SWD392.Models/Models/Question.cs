using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Question
    {
        public Question()
        {
            Answers = new HashSet<Answer>();
        }

        public int QuestionId { get; set; }
        public string QuestionContent { get; set; } = null!;
        public int QuizId { get; set; }

        public virtual Quiz Quiz { get; set; } = null!;
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
