using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_CustomerTypeEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_CustomerType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_CustomerType where(c_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                c_number.Value = SaaS_CustomerType.Rows[0]["c_number"].ToString();
                c_name.Value = SaaS_CustomerType.Rows[0]["c_name"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_CustomerType]  ");
            SqlWhere.Append("  SET [c_number] = '" + c_number.Value + "' ,c_name='"+ c_name .Value+ "'   ");
            SqlWhere.Append("      WHERE [c_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}