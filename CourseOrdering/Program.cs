using System;
using System.Linq;

namespace CourseOrdering
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Write a program that, given a list of courses and their pre-requisites, 
             * produce a possible order in which a student can complete as many of the provided course units as possible, 
             * adhering to the pre-requisite requirements.
             
              The program reads from two input files, “courses.csv” and “prerequisites.csv”, 
              which can be found in SampleInputFiles/ folder.
             */

            var engine = new CourseEngine();
            engine.CalculateCourses();

            Console.ReadKey();
        }
    }
}
