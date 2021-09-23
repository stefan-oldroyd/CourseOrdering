using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOrdering
{
    public class Prerequisite : IPrerequisite
    {
        public int course { get; set; }
        public int prerequisite { get; set; }
    }
}
