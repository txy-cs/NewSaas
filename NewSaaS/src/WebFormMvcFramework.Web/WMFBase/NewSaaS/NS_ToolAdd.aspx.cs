using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_ToolAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            DataTable SaaS_tool = DataFactory.SqlDataBase().ReturnDataTable("select count(*) as HS from SaaS_tool where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "')").Copy();
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  INSERT INTO [dbo].[SaaS_tool]  ");
            SqlWhere.Append("  ([c_guid]  ");
            SqlWhere.Append("  ,[c_number]    ");
            SqlWhere.Append("   ,[c_name]  ");
            SqlWhere.Append(" ,[c_state] ");
            SqlWhere.Append(" ,[c_Remarks] ");
            SqlWhere.Append(" ,[c_PurchasePrice] ");
            SqlWhere.Append(" ,[c_BuyingTime] ");
            SqlWhere.Append(" ,[u_guid] ");
            SqlWhere.Append("  ,[c_CreationTime]) ");
            SqlWhere.Append("     VALUES ");
            SqlWhere.Append("  (  ");
            SqlWhere.Append(" '" + Guid.NewGuid().ToString() + "', ");
            SqlWhere.Append("  '" + Convert.ToString(Convert.ToInt32(SaaS_tool.Rows[0]["HS"].ToString()) + 1) + "',  ");
            SqlWhere.Append("  '" + c_name.Value + "',  ");
            SqlWhere.Append("  '0',  ");
            SqlWhere.Append("  '" + c_Remarks.Value + "',  ");
            SqlWhere.Append("  '" + c_PurchasePrice.Value + "',  ");
            SqlWhere.Append("  '" + c_BuyingTime.Value + "',  ");
            SqlWhere.Append("  '" + HttpContext.Current.Session["u_UserParent"].ToString() + "',  ");
            SqlWhere.Append("  '" + DateTime.Now.ToString() + "'  ");

            SqlWhere.Append("  )  ");

            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}