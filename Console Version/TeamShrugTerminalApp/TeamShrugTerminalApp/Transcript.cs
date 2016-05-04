using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    public class Transcript
    {
        public double gpa { get; set; }
        public int completedHours { get; set; }
        public int numCompletedCourses;


        //A way to keep records of grades
        public struct completedCourses
        {
            public string courseName { get; set; }
            public int courseHours { get; set; }
            public string courseID { get; set; }
            public int grade { get; set; }

            public completedCourses(string courseNameIn, int courseHoursIn, string CourseIDIn, int gradeIn)
            {
                courseName = courseNameIn;
                courseHours = courseHoursIn;
                courseID = CourseIDIn;
                grade = gradeIn;
            }
        };

        

        public List<completedCourses> listOfCourses;

        public Transcript()
        {
            gpa = 0;
            completedHours = 0;
            numCompletedCourses = 0;
            completedHours = 0;
        }
        public void update_transcript(Course a, int gradeIn)
        {
            //   completedCourses addClass = new completedCourse();

            this.calculate_GPA();
        }

        public void calculate_GPA()
        {
            if (this.completedHours == 0)
            {
                this.gpa = 0;
            }
            else
            {
                int temp = 0;
                completedCourses tempCourse;
                for(int i = 0; i < listOfCourses.Count; i++)
                {
                    tempCourse = listOfCourses[i];
                    temp += tempCourse.grade;
                }
            }
        }

        public double getGPA()
        {
            this.calculate_GPA();
            return this.gpa;
        }
    }
}
