using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_BalancePaymentsAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
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
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();

            SqlWhere.Append("       INSERT INTO[dbo].[SaaS_BalancePayments]    ");
            SqlWhere.Append("        ([b_guid]  ");
            SqlWhere.Append("        ,[p_guid]  ");
            SqlWhere.Append("         ,[b_income]  ");
            SqlWhere.Append("      ,[b_expenditure]   ");
            SqlWhere.Append("       ,[b_PaymentDate]  ");
            SqlWhere.Append("      ,[b_HandlingPersonnel]   ");
            SqlWhere.Append("       ,[s_guid]   ");
            SqlWhere.Append("           ,[b_abstract]  ");
            SqlWhere.Append("       ,[u_guid]  ");
            SqlWhere.Append("         ,[b_CreationTime]   ");
            SqlWhere.Append("         ,[b_number])   ");

            SqlWhere.Append("      VALUES   ");
            SqlWhere.Append("      ('" + Guid.NewGuid().ToString() + "'   ");
            SqlWhere.Append("       ,'" + p_guid.SelectedItem.Value + "'   ");
            SqlWhere.Append("           ,'" + b_income.Value + "'    ");
            SqlWhere.Append("            ,'" + b_expenditure.Value + "'    ");
            SqlWhere.Append("        ,'" + b_PaymentDate.Value + "'  ");
            SqlWhere.Append("       ,'" + b_HandlingPersonnel.SelectedItem.Value + "'   ");
            SqlWhere.Append("         ,'" + s_guid.SelectedItem.Value + "'   ");
            SqlWhere.Append("         ,'" + b_abstract.Value + "'   ");
            SqlWhere.Append("          ,'" + HttpContext.Current.Session["u_UserParent"].ToString() + "'   ");
            SqlWhere.Append("          ,'" + DateTime.Now.ToString() + "'  ");
            SqlWhere.Append("          ,'" + b_number.Value + "')   ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}