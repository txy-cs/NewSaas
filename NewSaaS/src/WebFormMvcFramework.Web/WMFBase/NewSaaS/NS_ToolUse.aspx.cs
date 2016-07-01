using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_ToolUse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                StringBuilder SqlWhere = new StringBuilder();

                SqlWhere.Append("        WITH cte (u_guid, u_UserParent,u_user , u_Name, u_phone, u_IDCardNumber, u_EntryDate, level)      ");

                SqlWhere.Append("     AS(SELECT   u_guid,   ");

                SqlWhere.Append("       u_UserParent,  ");

                SqlWhere.Append("       u_user,  ");

                SqlWhere.Append("       u_Name,   ");

                SqlWhere.Append("         u_phone,   ");

                SqlWhere.Append("       u_IDCardNumber,  ");

                SqlWhere.Append("      u_EntryDate,  ");

                SqlWhere.Append("      1 level    ");

                SqlWhere.Append("       FROM     SaaS_User   ");

                SqlWhere.Append("      WHERE    u_guid = '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' ");

                SqlWhere.Append("       UNION ALL   ");

                SqlWhere.Append("     SELECT   b.u_guid,   ");

                SqlWhere.Append("         b.u_UserParent,   ");

                SqlWhere.Append("      b.u_user,  ");

                SqlWhere.Append("      b.u_Name,  ");

                SqlWhere.Append("   b.u_phone,  ");

                SqlWhere.Append("   b.u_IDCardNumber,  ");

                SqlWhere.Append("    b.u_EntryDate,   ");

                SqlWhere.Append("   level + 1   ");

                SqlWhere.Append("    FROM     SaaS_User b  ");

                SqlWhere.Append("        INNER JOIN cte c ON b.u_UserParent = c.u_guid   ");

                SqlWhere.Append("        )   ");

                SqlWhere.Append("      SELECT  u_guid,   ");

                SqlWhere.Append("      u_UserParent,    ");

                SqlWhere.Append("     u_user,  ");

                SqlWhere.Append("    u_Name,");

                SqlWhere.Append("     u_phone,  ");

                SqlWhere.Append("      u_IDCardNumber,  ");

                SqlWhere.Append("   u_EntryDate,   ");

                SqlWhere.Append("         level  ");

                SqlWhere.Append("     FROM    cte  ");

                SqlWhere.Append("       ORDER BY level;  ");

                c_LeadingPerson.DataValueField = "u_guid";
                c_LeadingPerson.DataTextField = "u_Name";
                c_LeadingPerson.DataSource = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
                c_LeadingPerson.DataBind();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_tool]  ");
            SqlWhere.Append("  SET [c_state] = '1' , c_LeadTime='"+DateTime.Now.ToString()+ "',c_LeadingPerson='"+ c_LeadingPerson .SelectedItem.Value+ "'  ");
            SqlWhere.Append("      WHERE[c_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("领用成功！");
            }
        }
    }
}