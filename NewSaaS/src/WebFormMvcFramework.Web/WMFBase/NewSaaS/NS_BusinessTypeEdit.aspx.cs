using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_BusinessTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_businessType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_businessType where(b_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                b_number.Value = SaaS_businessType.Rows[0]["b_number"].ToString();
                b_name.Value = SaaS_businessType.Rows[0]["b_name"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_businessType]  ");
            SqlWhere.Append("  SET [b_number] = '" + b_number.Value + "' ,b_name='" + b_name.Value + "'   ");
            SqlWhere.Append("      WHERE [b_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}