using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseOrdering
{
    public class Logger : ILogger
    {

        public void LogProgress(List<ICourse> nextCourseIds, int completedCourseCount)
        {
            Console.WriteLine("Can complete the following course(s):");
            nextCourseIds.ForEach(x => Console.WriteLine(x.id + ", " + x.title));
            Console.WriteLine("Completed the following number of course(s) " + completedCourseCount);
        }
    }
}
