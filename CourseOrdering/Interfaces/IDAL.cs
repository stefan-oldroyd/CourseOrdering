using System.Collections.Generic;

namespace CourseOrdering
{
    public interface IDAL
    {
        List<ICourse> GetCourses();
        List<IPrerequisite> GetPrerequisites();
    }
}