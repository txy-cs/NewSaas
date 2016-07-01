using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_ProjectEdit : System.Web.UI.Page
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


                DataTable SaaS_project = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_project where(p_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                p_number.Value = SaaS_project.Rows[0]["p_number"].ToString();
                p_EncodingProject.Value = SaaS_project.Rows[0]["p_EncodingProject"].ToString();
                p_ProjectName.Value = SaaS_project.Rows[0]["p_ProjectName"].ToString();
                p_workingHours.Value = SaaS_project.Rows[0]["p_workingHours"].ToString();
                p_UnitPrice.Value = SaaS_project.Rows[0]["p_UnitPrice"].ToString();
                ddl_projectType.SelectedValue = SaaS_project.Rows[0]["p_ProjectType"].ToString();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("         UPDATE[dbo].[SaaS_project]  ");
            SqlWhere.Append("        SET   ");
            SqlWhere.Append("    [p_ProjectName] = '" + p_ProjectName.Value + "'   ");
            SqlWhere.Append("     ,[p_EncodingProject] ='" + p_EncodingProject.Value + "'  ");
            SqlWhere.Append("    ,[p_workingHours] = '" + p_workingHours.Value + "'  ");
            SqlWhere.Append("    ,[p_UnitPrice] = '" + p_UnitPrice.Value + "'  ");
            SqlWhere.Append("    ,[p_ProjectType] = '" + ddl_projectType.SelectedItem.Value + "'  ");
            SqlWhere.Append("    ,[p_number] = '" + p_number.Value + "' ");
            SqlWhere.Append("    WHERE p_guid='" + Request.QueryString["Key"].ToString() + "'   ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}