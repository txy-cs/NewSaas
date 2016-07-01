using System;
using System.Web;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_StaffAdd : System.Web.UI.Page
    {
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Save_Click(object sender, EventArgs e)
        {
            SqlStr = " INSERT INTO [dbo].[SaaS_User] ";
            SqlStr += " ([u_guid] ";
            SqlStr += " ,[u_UserParent] ";
            SqlStr += " ,[u_Name] ";
            SqlStr += " ,[u_phone] ";
            SqlStr += " ,[u_IDCardNumber] ";
            SqlStr += " ,[u_sex] ";
            SqlStr += " ,[u_Birthday] ";
            SqlStr += " ,[u_BasePay] ";
            SqlStr += " ,[u_EntryDate] ";
            SqlStr += " ,[u_Remarks] ";
            SqlStr += " ,[u_CreationTime] ";
            SqlStr += " ,[u_Type]) ";
            SqlStr += " VALUES ";
            SqlStr += " ( ";
            SqlStr += " '" + Guid.NewGuid().ToString() + "', ";
            SqlStr += " '" + HttpContext.Current.Session["u_UserParent"].ToString() + "', ";
            SqlStr += " '" + u_Name.Value + "', ";
            SqlStr += " '" + u_phone.Value + "', ";
            SqlStr += " '" + u_IDCardNumber.Value + "', ";
            SqlStr += " '" + u_sex.Items[u_sex.SelectedIndex].Value + "', ";
            SqlStr += " '" + u_Birthday.Value + "', ";
            SqlStr += " '" + u_BasePay.Value + "', ";
            SqlStr += " '" + u_EntryDate.Value + "', ";
            SqlStr += " '" + u_Remarks.Value + "', ";
            SqlStr += " '" + DateTime.Now.ToString() + "', ";
            SqlStr += " '0' ";
            SqlStr += " ) ";

            if (DataFactory.SqlDataBase().Affected(SqlStr) > 0)
            {
                ShowMsgHelper.AlertMsg("操作成功！");
            }
            else
            {
                ShowMsgHelper.Alert_Error("操作失败！");
            }
        }
    }
}