using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace SWD392.Models.Models
{
    public partial class SWD_Summer2023Context : DbContext
    {
        public SWD_Summer2023Context()
        {
        }

        public SWD_Summer2023Context(DbContextOptions<SWD_Summer2023Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<CommentBlog> CommentBlogs { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Doc> Docs { get; set; } = null!;
        public virtual DbSet<Lesson> Lessons { get; set; } = null!;
        public virtual DbSet<Message> Messages { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Recharge> Recharges { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAnswer> UserAnswers { get; set; } = null!;
        public virtual DbSet<UserComment> UserComments { get; set; } = null!;
        public virtual DbSet<UserCourse> UserCourses { get; set; } = null!;
        public virtual DbSet<UserLesson> UserLessons { get; set; } = null!;
        public virtual DbSet<UserQuiz> UserQuizzes { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                                          .SetBasePath(Directory.GetCurrentDirectory())
                                          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SWD_Summer2023"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.AnswerContent).HasColumnType("ntext");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKAnswer353317");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.BlogContent).HasColumnType("ntext");

                entity.Property(e => e.BlogDate).HasColumnType("datetime");

                entity.Property(e => e.BlogDescription).HasMaxLength(255);

                entity.Property(e => e.BlogImage).HasColumnType("text");

                entity.Property(e => e.BlogTitle).HasMaxLength(200);

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.IsReported).HasColumnName("isReported");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKBlog360084");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.CommentContent).HasColumnType("ntext");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.IsDisable).HasColumnName("isDisable");

                entity.Property(e => e.IsReported).HasColumnName("isReported");

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment630592");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.VideoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKComment362035");
            });

            modelBuilder.Entity<CommentBlog>(entity =>
            {
                entity.HasKey(e => e.CommentId)
                    .HasName("PK__CommentB__C3B4DFAA9B972B10");

                entity.ToTable("CommentBlog");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.BlogId).HasColumnName("BlogID");

                entity.Property(e => e.CommentContent).HasColumnType("ntext");

                entity.Property(e => e.CommentDate).HasColumnType("datetime");

                entity.Property(e => e.IsReported).HasColumnName("isReported");

                entity.HasOne(d => d.Blog)
                    .WithMany(p => p.CommentBlogs)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCommentBlo644738");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Category).HasMaxLength(200);

                entity.Property(e => e.CourseImage).HasColumnType("text");

                entity.Property(e => e.CourseName).HasMaxLength(200);

                entity.Property(e => e.DateCreate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("ntext");

                entity.Property(e => e.Difficulty)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Objectives).HasColumnType("ntext");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_User");
            });

            modelBuilder.Entity<Doc>(entity =>
            {
                entity.HasKey(e => e.DocsId)
                    .HasName("PK__Docs__9A47E65CB2AE7B6A");

                entity.Property(e => e.DocsId).HasColumnName("DocsID");

                entity.Property(e => e.Content).HasColumnType("ntext");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Docs)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDocs909883");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.ToTable("Lesson");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.IsDisable).HasColumnName("isDisable");

                entity.Property(e => e.LessonName).HasMaxLength(200);

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.Types)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("types");

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKLesson935170");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Message");

                entity.Property(e => e.Content)
                    .HasColumnType("ntext")
                    .HasColumnName("content");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.From).HasColumnName("from");

                entity.Property(e => e.To).HasColumnName("to");

                entity.HasOne(d => d.FromNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.From)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMessage213227");

                entity.HasOne(d => d.ToNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.To)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKMessage65145");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => new { e.NoticeId, e.UserId })
                    .HasName("PK__Notifica__CE83CB8594AD468F");

                entity.ToTable("Notification");

                entity.Property(e => e.NoticeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NoticeID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.IsSeen).HasColumnName("isSeen");

                entity.Property(e => e.NoticeContent).HasColumnType("ntext");

                entity.Property(e => e.NoticeDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Notification_User");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.QuestionContent).HasColumnType("ntext");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestion143290");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuiz516641");
            });

            modelBuilder.Entity<Recharge>(entity =>
            {
                entity.ToTable("Recharge");

                entity.Property(e => e.RechargeId).HasColumnName("RechargeID");

                entity.Property(e => e.Content).HasMaxLength(50);

                entity.Property(e => e.Method).HasMaxLength(50);

                entity.Property(e => e.RechargeDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Recharges)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKRecharge738481");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.HasKey(e => new { e.ReportId, e.UserId, e.CommentId });

                entity.ToTable("Report");

                entity.Property(e => e.ReportId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ReportID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.ReportContent).HasMaxLength(50);

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_Comment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Report_User");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.ToTable("Section");

                entity.Property(e => e.SectionId).HasColumnName("SectionID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.IsDisable).HasColumnName("isDisable");

                entity.Property(e => e.SectionName).HasMaxLength(200);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_Course");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address).HasMaxLength(200);

                entity.Property(e => e.Avatar).HasColumnType("text");

                entity.Property(e => e.BankName).HasMaxLength(50);

                entity.Property(e => e.BankNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.IsDisable).HasColumnName("isDisable");

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserAnswer>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AnswerId })
                    .HasName("PK_User_Answer_1");

                entity.ToTable("User_Answer");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.AnswerId).HasColumnName("AnswerID");

                entity.Property(e => e.UserQuizId).HasColumnName("UserQuizID");

                entity.HasOne(d => d.Answer)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.AnswerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Answer_Answer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Answer_User");

                entity.HasOne(d => d.UserQuiz)
                    .WithMany(p => p.UserAnswers)
                    .HasForeignKey(d => d.UserQuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Answer_User_Quiz");
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.HasKey(e => new { e.CommentId, e.UserId });

                entity.ToTable("User_Comment");

                entity.Property(e => e.CommentId).HasColumnName("CommentID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.IsLiked).HasColumnName("isLiked");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.UserComments)
                    .HasForeignKey(d => d.CommentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Comment_Comment");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserComments)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Comment_User");
            });

            modelBuilder.Entity<UserCourse>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.CourseId })
                    .HasName("PK__User_Cou__7B1A1BB4D6DDFF75");

                entity.ToTable("User_Course");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseFeedback).HasColumnType("ntext");

                entity.Property(e => e.IsFavourite).HasColumnName("isFavourite");

                entity.Property(e => e.IsStudied).HasColumnName("isStudied");

                entity.Property(e => e.Paydate).HasColumnType("datetime");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Course_Course");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCourses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKUser_Cours401962");
            });

            modelBuilder.Entity<UserLesson>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LessonId });

                entity.ToTable("User_Lesson");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.UserLessons)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Lesson_Lesson");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLessons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Lesson_User");
            });

            modelBuilder.Entity<UserQuiz>(entity =>
            {
                entity.ToTable("User_Quiz");

                entity.Property(e => e.UserQuizId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("UserQuizID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.QuizId).HasColumnName("QuizID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.UserQuizzes)
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Quiz_Quiz");

                entity.HasOne(d => d.UserQuizNavigation)
                    .WithOne(p => p.UserQuiz)
                    .HasForeignKey<UserQuiz>(d => d.UserQuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Quiz_User");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.LessonId).HasColumnName("LessonID");

                entity.Property(e => e.VideoLink).IsUnicode(false);

                entity.Property(e => e.VideoName).HasMaxLength(200);

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKVideo395243");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
