using System.Collections.Generic;
using System.Linq;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace CourseOrdering
{
    public class DAL : IDAL
    {
        private const string InputFileDir = ".\\SampleInputFiles\\{0}";
        public List<ICourse> GetCourses()
        {
            using (var reader = new StreamReader(string.Format(InputFileDir, "courses.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var courses = csv.GetRecords<Course>().ToList();
                return courses.ToList<ICourse>();
            }
        }
        public List<IPrerequisite> GetPrerequisites()
        {
            using (var reader = new StreamReader(string.Format(InputFileDir, "prerequisites.csv")))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var prerequisites = csv.GetRecords<Prerequisite>().ToList();
                return prerequisites.ToList<IPrerequisite>();
            }
        }
    }
}
