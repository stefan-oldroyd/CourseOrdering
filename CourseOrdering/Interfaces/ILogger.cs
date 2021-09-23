using System.Collections.Generic;

namespace CourseOrdering
{
    public interface ILogger
    {
        void LogProgress(List<ICourse> nextCourseIds, int completedCourseCount);
    }
}