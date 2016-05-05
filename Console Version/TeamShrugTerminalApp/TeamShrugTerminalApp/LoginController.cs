using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    class LoginController
    {
        //Returns -1 if the username and password combination do not exist. Returns 1 if admin, returns 2 if student, and returns 3 if teacher
        public static int login(Database db, string username, string password)
        {
            if (db.get_admin(username) != null && db.get_admin(username).check_password(password))
            {
                return 1;
            }
            else if (db.get_student(username) != null && db.get_student(username).check_password(password))
            {
                return 2;
            }
            else if (db.get_teacher(username) != null && db.get_teacher(username).check_password(password))
            {
                return 3;
            }
            else { return -1; }
        }
    }
}
