using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class UserCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public bool IsStudied { get; set; }
        public int? CourseRating { get; set; }
        public string? CourseFeedback { get; set; }
        public float? Progress { get; set; }
        public DateTime? Paydate { get; set; }
        public bool? IsFavourite { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
