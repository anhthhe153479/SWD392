using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Doc
    {
        public int DocsId { get; set; }
        public int LessonId { get; set; }
        public string? Content { get; set; }

        public virtual Lesson Lesson { get; set; } = null!;
    }
}
