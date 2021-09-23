using NUnit.Framework;
using CourseOrdering;
using FluentAssertions;
using Moq;
using System.Collections.Generic;

namespace CourseOrderingTests
{
    public class Tests
    {
        private Prerequisite _Prerequisite;
        private Course _Course;
        private List<IPrerequisite> _PrerequisiteList;
        private List<ICourse> _CourseList;


        [SetUp]
        public void Setup()
        {
            _PrerequisiteList = new List<IPrerequisite>();
            _CourseList = new List<ICourse>();

            //no dependencies
            var courseFaker1 = new CourseFaker(101);
            var course1 = courseFaker1.Generate();

            //
            var courseFaker2 = new CourseFaker();
             _Course = courseFaker2.Generate();

            var prerequisiteFaker = new PrerequisiteFaker(course1.id, _Course.id);
            _Prerequisite = prerequisiteFaker.Generate();


            _PrerequisiteList.Add(_Prerequisite);
            _CourseList.Add(course1);
            _CourseList.Add(_Course);
        }

        [Test]
        public void Course()
        {
            _Course.id.Should().BeInRange(1,100);
            _Course.title.Should().NotBeNullOrWhiteSpace();
        }

        [Test]
        public void Prerequisite()
        {
            _Prerequisite.prerequisite.Should().BeInRange(1, 100);
            _Prerequisite.course.Should().Be(101);
        }

        [Test]
        public void CourseEngine()
        {   
            //Arrange
            var strategy = new Mock<ICourseStrategy>();
            var dal = new Mock<IDAL>();
            dal.Setup(x => x.GetPrerequisites()).Returns(_PrerequisiteList);
            dal.Setup(x => x.GetCourses()).Returns(_CourseList);

            //Act
            var courseEngine = new CourseEngine(dal.Object, strategy.Object);
            courseEngine.CalculateCourses();

            //Assert
            strategy.Verify(x => x.Execute(), Times.Once);
        }

        [Test]
        public void CourseStrategy()
        {
            //Arrange
            var logger = new Mock<ILogger>();

            //Act
            var courseStrategy = new CourseStrategy(_PrerequisiteList, _CourseList, logger.Object);
            courseStrategy.Execute();

            //Assert
            logger.Verify(x => x.LogProgress(It.IsAny<List<ICourse>>(), 1), Times.Exactly(2));

        }

        [Test]
        public void DAL()
        {
            //Arrange
            var dal = new DAL();

            //Act
            var courses = dal.GetCourses();
            var preRequisites = dal.GetPrerequisites();

            //Assert
            courses.Count.Should().BeGreaterThan(0);
            preRequisites.Count.Should().BeGreaterThan(0);
        }

    }
}