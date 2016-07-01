using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_projectType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_projectType").Copy();
                DataRow dr = SaaS_projectType.NewRow();
                dr["p_guid"] = "00000000-0000-0000-0000-000000000000";
                dr["p_name"] = "请选择....";
                SaaS_projectType.Rows.Add(dr);
                ddl_projectType.DataValueField = "p_guid";
                ddl_projectType.DataTextField = "p_name";
                ddl_projectType.DataSource = SaaS_projectType.Copy();
                ddl_projectType.DataBind();
                ddl_projectType.SelectedValue = "00000000-0000-0000-0000-000000000000";
                this.DataBindGrid();
            }
        }
        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" select * from View_Project where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and p_ProjectName like '%" + u_select.Value + "%'  ");
            if (ddl_projectType.SelectedItem.Value!= "00000000-0000-0000-0000-000000000000")
            {
                SqlWhere.Append(" and p_ProjectType='"+ddl_projectType.SelectedItem.Value+"'  ");
            }
            SqlWhere.Append("  ) ");

            DataTable SaaS_businessType = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            rp_Item.DataSource = SaaS_businessType.Copy();
            rp_Item.DataBind();
        }
        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" delete from SaaS_project where(p_guid='" + hf_p_guid.Value + "') ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.Alert("删除成功！");
                DataBindGrid();
            }
        }
    }
}