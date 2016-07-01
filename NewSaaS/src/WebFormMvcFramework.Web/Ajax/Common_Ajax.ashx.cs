using System;
using System.Web;
using System.Web.SessionState;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;

namespace WebFormMvcFramework.Web.Ajax
{
    /// <summary>
    /// Common_Ajax 的摘要说明
    /// </summary>
    public class Common_Ajax : IHttpHandler, IRequiresSessionState
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
            string Action = context.Request["action"];
            string module = context.Request["module"];
            string tableName = context.Request["tableName"];
            string pkName = context.Request["pkName"];
            string pkVal = context.Request["pkVal"];
            WMF_System_IDAO system_idao = new WMF_System_Dal();
            string text = Action;
            if (text != null)
            {
                if (!(text == "Cut"))
                {
                    if (!(text == "Virtualdelete"))
                    {
                        if (!(text == "Delete"))
                        {
                            if (text == "IsExist")
                            {
                                int Return = system_idao.IsExist(tableName.Trim(), pkName.Trim(), pkVal.Trim());
                                context.Response.Write(Return.ToString());
                            }
                        }
                        else
                        {
                            int Return = system_idao.DeleteData_Base(tableName.Trim(), pkName.Trim(), pkVal.Split(new char[]
							{
								','
							}));
                            context.Response.Write(Return.ToString());
                        }
                    }
                    else
                    {
                        int Return = system_idao.Virtualdelete(module.Trim(), tableName.Trim(), pkName.Trim(), pkVal.Trim().Split(new char[]
						{
							','
						}));
                        context.Response.Write(Return.ToString());
                    }
                }
                else
                {
                    context.Session.Abandon();
                    context.Session.Clear();
                    context.Response.Write(1);
                    context.Response.End();
                }
            }
        }
    }
}