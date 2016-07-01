using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysUser
{
    public partial class UserInfo_Import : PageBase
    {
        private WMF_System_IDAO sys_idao = new WMF_System_Dal();
        private ListItem LT;
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable RoleList = sys_idao.InitRoleList();
                for (int i = 0; i < RoleList.Rows.Count; i++)
                {
                    LT = new ListItem();
                    LT.Text = RoleList.Rows[i]["Roles_Name"].ToString();
                    LT.Value = RoleList.Rows[i]["Roles_ID"].ToString();
                    ddl_Role.Items.Add(LT);
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Save.Enabled = false;
            if (FileUpload1.HasFile == true)
            {
                string strErr = "";
                //获取上传文件的大小
                int filesize = FileUpload1.PostedFile.ContentLength;
                if (filesize > 1024 * 1024)
                {
                    strErr = "文件太大了，系统不允许上传文件超过1MB\n";
                }
                if (strErr == "")
                {   //获取服务器当前路径
                    string path = Server.MapPath("~");
                    string FileUrl = path + "\\Temporary\\" + Guid.NewGuid() + ".csv";
                    //把上传文件放到服务器的upload文件夹下
                    FileUpload1.PostedFile.SaveAs(FileUrl);
                    DataTable dt = DotNet.Utilities.CsvHelper.csv2dt(FileUrl, 0);
                    ArrayList ListSql = new ArrayList();
                    if (ddl_ImportMode.SelectedItem.Text == "清空")
                    {
                        ListSql.Clear();
                        SqlStr = " delete from Base_UserInfo ";
                        ListSql.Add(SqlStr);
                        SqlStr = " delete from Base_UserRole ";
                        ListSql.Add(SqlStr);
                        DataFactory.SqlDataBase().SqlBatch(ListSql);
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (ddl_ImportMode.SelectedItem.Text == "覆盖")
                        {
                            string user_id = DataFactory.SqlDataBase().ReturnDataTable("select User_ID from Base_UserInfo where(User_Code='" + dt.Rows[i]["User_Code"].ToString() + "')").Rows[0]["User_ID"].ToString();
                            SqlStr = " delete from Base_UserInfo where(User_Code='" + dt.Rows[i]["User_Code"].ToString() + "') ";
                            ListSql.Add(SqlStr);
                            SqlStr = " delete from Base_UserRole where(user_id='" + user_id + "') ";
                            ListSql.Add(SqlStr);
                            DataFactory.SqlDataBase().SqlBatch(ListSql);
                        }
                        if (ddl_ImportMode.SelectedItem.Text == "跳过")
                        {
                            if (DataFactory.SqlDataBase().ReturnDataTable("select User_ID from Base_UserInfo where(User_Code='" + dt.Rows[i]["User_Code"].ToString() + "')").Rows.Count > 0)
                            {
                                continue;
                            }
                        }
                        ListSql.Clear();
                        string UserID = Guid.NewGuid().ToString();
                        SqlStr = " INSERT INTO [dbo].[Base_UserInfo] ";
                        SqlStr += " ([User_ID] ";
                        SqlStr += " ,[User_Code] ";
                        SqlStr += " ,[User_Account] ";
                        SqlStr += " ,[User_Pwd] ";
                        SqlStr += " ,[User_Name] ";
                        SqlStr += " ,[User_Sex] ";
                        SqlStr += " ,[Title] ";
                        SqlStr += " ,[Email] ";
                        SqlStr += " ,[Theme] ";
                        SqlStr += " ,[Question] ";
                        SqlStr += " ,[AnswerQuestion] ";
                        SqlStr += " ,[DeleteMark] ";
                        SqlStr += " ,[CreateDate] ";
                        SqlStr += " ,[CreateUserId] ";
                        SqlStr += " ,[CreateUserName] ";
                        SqlStr += " ,[ModifyDate] ";
                        SqlStr += " ,[ModifyUserId] ";
                        SqlStr += " ,[ModifyUserName] ";
                        SqlStr += " ,[User_Remark]) ";
                        SqlStr += " VALUES ";
                        SqlStr += " ( ";
                        SqlStr += " '" + UserID + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Code"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Account"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Pwd"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Name"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Sex"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["Title"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["Email"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["Theme"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["Question"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["AnswerQuestion"].ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["DeleteMark"].ToString() + "', ";
                        SqlStr += " '" + DateTime.Now.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserId.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserName.ToString() + "', ";
                        SqlStr += " '" + DateTime.Now.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserId.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserName.ToString() + "', ";
                        SqlStr += " '" + dt.Rows[i]["User_Remark"].ToString() + "' ";
                        SqlStr += " ) ";
                        ListSql.Add(SqlStr);

                        string UserRole_ID = Guid.NewGuid().ToString();
                        SqlStr = " INSERT INTO [dbo].[Base_UserRole] ";
                        SqlStr += " ([UserRole_ID] ";
                        SqlStr += " ,[User_ID] ";
                        SqlStr += " ,[Roles_ID] ";
                        SqlStr += " ,[CreateDate] ";
                        SqlStr += " ,[CreateUserId] ";
                        SqlStr += " ,[CreateUserName]) ";
                        SqlStr += " VALUES ";
                        SqlStr += " ( ";
                        SqlStr += " '" + UserRole_ID + "', ";
                        SqlStr += " '" + UserID + "', ";
                        SqlStr += " '" + ddl_Role.SelectedItem.Value + "', ";
                        SqlStr += " '" + DateTime.Now.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserId.ToString() + "', ";
                        SqlStr += " '" + RequestSession.GetSessionUser().UserName.ToString() + "' ";
                        SqlStr += " ) ";
                        ListSql.Add(SqlStr);
                        DataFactory.SqlDataBase().SqlBatch(ListSql);
                    }
                    Universal_ClassLibrary.File.FileHandle.DeleteFile(FileUrl);
                    ShowMsgHelper.AlertMsg("用户导入成功！");
                }
            }
            else
            {
                ShowMsgHelper.ShowScript("back();showWarningMsg('请指定上传文件！');");
            }

            Save.Enabled = true;
        }
    }
}