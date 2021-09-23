using CourseOrdering;
using Bogus;

namespace CourseOrderingTests
{
    public class CourseFaker:Faker<Course>
    {
        public CourseFaker() : base("en")
        {
            RuleFor(x => x.id, f => f.Random.Number(1, 100));
            RuleFor(x => x.title, f => f.Lorem.Sentence());
        }

        public CourseFaker(int id) : base("en")
        {
            RuleFor(x => x.id, f => id);
            RuleFor(x => x.title, f => f.Lorem.Sentence());
        }
    }
}