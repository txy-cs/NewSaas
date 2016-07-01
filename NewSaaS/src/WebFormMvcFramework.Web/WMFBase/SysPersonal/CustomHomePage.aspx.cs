using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;
using WebFormMvcFramework.Busines;
using System.Web.UI;

namespace WebFormMvcFramework.Web.WMFBase.SysPersonal
{
    public partial class CustomHomePage : Page
    {
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable CustomHomePage = DataFactory.SqlDataBase().ReturnDataTable("select * from Base_UserInfo where User_Account='" + RequestSession.GetSessionUser().UserAccount + "'").Copy();
                if (CustomHomePage.Rows.Count > 0)
                {
                    content1.Value = CustomHomePage.Rows[0]["CustomHomePage"].ToString();
                }
                else
                {
                    content1.Value = "";
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            List<SqlParameter> SqlList = new List<SqlParameter>();
            SqlStr = " UPDATE  dbo.Base_UserInfo ";
            SqlStr += " SET     CustomHomePage = @CustomHomePage ";
            SqlStr += " WHERE   User_Account = @User_Account; ";
            SqlParameter param;
            param = new SqlParameter();
            param.DbType = DbType.String;
            param.Value = Request.Form["content1"];
            param.ParameterName = "@CustomHomePage";
            param.Direction = ParameterDirection.Input; //输入参数
            SqlList.Add(param);
            param = new SqlParameter();
            param.DbType = DbType.String;
            param.Value = RequestSession.GetSessionUser().UserAccount;
            param.ParameterName = "@User_Account";
            param.Direction = ParameterDirection.Input; //输入参数
            SqlList.Add(param);
            Maticsoft.DBUtility.DbHelperSQL.connectionString = WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("SqlServer_WMF_DB");
            Maticsoft.DBUtility.DbHelperSQL.ExecuteSql(SqlStr, SqlList.ToArray());
            ShowMsgHelper.ShowScript("MainSwitch()");
        }
    }
}