using System;
using System.Data;
using System.Text;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_StaffEdit : System.Web.UI.Page
    {
        private string Str_u_guid = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Str_u_guid = Request.QueryString["Key"].ToString();
                DataTable SaaS_User = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_User where(u_guid='" + Str_u_guid + "')").Copy();
                              u_phone.Value = SaaS_User.Rows[0]["u_phone"].ToString();
                u_IDCardNumber.Value = SaaS_User.Rows[0]["u_IDCardNumber"].ToString();
                u_Birthday.Value = SaaS_User.Rows[0]["u_Birthday"].ToString();
                u_Remarks.Value = SaaS_User.Rows[0]["u_Remarks"].ToString();
                u_Name.Value = SaaS_User.Rows[0]["u_Name"].ToString();
                           u_BasePay.Value = SaaS_User.Rows[0]["u_BasePay"].ToString();
                u_EntryDate.Value = SaaS_User.Rows[0]["u_EntryDate"].ToString();
                switch (SaaS_User.Rows[0]["u_sex"].ToString())
                {
                    case "0":
                        u_sex.SelectedIndex = 0;
                        break;
                    case "1":
                        u_sex.SelectedIndex = 1;
                        break;
                }
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("  UPDATE[dbo].[SaaS_User]  ");
            SqlWhere.Append("  set    [u_Name] = '" + u_Name.Value + "' ,  ");
            SqlWhere.Append("    [u_phone] = '" + u_phone.Value + "' ,  ");
            SqlWhere.Append("      [u_IDCardNumber] = '" + u_IDCardNumber.Value + "' ,  ");
            SqlWhere.Append("       [u_sex] = '" + u_sex.Items[u_sex.SelectedIndex].Value + "' ,   ");
            SqlWhere.Append("       [u_Birthday] = '" + u_Birthday.Value + "' , ");
            SqlWhere.Append("       [u_BasePay] = '" + u_BasePay.Value + "' ,  ");
            SqlWhere.Append("         [u_EntryDate] = '" + u_EntryDate.Value + "' ,   ");
            SqlWhere.Append("       [u_Remarks] = '" + u_Remarks.Value + "'  ");
            SqlWhere.Append("      WHERE[u_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}