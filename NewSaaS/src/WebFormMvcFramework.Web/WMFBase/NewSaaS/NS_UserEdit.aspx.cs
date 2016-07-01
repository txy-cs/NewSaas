using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_UserEdit : System.Web.UI.Page
    {
        private string Str_u_guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Str_u_guid = Request.QueryString["Key"].ToString();
                DataTable SaaS_User = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_User where(u_guid='" + Str_u_guid + "')").Copy();
                u_user.Value = SaaS_User.Rows[0]["u_user"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_User]  ");
            SqlWhere.Append("  SET[u_pwd] = '" + u_pwd.Value + "' ,   ");
            SqlWhere.Append("      WHERE[u_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}