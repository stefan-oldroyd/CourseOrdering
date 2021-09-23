using System;
using System.Collections.Generic;
using System.Linq;

namespace CourseOrdering
{
    public class CourseStrategy : ICourseStrategy
    {
        private readonly List<IPrerequisite> _PreRequisites;
        private readonly List<ICourse> _Courses;
        private readonly ILogger _logger;
        private List<int> _CompletedCourseIds = new List<int>();

        public CourseStrategy(List<IPrerequisite> preRequisites, List<ICourse> courses, ILogger logger)
        {
            _PreRequisites = preRequisites;
            _Courses = courses;
            _logger = logger;
        }

        public void Execute()
        {
            while (CanDoMoreCourses())
            {
                LogProgress();
                UpdateCompletedCourses();
            }
        }

        private void LogProgress()
        {
            _logger.LogProgress(NextCourseIds(), CompletedCourseCount());
        }

        private bool CanDoMoreCourses()
        {
            bool completedMoreCourses = false;

            if (CompletedCourseCount() > 0)
            {
                completedMoreCourses = true;
            }

            return completedMoreCourses;
        }

        private int CompletedCourseCount()
        {
            int completedCourseCount = NextCourseIds().Count();

            return completedCourseCount;
        }

        private IEnumerable<int> RemainingCourseIds()
        {
            IEnumerable<int> remainingCourseIds = _PreRequisites.Select(x => x.course).Where(y => !_CompletedCourseIds.Contains(y));

            return remainingCourseIds;
        }

        private List<int> InvalidPreRequisiteCourseIds()
        {
            //courses with invalid dependencies
            var invalidPreRequisiteCourseIds = _PreRequisites.Where(y => RemainingCourseIds().Contains(y.course) &&
                                                            !_CompletedCourseIds.Contains(y.prerequisite))
                                                            .Select(x => x.course).Distinct().ToList();

            return invalidPreRequisiteCourseIds;
        }

        private List<ICourse> NextCourseIds()
        {
            //NOT COMPLETED
            //WHERE none of the prerequisits are in the not completed list
            var nextCourseIds = _Courses.Where(x => !InvalidPreRequisiteCourseIds().Contains(x.id) &&
                                                       !_CompletedCourseIds.Contains(x.id));

            return nextCourseIds.ToList();
        }

        private void UpdateCompletedCourses()
        {
            _CompletedCourseIds.AddRange(NextCourseIds().Select(x => x.id).Distinct());
        }
    }
}

