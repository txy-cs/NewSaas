using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.SessionState;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetData;
using WebFormMvcFramework.Common.DotNetJson;
namespace WebFormMvcFramework.Web.WMFBase.SysUserGroup
{
    public class UserGroup : IHttpHandler, IRequiresSessionState
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
            string txt_Search = context.Request["txt_Search"];
            string Searchwhere = context.Request["Searchwhere"];
            string UserGroup_ID = context.Request["UserGroup_ID"];
            string User_ID = context.Request["User_ID"];
            WMF_UserInfo_IDAO user_idao = new WMF_UserInfo_Dal();
            string text = Action;
            if (text != null)
            {
                if (!(text == "UserList"))
                {
                    if (!(text == "UserGroupInfo"))
                    {
                        if (text == "UserGroupaddMember")
                        {
                            bool IsOk = user_idao.AddUserGroupMenber(User_ID.Split(new char[]
							{
								','
							}), UserGroup_ID);
                            if (IsOk)
                            {
                                context.Response.Write(1);
                                context.Response.End();
                            }
                            else
                            {
                                context.Response.Write(-1);
                                context.Response.End();
                            }
                        }
                    }
                    else
                    {
                        context.Response.Write(this.InitUserGroupInfo(user_idao.Load_UserInfoUserGroupList(UserGroup_ID)));
                        context.Response.End();
                    }
                }
                else
                {
                    StringBuilder SqlWhere = new StringBuilder();
                    if (!string.IsNullOrEmpty(txt_Search))
                    {
                        SqlWhere.Append(" AND " + Searchwhere.Trim() + " like  '%" + txt_Search.Trim() + "%' ");
                    }
                    SqlWhere.Append(" AND USER_ID NOT IN(SELECT USER_ID FROM Base_UserInfoUserGroup WHERE UserGroup_ID = '" + UserGroup_ID + "')");
                    context.Response.Write(JsonHelper.DataTableToJson(user_idao.GetUserInfoInfo(SqlWhere), "UserGroupList"));
                    context.Response.End();
                }
            }
        }
        public string InitUserGroupInfo(DataTable dt)
        {
            StringBuilder str_allUserGroup = new StringBuilder();
            if (DataTableHelper.IsExistRows(dt))
            {
                DataView dv = new DataView(dt);
                foreach (DataRowView drv in dv)
                {
                    str_allUserGroup.Append("<li>");
                    str_allUserGroup.Append(string.Concat(new object[]
					{
						"<div ondblclick=\"DeleteMember('",
						drv["UserInfoUserGroup_ID"],
						"')\" title='成员'><img src=\"../../Themes/Images/user_mature.png\" width=\"16\" height=\"16\" />",
						drv["User_Name"],
						"</div>"
					}));
                    str_allUserGroup.Append("</li>");
                }
            }
            else
            {
                str_allUserGroup.Append("<li>");
                str_allUserGroup.Append("<div><span style='color:red;'>暂无数据</span></div>");
                str_allUserGroup.Append("</li>");
            }
            return str_allUserGroup.ToString();
        }
    }
}
