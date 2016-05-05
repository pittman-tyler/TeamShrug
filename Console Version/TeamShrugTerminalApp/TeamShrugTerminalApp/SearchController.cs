using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamShrugTerminalApp
{
    class SearchController
    {
        public static string CourseSearch(string coursID, Database db)
        {
            return db.search_for_courses(coursID);
        }

        public static string StudentSearch(string studID, Database db)
        {
            return db.search_for_users(studID);
        }
    }
}
