﻿using System;

namespace TeamShrugTerminalApp
{
    internal class UserController
    {
        internal static string create_administrator(string personName, string username, string password, Database db)
        {
            if(db.get_admin(username) != null)
            {
                return "Administrator already exists. Please use a different username";
            }
            else
            { 
                Administrator temp = new Administrator(personName, username, password);
                db.add_user(temp);
            }
                return "Success!";
            
        }

        internal static string delete_user(string username, Database db)
        {
            db.delete_user(username);
            return "Success!";
        }

        internal static string schedule_view(string userID, Database db)
        {
            if (db.get_teacher(userID) != null){
                Teacher temp = db.get_teacher(userID);
                return temp.getSchedule().display_courses();

            }
            else if (db.get_student(userID) != null) {
                Student temp = db.get_student(userID);
                return temp.get_schedule().display_courses();
            }
            else
            {
                return "User does not exist.";
            }
            
        }
    }
}