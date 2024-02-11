using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CourseDetails
    {
        [Key]
        public int CourseDetailId { get; set; }

        public string CourseName { get; set; }

        public string Description { get; set; }

        public string CourseLocation { get; set; }

        public int CourseDuration { get; set; } //kurs süresi

        [ForeignKey("CourseId")]
        public Courses Courses { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CategoryId")]
        public CoursesCategories CoursesCategories { get; set; }
        public int CategoryID { get; set; }

    }
}
