using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;

namespace WebFormMvcFramework.Web.Ajax
{
    /// <summary>
    /// Signout 的摘要说明
    /// </summary>
    public class Signout : IHttpHandler, IRequiresSessionState
    {
        private WMF_System_IDAO sys_idao = new WMF_System_Dal();
        public void ProcessRequest(HttpContext context)
        {
            sys_idao.SysLoginLog(RequestSession.GetSessionUser().UserAccount.ToString(), "8", "IP归属地");
            context.Response.ContentType = "text/plain";
            HttpContext.Current.Session.Abandon();
            context.Response.Write("Ok");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}