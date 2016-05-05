using System;

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
        }
    }
}