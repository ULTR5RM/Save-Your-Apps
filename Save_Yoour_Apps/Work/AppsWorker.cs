using Save_Yoour_Apps.Models;
using Save_Yoour_Apps.Connection;

namespace Save_Yoour_Apps.Work
{
    public static class AppsWorker
    {
        public static int AppsCount(string mail) //счетчик  количества приложений
        {
            return GetAppList(mail).Count;
        }
        public static bool CheckName(string mail, string name) //проверка на имя приложения
        {//true - Приложение есть
            return false;
        }
        public static string IdentityCreator()
        {
            string res = "";
            const string chars = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890qwertyuiopasdfghjklzxcvbnm";
            Random rand = new Random();

            do
            {
                for (int a = 0; a < 6; a++)
                {
                    res += chars[rand.Next(chars.Length)];
                }
            } while (IdentityToId(res) != -1);

            return res;
        } // генератор идентификатора
        public static void CreateApp(App app, string ownerMail) //создание приложения
        {
            int oid = UserWorker.MailToId(ownerMail);

            if (oid == 0) return;
            app.owner = oid;
            using (AppsContext db = new AppsContext())
            {
                App newApp = app;
                db.Add(newApp);
                db.SaveChanges();
            }
        }
        public static int IdentityToId(string identity)
        {
            using (AppsContext db = new AppsContext())
            {
                App app = db.Apps
                .Where(b => b.Identity == identity)
                .FirstOrDefault(); //Возвращает первый элемент последовательности или значение по умолчанию, если ни одного элемента не найдено.

                if (app == null)
                {
                    return -1;
                }
                return app.Id;
            }
        }
        public static App FindById(int id)
        {
            using (AppsContext db = new AppsContext())
            {
                App app = db.Apps
                    .Where(b => b.Id == id)
                    .FirstOrDefault();

                return app;
            }
        }
        public static List<App> GetAppList(string ownerMail)
        {
            List<App> appList = new List<App>();

            int oid = UserWorker.MailToId(ownerMail);

            if (oid == -1) return appList;

            using (AppsContext db = new AppsContext())
            {
                foreach (App entry in db.Apps.Where(b => b.owner == oid))
                {
                    appList.Add(entry);
                }
            }
            return appList;
        }
    }
}
