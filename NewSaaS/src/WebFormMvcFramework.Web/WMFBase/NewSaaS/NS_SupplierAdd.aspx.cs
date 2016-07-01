using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_SupplierAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("        INSERT INTO[dbo].[SaaS_supplier]    ");
            SqlWhere.Append("            ([s_guid]    ");
            SqlWhere.Append("              ,[s_name]    ");
            SqlWhere.Append("           ,[s_contacts]   ");
            SqlWhere.Append("         ,[s_ContactPhone]   ");
            SqlWhere.Append("          ,[s_MainBusiness]   ");
            SqlWhere.Append("             ,[s_address]    ");
            SqlWhere.Append("             ,[s_Remarks]   ");
            SqlWhere.Append("           ,[s_Phone]   ");
            SqlWhere.Append("           ,[s_QQ]   ");
            SqlWhere.Append("          ,[u_guid]   ");
            SqlWhere.Append("          ,[s_CreationTime]    ");
            SqlWhere.Append("          ,[s_number]    ");
            SqlWhere.Append("          ,[s_Arrears])    ");
            SqlWhere.Append("        VALUES    ");
            SqlWhere.Append("        ('" + Guid.NewGuid().ToString() + "'    ");
            SqlWhere.Append("            ,'"+ s_name .Value+ "'   ");
            SqlWhere.Append("          ,'"+ s_contacts .Value+ "'   ");
            SqlWhere.Append("            ,'"+ s_ContactPhone .Value+ "'    ");
            SqlWhere.Append("         ,'"+ s_MainBusiness .Value+ "'    ");
            SqlWhere.Append("         ,'"+ s_address .Value+ "'    ");
            SqlWhere.Append("            ,'"+ s_Remarks .Value+ "'   ");
            SqlWhere.Append("            ,'"+ s_Phone .Value+ "'    ");
            SqlWhere.Append("            ,'"+ s_QQ .Value+ "'  ");
            SqlWhere.Append("             , '" + HttpContext.Current.Session["u_UserParent"].ToString() + "'    ");
            SqlWhere.Append("            , '" + DateTime.Now.ToString() + "'     ");
            SqlWhere.Append("          ,'"+ s_number .Value+ "'     ");
            SqlWhere.Append("           ,'"+ s_Arrears .Value+ "')     ");

            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}