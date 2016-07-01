using System.Data;
using System.Web;
using System.Web.SessionState;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetJson;

namespace WebFormMvcFramework.Web.Frame
{
    /// <summary>
    /// Frame 的摘要说明
    /// </summary>
    public class Frame : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable//是否可再使用
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Buffer = true;
            //context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1.0);
            //context.Response.AddHeader("pragma", "no-cache");
            //context.Response.AddHeader("cache-control", "");
            //context.Response.CacheControl = "no-cache";
            string Action = context.Request["action"];
            string user_Account = context.Request["user_Account"];
            string userPwd = context.Request["userPwd"];
            string code = context.Request["code"];
            WMF_UserInfo_IDAO user_idao = new WMF_UserInfo_Dal();
            WMF_System_IDAO sys_idao = new WMF_System_Dal();
            string text = Action;
            if (HttpContext.Current.Session["Roles_ID"] != null)
            {
                string strMenus = JsonHelper.DataTableToJson(sys_idao.GetMenu(HttpContext.Current.Session["Roles_ID"].ToString()), "MENU");
                context.Response.Write(strMenus);
                context.Response.End();
            }
            if (text != null)
            {
                if (text == "init")
                {
                    var s = HttpContext.Current.Session.SessionID;
                    HttpContext.Current.Session["init"] = "123";
                }
                if (text == "Menu")
                {
                    string UserId = RequestSession.GetSessionUser().UserId.ToString();
                    string strMenus = JsonHelper.DataTableToJson(sys_idao.GetMenuHtml(UserId), "MENU");
                    context.Response.Write(strMenus);
                    context.Response.End();
                }
                else if (text == "login")
                {
                    var s2 = HttpContext.Current.Session.SessionID;
                    if (HttpContext.Current.Session["ValidateCode"] == null)
                    {
                        context.Response.Write("1");
                        context.Response.End();
                    }
                    if (code.ToLower() != HttpContext.Current.Session["ValidateCode"].ToString().ToLower())
                    {
                        context.Response.Write("1");
                        context.Response.End();
                    }
                    DataTable dtlogin = user_idao.UserLogin(user_Account.Trim(), userPwd.Trim());
                    if (dtlogin != null)
                    {
                        if (dtlogin.Rows.Count != 0)
                        {
                            sys_idao.SysLoginLog(user_Account, "1", "IP归属地");
                            if (dtlogin.Rows[0]["DeleteMark"].ToString() == "1")
                            {
                                if (this.Islogin(context, user_Account))
                                {
                                    if (RequestSession.AddSessionUser(new SessionUser
                                    {
                                        UserId = dtlogin.Rows[0]["User_ID"].ToString(),
                                        UserAccount = dtlogin.Rows[0]["User_Account"].ToString(),
                                        UserName = dtlogin.Rows[0]["User_Name"].ToString() + "(" + dtlogin.Rows[0]["User_Account"].ToString() + ")",
                                        UserPwd = dtlogin.Rows[0]["User_Pwd"].ToString()
                                    }) == "2")
                                    {
                                        context.Response.Write("7");
                                        context.Response.End();
                                    }

                                    context.Response.Write("3");
                                    context.Response.End();
                                }
                                else
                                {
                                    context.Response.Write("6");
                                    context.Response.End();
                                }
                            }
                            else
                            {
                                context.Response.Write("2");
                                context.Response.End();
                            }
                        }
                        else
                        {
                            context.Response.Write("4");
                            context.Response.End();
                        }
                    }
                    else
                    {
                        context.Response.Write("5");
                        context.Response.End();
                    }
                }
            }
        }

        public bool Islogin(HttpContext context, string User_Account)
        {
            return true;
        }
    }
}