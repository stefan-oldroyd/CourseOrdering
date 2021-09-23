using System.Collections.Generic;

namespace CourseOrdering
{
    public class CourseEngine : ICourseEngine
    {
        private readonly List<IPrerequisite> _PreRequisites;
        private readonly List<ICourse> _Courses;
        private readonly ILogger _logger = new Logger();
        private List<int> _CompletedCourseIds = new List<int>();
        private readonly ICourseStrategy _CourseStrategy;


        public CourseEngine()
        {
            var dal = new DAL();
            _PreRequisites = dal.GetPrerequisites();
            _Courses = dal.GetCourses();
            _CourseStrategy = new CourseStrategy(_PreRequisites, _Courses, _logger);
        }

        public CourseEngine(IDAL dal, ICourseStrategy courseStrategy)
        {
            _PreRequisites = dal.GetPrerequisites();
            _Courses = dal.GetCourses();
            _CourseStrategy = courseStrategy;
        }

        public void CalculateCourses()
        {
            _CourseStrategy.Execute();
        }
    }
}
