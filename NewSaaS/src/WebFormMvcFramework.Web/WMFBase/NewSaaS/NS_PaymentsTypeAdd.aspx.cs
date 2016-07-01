using System;
using System.Text;
using System.Web;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_PaymentsTypeAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  INSERT INTO [dbo].[SaaS_PaymentsType]  ");
            SqlWhere.Append("  ([p_guid]  ");
            SqlWhere.Append("  ,[p_name]    ");
            SqlWhere.Append("   ,[u_guid]  ");
            SqlWhere.Append(" ,[p_CreationTime] ");
            SqlWhere.Append(" ,[p_Remarks] ");
            SqlWhere.Append("  ,[p_number]) ");
            SqlWhere.Append("     VALUES ");
            SqlWhere.Append("  (  ");
            SqlWhere.Append(" '" + Guid.NewGuid().ToString() + "', ");
            SqlWhere.Append("  '" + p_name.Value + "',  ");
            SqlWhere.Append("  '" + HttpContext.Current.Session["u_UserParent"].ToString() + "',  ");
            SqlWhere.Append("  '" + DateTime.Now.ToString() + "',  ");
            SqlWhere.Append("  '" + p_Remarks.Value + "',  ");
            SqlWhere.Append("  '" + p_number.Value + "'  ");

            SqlWhere.Append("  )  ");

            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}