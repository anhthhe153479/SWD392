﻿using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Section
    {
        public Section()
        {
            Lessons = new HashSet<Lesson>();
        }

        public int SectionId { get; set; }
        public int CourseId { get; set; }
        public string? SectionName { get; set; }
        public bool IsDisable { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}
