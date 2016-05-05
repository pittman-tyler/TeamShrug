using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    public class User
    {
        //variables that will be used by all users

        protected string name;
        protected string username;
        protected string password;

        //empty constructor so that we can use inheritance
        public User() { }

        //standard constructor for the User class.
        public User(string nameIn, string usernameIn, string passwordIn)
        {
            name = nameIn;
            username = usernameIn;
            password = passwordIn;
        }

        //Return the user's name
        public string get_name()
        {
            return name;
        }

        //returns the user's username
        public string get_username()
        {
            return username;
        }

        //check the input password with the user's password
        public bool check_password(string input)
        {
            return input.Equals(password);
        }

        public string toString()
        {
            string output = "Name = ";
            output += this.name + "\tUsername" + this.username;
            return output;
        }

        public string search_users(string input, Database db)
        {
            return db.search_for_users(input);
        }
    }

    //Specialization for the "student" user
    public class Student : User
    {
        //Student's variables
        protected bool registrationStatus { get; set; }
        public Transcript studentTranscript = new Transcript();
        public Schedule schedule;

        public Student() { }

        //Student's constructor
        public Student(string nameIn, string usernameIn, string passwordIn, bool registrationstatusIn)
        {
            this.name = nameIn;
            this.username = usernameIn;
            this.password = passwordIn;
            this.registrationStatus = registrationstatusIn;
            this.studentTranscript = new Transcript();
            this.schedule = new Schedule();
        }

        
        //Allows changes to the registration status
        public int set_registration_status(bool regStatusIn)
        {
            this.registrationStatus = regStatusIn;
            return 0;
        }

        //return the user's registration status
        public bool get_registration_status()
        {
            return this.registrationStatus;
        }

        public Transcript get_student_transcript()
        {
            return this.studentTranscript;
        }

        new public string toString()
        {
            string output = "Name: ";
            output += this.name + "\tUsername: " + this.username;
            output += "\tRegistration Status: ";
            if (this.registrationStatus) {
                output += "Active";
            }
            else
            {
                output += "Inactive";
            }
            return output;
        }
    }

    //Speciliazation for the "Teacher" user
    public class Teacher : User
    {
        public Teacher(string nameIn, string usernameIn, string passwordIn) : base(nameIn, usernameIn, passwordIn)
        {
        }

        public void assignGrade(Course a_course, Student a_student, int gradeInput)
        {
            Transcript tempTranscript = a_student.get_student_transcript();
            tempTranscript.update_transcript(a_course, gradeInput);
        }
    }

    //Specilization for the "Administrator" user -- need to implement
    public class Administrator : User
    {
        public Administrator(string nameIn, string usernameIn, string passwordIn) : base(nameIn, usernameIn, passwordIn)
        {
            //uses the default constructor for User
        }

        private void create_student(string nameIn, string usernameIn, string passwordIn, bool registrationstatusIn)
        {
            //Done in controllers        
        }
        private void create_teacher(string nameIn, string usernameIn, string passwordIn)
        {
            //Done in controllers
        }
        private void create_admin(string nameIn, string usernameIn, string passwordIn)
        {
            //Done in controllers
        }
        private void create_course(string courseIDin, string nameIn, string description, string teacherNameIn, int meetingInfoIn, int creditHours, int timeIn, int maxSize)
        {
            //Done in controllers
        }
        private void delete_course(string courseID)
        {
            //Done in controllers
        }
    }
}
