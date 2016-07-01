using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysUser
{
    public partial class UserInfo_Export : PageBase
    {
        private WMF_System_IDAO sys_idao = new WMF_System_Dal();
        private ListItem LT;
        private string SqlStr = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable RoleList = sys_idao.InitRoleList();
                LT = new ListItem();
                LT.Text = "全部角色";
                DropDownList1.Items.Add(LT);
                for (int i = 0; i < RoleList.Rows.Count; i++)
                {
                    LT = new ListItem();
                    LT.Text = RoleList.Rows[i]["Roles_Name"].ToString();
                    LT.Value = RoleList.Rows[i]["Roles_ID"].ToString();
                    DropDownList1.Items.Add(LT);
                }
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Save.Enabled = false;
            Universal_ClassLibrary.File.FileHandle.DeleteFile(Server.MapPath(WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") + "/Temporary/用户数据.csv"));
            Universal_ClassLibrary.File.FileHandle.FileCreate(Server.MapPath(WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") + "/Temporary/用户数据.csv"));
            SqlStr = " SELECT  U.User_Code , ";
            SqlStr += " U.User_Account , ";
            SqlStr += " U.User_Pwd , ";
            SqlStr += " U.User_Name , ";
            SqlStr += " U.User_Sex , ";
            SqlStr += " U.Title , ";
            SqlStr += " U.Email , ";
            SqlStr += " U.Theme , ";
            SqlStr += " U.Question , ";
            SqlStr += " U.AnswerQuestion , ";
            SqlStr += " U.DeleteMark , ";
            SqlStr += " U.User_Remark ";
            SqlStr += " FROM    dbo.Base_UserRole AS R ";
            SqlStr += " LEFT OUTER JOIN dbo.Base_UserInfo AS U ON U.User_ID = R.User_ID ";
            SqlStr += " LEFT OUTER JOIN dbo.Base_StaffOrganize AS S ON S.User_ID = U.User_ID ";
            SqlStr += " LEFT OUTER JOIN dbo.Base_Organization AS O ON O.Organization_ID = S.Organization_ID ";
            if (DropDownList1.SelectedItem.Text != "全部角色")
            {
                SqlStr += " WHERE Roles_ID = '" + DropDownList1.SelectedItem.Value + "'; ";
            }
            DataTable dt_Menu = DataFactory.SqlDataBase().ReturnDataTable(SqlStr.ToString());
            DotNet.Utilities.CsvHelper.dt2csv(dt_Menu.Copy(), Server.MapPath(WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") + "/Temporary/用户数据.csv"), "", "");
            Download("用户数据.csv", Server.MapPath(WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") + "/Temporary/用户数据.csv"));
            Save.Enabled = true;
        }
        /// <summary>
        /// 下载
        /// </summary>
        /// <param name="fileName">保存的名字是什么</param>
        /// <param name="filePath">文件路径</param>
        private void Download(string fileName, string filePath)
        {
            FileStream fs = new FileStream(filePath, FileMode.Open);
            byte[] bytes = new byte[(int)fs.Length]; fs.Read(bytes, 0, bytes.Length);
            fs.Close();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
            Response.BinaryWrite(bytes);
            Response.Flush();
            Response.End();
        }
    }
}