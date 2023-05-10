using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class User
    {
        public User()
        {
            Blogs = new HashSet<Blog>();
            Comments = new HashSet<Comment>();
            Courses = new HashSet<Course>();
            Notifications = new HashSet<Notification>();
            Recharges = new HashSet<Recharge>();
            Reports = new HashSet<Report>();
            UserAnswers = new HashSet<UserAnswer>();
            UserComments = new HashSet<UserComment>();
            UserCourses = new HashSet<UserCourse>();
            UserLessons = new HashSet<UserLesson>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public DateTime? DoB { get; set; }
        public string? PostCode { get; set; }
        public int? Balance { get; set; }
        public string? Avatar { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public string? BankNumber { get; set; }
        public string? BankName { get; set; }
        public bool IsDisable { get; set; }

        public virtual UserQuiz? UserQuiz { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Recharge> Recharges { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<UserAnswer> UserAnswers { get; set; }
        public virtual ICollection<UserComment> UserComments { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
        public virtual ICollection<UserLesson> UserLessons { get; set; }
    }
}
