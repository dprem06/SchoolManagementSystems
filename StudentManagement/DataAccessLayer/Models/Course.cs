using System;
using System.Collections.Generic;


namespace DataAccessLayer.Models
{
    public partial class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public string CourseDescription { get; set; }
        public string IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
