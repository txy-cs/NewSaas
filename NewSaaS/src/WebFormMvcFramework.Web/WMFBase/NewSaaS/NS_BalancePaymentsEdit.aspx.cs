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
    public partial class NS_BalancePaymentsEdit : System.Web.UI.Page
    {
        private string Str_u_guid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Str_u_guid = Request.QueryString["Key"].ToString();
                DataTable SaaS_PaymentsType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_PaymentsType where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "')").Copy();
                p_guid.DataValueField = "p_guid";
                p_guid.DataTextField = "p_name";
                p_guid.DataSource = SaaS_PaymentsType.Copy();
                p_guid.DataBind();


                DataTable SaaS_SettlementMethod = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_SettlementMethod where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "')").Copy();
                s_guid.DataValueField = "s_guid";
                s_guid.DataTextField = "s_name";
                s_guid.DataSource = SaaS_SettlementMethod.Copy();
                s_guid.DataBind();



                StringBuilder SqlWhere = new StringBuilder();

                SqlWhere.Append("        WITH cte (u_guid, u_UserParent,u_user , u_Name, u_phone, u_IDCardNumber, u_EntryDate, level)      ");

                SqlWhere.Append("     AS(SELECT   u_guid,   ");

                SqlWhere.Append("       u_UserParent,  ");

                SqlWhere.Append("       u_user,  ");

                SqlWhere.Append("       u_Name,   ");

                SqlWhere.Append("         u_phone,   ");

                SqlWhere.Append("       u_IDCardNumber,  ");

                SqlWhere.Append("      u_EntryDate,  ");

                SqlWhere.Append("      1 level    ");

                SqlWhere.Append("       FROM     SaaS_User   ");

                SqlWhere.Append("      WHERE    u_guid = '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' ");

                SqlWhere.Append("       UNION ALL   ");

                SqlWhere.Append("     SELECT   b.u_guid,   ");

                SqlWhere.Append("         b.u_UserParent,   ");

                SqlWhere.Append("      b.u_user,  ");

                SqlWhere.Append("      b.u_Name,  ");

                SqlWhere.Append("   b.u_phone,  ");

                SqlWhere.Append("   b.u_IDCardNumber,  ");

                SqlWhere.Append("    b.u_EntryDate,   ");

                SqlWhere.Append("   level + 1   ");

                SqlWhere.Append("    FROM     SaaS_User b  ");

                SqlWhere.Append("        INNER JOIN cte c ON b.u_UserParent = c.u_guid   ");

                SqlWhere.Append("        )   ");

                SqlWhere.Append("      SELECT  u_guid,   ");

                SqlWhere.Append("      u_UserParent,    ");

                SqlWhere.Append("     u_user,  ");

                SqlWhere.Append("    u_Name,");

                SqlWhere.Append("     u_phone,  ");

                SqlWhere.Append("      u_IDCardNumber,  ");

                SqlWhere.Append("   u_EntryDate,   ");

                SqlWhere.Append("         level  ");

                SqlWhere.Append("     FROM    cte  ");

                SqlWhere.Append("       ORDER BY level;  ");

                b_HandlingPersonnel.DataValueField = "u_guid";
                b_HandlingPersonnel.DataTextField = "u_Name";
                b_HandlingPersonnel.DataSource = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
                b_HandlingPersonnel.DataBind();

                DataTable View_BalancePayments = DataFactory.SqlDataBase().ReturnDataTable("select * from View_BalancePayments where(b_guid='" + Str_u_guid + "')").Copy();
                b_number.Value = View_BalancePayments.Rows[0]["b_number"].ToString();
                p_guid.SelectedValue = View_BalancePayments.Rows[0]["p_guid"].ToString();
                b_expenditure.Value = View_BalancePayments.Rows[0]["b_expenditure"].ToString();
                b_income.Value = View_BalancePayments.Rows[0]["b_income"].ToString();
                b_PaymentDate.Value = View_BalancePayments.Rows[0]["b_PaymentDate"].ToString();
                b_HandlingPersonnel.SelectedValue = View_BalancePayments.Rows[0]["b_HandlingPersonnel"].ToString();
                s_guid.SelectedValue = View_BalancePayments.Rows[0]["s_guid"].ToString();
                b_abstract.Value = View_BalancePayments.Rows[0]["b_abstract"].ToString();
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("         UPDATE[dbo].[SaaS_BalancePayments]   ");
            SqlWhere.Append("       SET     ");
            SqlWhere.Append("            [p_guid] = '" + p_guid.SelectedItem.Value + "'    ");
            SqlWhere.Append("       ,[b_income] = '" + b_income.Value + "'    ");
            SqlWhere.Append("     ,[b_expenditure] = '" + b_expenditure.Value + "'  ");
            SqlWhere.Append("        ,[b_PaymentDate] = '" + b_PaymentDate.Value + "'  ");
            SqlWhere.Append("     ,[b_HandlingPersonnel] = '" + b_HandlingPersonnel.SelectedItem.Value + "'  ");
            SqlWhere.Append("   ,[s_guid] = '" + s_guid.SelectedItem.Value + "' ");
            SqlWhere.Append("         ,[b_abstract] = '" + b_abstract.Value + "'   ");
            SqlWhere.Append("       ,[b_number] ='" + b_number.Value + "'  ");
            SqlWhere.Append("      WHERE b_guid='" + Request.QueryString["Key"].ToString() + "'  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("编辑成功！");
            }
        }
    }
}