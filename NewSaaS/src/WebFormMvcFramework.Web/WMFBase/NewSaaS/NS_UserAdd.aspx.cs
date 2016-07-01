using System;
using System.Text;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_UserAdd : System.Web.UI.Page
    {
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            if (DataFactory.SqlDataBase().ReturnDataTable("select u_user from SaaS_User where(u_user='" + u_user.Value + "')").Rows.Count == 0)
            {
                StringBuilder SqlWhere = new StringBuilder();
                SqlWhere.Append("  UPDATE[dbo].[SaaS_User]  ");
                SqlWhere.Append("  SET[u_pwd] = '" + u_pwd.Value + "' ,   ");
                SqlWhere.Append("  [u_user] = '" + u_user.Value + "'    ");
                SqlWhere.Append("      WHERE[u_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");

                if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
                {
                    ShowMsgHelper.AlertMsg("添加成功！");
                }
                else
                {
                    ShowMsgHelper.Alert_Error("操作失败！");
                }
            }
            else
            {
                ShowMsgHelper.showWarningMsg("登录帐号已存在！");
            }
        }
    }
}