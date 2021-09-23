using CourseOrdering;
using Bogus;

namespace CourseOrderingTests
{
    public class PrerequisiteFaker:Faker<Prerequisite>
    {
        public PrerequisiteFaker() : base("en")
        {
            RuleFor(x => x.course, f => f.Random.Number(1, 100));
            RuleFor(x => x.prerequisite, f => f.Random.Number(1, 100));
        }

        public PrerequisiteFaker(int courseId, int prerequisiteId) : base("en")
        {
            RuleFor(x => x.course, f => courseId);
            RuleFor(x => x.prerequisite, f=> prerequisiteId);
        }
    }
}