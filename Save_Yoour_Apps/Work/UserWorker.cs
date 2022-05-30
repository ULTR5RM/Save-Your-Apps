using Save_Yoour_Apps.Models;
using Save_Yoour_Apps.Connection;

namespace Save_Yoour_Apps.Work
{
    public static class UserWorker
    {
        public static bool AuthUser(string mail, string pass)
        {
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .Where(b=> b.Password==pass)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool CheckMail(string mail)
        {
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return false;
                }
            }

            return true;
        }
        public static int MailToId(string mail)
        {
            using (UserContext db = new UserContext())
            {
                User usr = db.Users
                    .Where(b => b.Email == mail)
                    .FirstOrDefault();

                if (usr == null)
                {
                    return -1;
                }
                return usr.Id;
            }
        }
        public static void AddUser(User usr)
        {
            using (UserContext db = new UserContext())
            {
                User newUser = usr;
                db.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
