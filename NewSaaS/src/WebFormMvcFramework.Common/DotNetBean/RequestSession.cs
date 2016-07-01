using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.SessionState;

namespace WebFormMvcFramework.Common.DotNetBean
{
    public class RequestSession
    {
        private static string SESSION_USER = "SESSION_USER";

        public static string AddSessionUser(SessionUser user)
        {
            // HttpContext rq = HttpContext.Current;
            // rq.Session[RequestSession.SESSION_USER] = user;
            //防止一个浏览器多次登陆窜值
            if (GetSessionUser() == null)
            {
                user.SessionId = HttpContext.Current.Session.SessionID;
                HttpContext.Current.Session["SESSION_USER"] = user;
                return "1";
            }
            if (GetSessionUser().SessionId == HttpContext.Current.Session.SessionID)
            {
                return "2";
            }
            return "2";
        }

        public static SessionUser GetSessionUser()
        {
            // HttpContext rq = HttpContext.Current;
            // return (SessionUser)rq.Session[RequestSession.SESSION_USER];
            string names = HttpContext.Current.Session.SessionID;
            return (SessionUser)HttpContext.Current.Session["SESSION_USER"];
        }
    }
}