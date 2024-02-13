﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Courses
    {
        [Key]
        public int CourseId { get; set; }

        public string CourseName { get; set; }

        public string Image { get; set; }
    }
}
