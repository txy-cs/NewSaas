using System;
using System.Text;
using System.Web;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }

        private void DataBindGrid()
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

            SqlWhere.Append("      WHERE    u_guid = '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and (u_user like '%" + u_select.Value + "%' or u_Name like '%" + u_select.Value + "%') ");

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

            SqlWhere.Append("   WHERE(u_user LIKE '%" + u_select.Value + "%'  ");

            SqlWhere.Append("      OR u_Name LIKE '%" + u_select.Value + "%'   ");

            SqlWhere.Append("      )   ");

            SqlWhere.Append("       ORDER BY level;  ");

            rp_Item.DataSource = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            rp_Item.DataBind();
        }

        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            if (DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_User where(u_guid='" + hf_U_Guid.Value + "')").Rows[0]["u_UserParent"].ToString() != "")
            {
                StringBuilder SqlWhere = new StringBuilder();
                SqlWhere.Append("  UPDATE[dbo].[SaaS_User]  ");
                SqlWhere.Append("  SET [u_pwd] = '' , u_user=''  ");
                SqlWhere.Append("      WHERE[u_guid] = '" + hf_U_Guid.Value + "';  ");
                if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
                {
                    ShowMsgHelper.Alert("删除帐号成功！");
                    DataBindGrid();
                }
            }
            else
            {
                ShowMsgHelper.Alert_Error("删除帐号失败！");
            }
        }
    }
}