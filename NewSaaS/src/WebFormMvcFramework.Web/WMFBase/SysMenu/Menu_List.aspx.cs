using System;
using System.Web;
using System.Web.SessionState;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;

namespace WebFormMvcFramework.Web.WMFBase.SysMenu
{
    public class Menu_List : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            string Action = context.Request["action"].Trim();
            string ParentId = context.Request["ParentId"];
            string key = context.Request["key"];
            WMF_System_IDAO systemidao = new WMF_System_Dal();
            string text = Action;
            if (text != null)
            {
                if (text == "addButton")
                {
                    context.Response.Write(systemidao.AllotButton(key, ParentId));
                    context.Response.End();
                }
            }
        }
    }
}