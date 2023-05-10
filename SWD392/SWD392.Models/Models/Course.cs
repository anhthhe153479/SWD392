using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Course
    {
        public Course()
        {
            Sections = new HashSet<Section>();
            UserCourses = new HashSet<UserCourse>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; } = null!;
        public DateTime? DateCreate { get; set; }
        public int AuthorId { get; set; }
        public string? Category { get; set; }
        public int NumberEnrolled { get; set; }
        public float? CoursePrice { get; set; }
        public string? CourseImage { get; set; }
        public string Status { get; set; } = null!;
        public string? Description { get; set; }
        public string? Objectives { get; set; }
        public string? Difficulty { get; set; }

        public virtual User Author { get; set; } = null!;
        public virtual ICollection<Section> Sections { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}
