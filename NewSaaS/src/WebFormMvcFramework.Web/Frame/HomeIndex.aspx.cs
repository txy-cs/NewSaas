using System;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.Frame
{
    public partial class HomeIndex : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = DataFactory.SqlDataBase().ReturnDataTable("select * from Base_UserInfo where User_Account='" + RequestSession.GetSessionUser().UserAccount + "'").Rows[0]["CustomHomePage"].ToString();
        }
    }
}