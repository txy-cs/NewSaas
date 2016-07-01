using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_SettlementMethodEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_businessType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_SettlementMethod where(s_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                s_number.Value = SaaS_businessType.Rows[0]["s_number"].ToString();
                s_name.Value = SaaS_businessType.Rows[0]["s_name"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_SettlementMethod]  ");
            SqlWhere.Append("  SET [s_number] = '" + s_number.Value + "' ,s_name='" + s_name.Value + "'   ");
            SqlWhere.Append("      WHERE [s_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}