using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_PaymentsTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_PaymentsType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_PaymentsType where(p_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                p_number.Value = SaaS_PaymentsType.Rows[0]["p_number"].ToString();
                p_name.Value = SaaS_PaymentsType.Rows[0]["p_name"].ToString();
                p_Remarks.Value = SaaS_PaymentsType.Rows[0]["p_Remarks"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_PaymentsType]  ");
            SqlWhere.Append("  SET [p_number] = '" + p_number.Value + "' ,p_name='" + p_name.Value + "',p_Remarks='" + p_Remarks.Value + "'   ");
            SqlWhere.Append("      WHERE [p_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}