﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOrdering
{
    public class Course : ICourse
    {
        public int id { get; set; }
        public string title { get; set; }
    }
}
