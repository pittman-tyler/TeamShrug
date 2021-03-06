﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database db = new Database();
            string loggedInUser = "";
            while (true)
            {
                Console.Clear();
                int typeUser = -5;
                string input;
                while (typeUser < 0)
                {
                    Console.Write("Welcome to the University Registration System.\n\nPlease Login\nUsername: ");
                    loggedInUser = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    typeUser = LoginController.login(db, loggedInUser, password);

                    if (typeUser < 0)
                    {
                        Console.WriteLine("Invalid username or password. Please try again.\n\n[Five Second Timeout]");
                        System.Threading.Thread.Sleep(5000);
                        Console.Clear();


                    }
                }
                #region Administrator View 
                if (typeUser == 1)
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("\nPlease Select an option below.\n1 Main \n2 Search For Course \n3 Search For User \n4 Modify Registration Status \n5 Create or Delete User \n6 Create or Delete a Course \n7 View Enrollment Summary \n8 Logout\n\nOption: ");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input)
                        {
                            case "1": //Main
                                break;
                            case "2": //Search Course
                                Console.Write("Search for a course.\n\n\tEnter a Course ID: ");
                                string courseInput = Console.ReadLine();
                                Console.WriteLine(SearchController.CourseSearch(courseInput, db) + "\n");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "3": //Search User
                                Console.Write("Search For a User. \n\n\tPlease Enter a User ID: ");
                                string studentInput = Console.ReadLine();
                                Console.WriteLine(SearchController.StudentSearch(studentInput, db) + "\n");
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "4": //Modify Registration Status
                                Console.Write("Modify Registration Status Page\n\n\tPlease enter a student ID: ");
                                string regStatusKey = Console.ReadLine();
                                Console.Write("Enter Registration Status [1 for registered, 0 for unregistered]: ");
                                string regStatus = Console.ReadLine();
                                Console.WriteLine(StudentController.changeRegistrationStatus(db, regStatusKey, regStatus));
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "5": //Create Delete User
                                Console.Write("Please enter 1 for create user, and 2 for delete user.");
                                string choice = Console.ReadLine();
                                string username;
                                string password;
                                if (String.Compare(choice, "1") == 0)
                                {
                                    Console.Write("What kind of user is this? Enter 1 for Student, 2 for Administrator, or 3 for Teacher: ");
                                    string typeOfUser = Console.ReadLine();
                                    Console.Write("Name: ");
                                    string personName = Console.ReadLine();
                                    Console.Write("Username: ");
                                    username = Console.ReadLine();
                                    Console.Write("Password: ");
                                    password = Console.ReadLine();
                                    if (String.Compare(typeOfUser, "1") == 0)
                                    {
                                        Console.Write("Registration Status [0 for unregistered, 1 for registered]:");
                                        string registrationStatus = Console.ReadLine();
                                        Console.WriteLine(StudentController.create_student(personName, username, password, registrationStatus, db));
                                    }
                                    else if (String.Compare(typeOfUser, "2") == 0)
                                    {
                                        Console.WriteLine(UserController.create_administrator(personName, username, password, db));
                                    }
                                }
                                else if (String.Compare(choice, "2") == 0)
                                {
                                    Console.Write("Enter the username of the user you would like to delete: ");
                                    username = Console.ReadLine();
                                    Console.WriteLine(UserController.delete_user(username, db));
                                }
                                else { Console.WriteLine("Invalid Selection. Please try again."); }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "6": //Create Delete Course
                                Console.Write("Create Or Delete Course.\n\n\tEnter 1 to create a course or 2 to delete a course.");
                                choice = Console.ReadLine();
                                if (string.Compare(choice, "1") == 0)
                                {
                                    Console.Write("Course Name: ");
                                    string courseName = Console.ReadLine();
                                    Console.Write("Course Description: ");
                                    string courseDescription = Console.ReadLine();
                                    Console.Write("Course Hours: ");
                                    string courseHours = Console.ReadLine();
                                    Console.Write("Course ID: ");
                                    string courseID = Console.ReadLine();
                                    Console.Write("Teacher's Name: ");
                                    string teacherName = Console.ReadLine();
                                    Console.Write("Meeting Days [Enter 1 for MWF, 2 for TR]: ");
                                    string meetingDays = Console.ReadLine();
                                    Console.Write("Credit Hours (0-4): ");
                                    string creditHours = Console.ReadLine();
                                    Console.Write("Class Time [4-7]: ");
                                    string classTime = Console.ReadLine();
                                    Console.Write("Maximum Size: ");
                                    string maxSize = Console.ReadLine();
                                    Console.WriteLine(CourseController.addCourse(courseName, courseDescription, courseHours, courseID, teacherName, meetingDays, creditHours, classTime, maxSize, db));
                                }
                                else if (string.Compare(choice, "2") == 0)
                                {
                                    Console.Write("Enter the Course ID that you would like deleted: ");
                                    string courseID = Console.ReadLine();
                                    Console.WriteLine(CourseController.delete_course(courseID, db));
                                }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "7": //Views Student
                                Console.WriteLine(StudentController.get_student_list(db));
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "8": //Logout
                                break;



                            default:
                                Console.WriteLine("Invalid Input. Press any key to continue");
                                Console.ReadKey();
                                break;
                        }
                    } while (string.Compare(input, "8") != 0);
                    Console.Clear();

                }
                #endregion

                #region Student View
                else if (typeUser == 2)
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("\nPlease Select an option below.\n1 Main \n2 Search Courses \n3 Add or Drop Course \n4 Transcript View \n5 Schedule View \n6 Logout\n\nOption: ");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input)
                        {
                            case "1":

                                break;
                            case "2":
                                Console.WriteLine("Course Search");
                                Console.Write("Enter the Course ID you would like to search for:");
                                string courseID = Console.ReadLine();
                                Console.WriteLine(SearchController.CourseSearch(courseID, db));
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "3": //ADD OR DROP COURSE
                                Console.WriteLine("Add or Drop a Course View");
                                Console.Write("\n1 Add a Course \n2 Drop a Course\nOption: ");
                                input = Console.ReadLine();
                                if (string.Compare(input, "1") == 0)
                                {
                                    Console.Write("Please input a course ID: ");
                                    string selection = Console.ReadLine();
                                    Console.WriteLine(StudentController.add_course(input, loggedInUser, db));
                                }
                                else if (string.Compare(input, "2") == 0)
                                {
                                    Console.Write("Select a course from the list." + UserController.schedule_view(loggedInUser, db));
                                    Console.Write("Course ID: ");
                                    string selection = Console.ReadLine();
                                    Console.WriteLine(StudentController.drop_course(selection, loggedInUser, db));
                                }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "4":
                                Console.WriteLine("Transcript View");
                                Console.WriteLine(StudentController.view_transcript(db, loggedInUser));
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "5":
                                Console.WriteLine("Schedule View");
                                Console.WriteLine(UserController.schedule_view(loggedInUser, db));
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "6":
                                break;
                            default:
                                break;
                        }
                    } while (string.Compare(input, "6") != 0);

                }
                #endregion

                #region Teacher View
                else if (typeUser == 3)
                {
                    do
                    {
                        Console.Clear();
                        Console.Write("\nPlease Select an option below.\n1 Main \n2 Schedule View \n3 Logout\n\nOption: ");
                        input = Console.ReadLine();
                        Console.Clear();
                        switch (input)
                        {
                            case "1":
                                break;
                            case "2":
                                Console.WriteLine("Schedule View\n\nPlease select a course from the list.\n");
                                Console.Write(UserController.schedule_view(loggedInUser, db));
                                Console.Write("Selection [courseID]: ");
                                string selection = Console.ReadLine();
                                Console.WriteLine("Options: \n1\tView Student List\n2\tMain Menu");
                                string selection2 = Console.ReadLine();
                                if (string.Compare(selection2, "1") == 0)
                                {
                                    Console.WriteLine("Select a student from the list below.");
                                    Console.WriteLine(CourseController.view_students(selection, db) + "\nUsername: ");
                                    string selection3 = Console.ReadLine();
                                    Console.WriteLine("Input grade A = 4, B = 3, C = 2, D = 1, F = 0: ");
                                    string grade = Console.ReadLine();
                                    Console.WriteLine(StudentController.update_grade(selection, selection3, grade, db));
                                }
                                else { break; }
                                Console.WriteLine("Press any key to continue.");
                                Console.ReadKey();
                                break;
                            case "3":
                                break;
                            default:
                                break;
                        }



                    } while (string.Compare(input, "3") != 0);
                }
                #endregion
            }


        }
    }
}