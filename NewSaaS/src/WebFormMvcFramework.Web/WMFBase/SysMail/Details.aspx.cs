using System;
using System.Data;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysMail
{
    public partial class Details : PageBase
    {
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string Mail_Guid = Request.QueryString["Mail_Guid"].ToString();
                SqlStr = " UPDATE dbo.Base_Mail SET Mail_ReadState=0 WHERE(Mail_Guid='" + Mail_Guid + "') ";
                if (DataFactory.DBSQL().ExecuteSql(SqlStr) > 0)
                {
                    SqlStr = " select * from Base_Mail WHere(Mail_Guid='" + Mail_Guid + "') ";
                    DataTable UserDT = DataFactory.DBSQL().Query(SqlStr).Tables[0].Copy();
                    Label2.Text = UserDT.Rows[0]["Mail_MR_UserAccount"].ToString();
                    Label3.Text = UserDT.Rows[0]["Mail_CreateTime"].ToString();
                    Label4.Text = UserDT.Rows[0]["Mail_User_Account"].ToString();
                    Label1.Text = UserDT.Rows[0]["Mail_Text"].ToString();
                    Label5.Text = UserDT.Rows[0]["Mail_Name"].ToString();
                }
            }
        }
    }
}