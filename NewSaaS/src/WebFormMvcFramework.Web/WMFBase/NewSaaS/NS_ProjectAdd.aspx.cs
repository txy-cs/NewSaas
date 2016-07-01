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
    public partial class NS_ProjectAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_projectType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_projectType").Copy();
                ddl_projectType.DataValueField = "p_guid";
                ddl_projectType.DataTextField = "p_name";
                ddl_projectType.DataSource = SaaS_projectType.Copy();
                ddl_projectType.DataBind();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  INSERT INTO [dbo].[SaaS_project]  ");
            SqlWhere.Append("   ([p_guid]  ");
            SqlWhere.Append("   ,[p_EncodingProject]   ");
            SqlWhere.Append("  ,[p_ProjectName] ");
            SqlWhere.Append(" ,[p_ProjectType] ");
            SqlWhere.Append("  ,[p_workingHours] ");
            SqlWhere.Append("  ,[p_UnitPrice] ");
            SqlWhere.Append("  ,[u_guid] ");
            SqlWhere.Append("  ,[p_CreationTime] ");
            SqlWhere.Append("   ,[p_number] ");
            SqlWhere.Append("  ) ");
            SqlWhere.Append("     VALUES ");
            SqlWhere.Append("  (  ");
            SqlWhere.Append(" '" + Guid.NewGuid().ToString() + "', ");
            SqlWhere.Append("  '" + p_EncodingProject.Value + "',  ");
            SqlWhere.Append("  '" + p_ProjectName.Value + "',  ");
            SqlWhere.Append("  '" + ddl_projectType.SelectedItem.Value + "',  ");
            SqlWhere.Append("  '" + p_workingHours.Value + "',  ");
            SqlWhere.Append("  '" + p_UnitPrice.Value + "',  ");
            SqlWhere.Append("  '" + HttpContext.Current.Session["u_UserParent"].ToString() + "',  ");
            SqlWhere.Append("  '" + DateTime.Now.ToString() + "',  ");
            SqlWhere.Append("  '" + p_number.Value + "'  ");
            SqlWhere.Append("  )  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}