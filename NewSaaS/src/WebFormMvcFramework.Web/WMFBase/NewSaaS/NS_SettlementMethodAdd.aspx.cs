using System;
using System.Text;
using System.Web;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_SettlementMethodAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  INSERT INTO [dbo].[SaaS_SettlementMethod]  ");
            SqlWhere.Append("  ([s_guid]  ");
            SqlWhere.Append("  ,[s_name]    ");
            SqlWhere.Append("   ,[u_guid]  ");
            SqlWhere.Append(" ,[s_CreationTime] ");
            SqlWhere.Append("  ,[s_number]) ");
            SqlWhere.Append("     VALUES ");
            SqlWhere.Append("  (  ");
            SqlWhere.Append(" '" + Guid.NewGuid().ToString() + "', ");
            SqlWhere.Append("  '" + s_name.Value + "',  ");
            SqlWhere.Append("  '" + HttpContext.Current.Session["u_UserParent"].ToString() + "',  ");
            SqlWhere.Append("  '" + DateTime.Now.ToString() + "',  ");
            SqlWhere.Append("  '" + s_number.Value + "'  ");

            SqlWhere.Append("  )  ");

            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}