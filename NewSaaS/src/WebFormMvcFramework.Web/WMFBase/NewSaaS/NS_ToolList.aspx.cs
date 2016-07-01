using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_ToolList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DataBindGrid();
            }
        }

        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();

            SqlWhere.Append("     SELECT * ,   ");

            SqlWhere.Append("    CASE WHEN (c_state = '0') THEN '在库'  ");

            SqlWhere.Append("     WHEN(c_state = '1') THEN '不在库'   ");

            SqlWhere.Append("    END AS c_StateName   ");

            SqlWhere.Append("     FROM[View_Tool]  ");

            SqlWhere.Append("     where(u_guid = '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and c_name like '%" + u_select.Value + "%')  ");

            DataTable View_SaaS_tool = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            rp_Item.DataSource = View_SaaS_tool.Copy();
            rp_Item.DataBind();
        }

        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" delete from SaaS_tool where(c_guid='" + hf_c_guid.Value + "') ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.Alert("删除成功！");
                DataBindGrid();
            }
        }

        protected void lbtReturn_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_tool]  ");
            SqlWhere.Append("  SET [c_state] = '0' , c_LeadTime='',c_LeadingPerson=NULL  ");
            SqlWhere.Append("      WHERE[c_guid] = '" + hf_c_guid.Value + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.Alert("归还成功！");
                DataBindGrid();
            }
        }
    }
}