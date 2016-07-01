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
    public partial class NS_SupplierEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_supplier = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_supplier where(s_guid='" + Request.QueryString["Key"].ToString() + "')").Copy();
                s_name.Value = SaaS_supplier.Rows[0]["s_name"].ToString();
                s_contacts.Value = SaaS_supplier.Rows[0]["s_contacts"].ToString();
                s_ContactPhone.Value = SaaS_supplier.Rows[0]["s_ContactPhone"].ToString();
                s_MainBusiness.Value = SaaS_supplier.Rows[0]["s_MainBusiness"].ToString();
                s_address.Value = SaaS_supplier.Rows[0]["s_address"].ToString();
                s_Remarks.Value = SaaS_supplier.Rows[0]["s_Remarks"].ToString();
                s_Phone.Value = SaaS_supplier.Rows[0]["s_Phone"].ToString();
                s_QQ.Value = SaaS_supplier.Rows[0]["s_QQ"].ToString();
                s_number.Value = SaaS_supplier.Rows[0]["s_number"].ToString();
                s_Arrears.Value = SaaS_supplier.Rows[0]["s_Arrears"].ToString();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("         UPDATE[dbo].[SaaS_supplier]    ");
            SqlWhere.Append("         SET   ");
            SqlWhere.Append("        [s_name] ='"+ s_name .Value+ "'    ");
            SqlWhere.Append("         ,[s_contacts] = '"+ s_contacts .Value+ "'    ");
            SqlWhere.Append("            ,[s_ContactPhone] ='"+ s_ContactPhone .Value+ "'     ");
            SqlWhere.Append("         ,[s_MainBusiness] = '"+ s_MainBusiness .Value+ "'  ");
            SqlWhere.Append("        ,[s_address] = '"+ s_address .Value+ "'     ");
            SqlWhere.Append("          ,[s_Remarks] = '"+ s_Remarks .Value+ "'     ");
            SqlWhere.Append("           ,[s_Phone] ='"+ s_Phone .Value+ "' ");
            SqlWhere.Append("           ,[s_QQ] = '"+ s_QQ .Value+ "'   ");
            SqlWhere.Append("       ,[s_number] = '"+ s_number .Value+ "'    ");
            SqlWhere.Append("         ,[s_Arrears] = '"+ s_Arrears .Value+ "'    ");
            SqlWhere.Append("      WHERE [s_guid] = '" + Request.QueryString["Key"].ToString() + "';  ");

            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}