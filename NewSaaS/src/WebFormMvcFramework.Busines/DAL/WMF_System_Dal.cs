using System;
using System.Collections;
using System.Data;
using System.Text;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetData;

namespace WebFormMvcFramework.Busines.DAL
{
    public class WMF_System_Dal : WMF_System_IDAO
    {
        public DataTable GetMenu(string Roles_ID)
        {
                      string strSql = string.Empty;
            strSql = "select * from [dbo].[View_RolesMenu] where(Roles_ID='"+ Roles_ID + "')";
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy(), Universal_ClassLibrary.SizeWriting.Upper).Copy();
        }
        public DataTable GetMenuHtml(string UserId)
        {
            string strSql = string.Empty;
            strSql += " SELECT  M.Menu_Id , ";
            strSql += " M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode ";
            strSql += " FROM    ( SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " '角色权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_RoleRight R_R ON R_R.Menu_Id = M.Menu_Id ";
            strSql += " LEFT JOIN Base_UserRole U_R ON U_R.Roles_ID = R_R.Roles_ID ";
            strSql += " WHERE     M.TARGET = 'Iframe' ";
            strSql += " AND U_R.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " UNION ALL ";
            strSql += " SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " '用户组权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_UserGroupRight U_R ON U_R.Menu_Id = M.Menu_Id ";
            strSql += " LEFT JOIN Base_UserInfoUserGroup U_G ON U_G.UserGroup_ID = U_R.UserGroup_ID ";
            strSql += " WHERE     M.TARGET = 'Iframe' ";
            strSql += " AND U_G.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " UNION ALL ";
            strSql += " SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " '用户权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_UserRight U_R ON U_R.Menu_Id = M.Menu_Id ";
            strSql += " WHERE     M.TARGET = 'Iframe' ";
            strSql += " AND U_R.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " ) M ";
            strSql += " GROUP BY M.Menu_Id , ";
            strSql += " M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode ";
            strSql += " ORDER BY M.SortCode ";


            //strSql = "select * from [dbo].[View_RolesMenu] where(Roles_ID='c70d20db-341e-4b7a-aef4-0f998ad5bbb3')";
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy(), Universal_ClassLibrary.SizeWriting.Upper).Copy();
        }

        public int DeleteData_Base(string tableName, string pkName, string[] pkVal)
        {
            int index = 0;
            string str = string.Empty;
            StringBuilder sql = new StringBuilder(string.Concat(new string[]
                {
                    "DELETE FROM ",
                    tableName,
                    " WHERE ",
                    pkName,
                    " IN ("
                }));
            for (int i = 0; i < pkVal.Length - 1; i++)
            {
                object obj2 = pkVal[i];
                str = "'" + obj2 + "'";
                sql.Append(str).Append(",");
                index++;
            }
            str = "'" + pkVal[index] + "'";
            sql.Append(str);
            sql.Append(")");
            return DataFactory.SqlDataBase().Affected(sql.ToString());
        }

        public DataTable GetMenuBind()
        {
            string strSql = string.Empty;
            strSql += " SELECT  * ";
            strSql += " FROM    Base_SysMenu ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " ORDER BY SortCode ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable GetMenuList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  Menu_Id , ";
            strSql += " Menu_Name , ";
            strSql += " Menu_Img , ";
            strSql += " Menu_Type , ";
            strSql += " TARGET , ";
            strSql += " ParentId , ";
            strSql += " CAST(Menu_Type AS VARCHAR(10)) + '-' + CAST(SortCode AS VARCHAR(10)) AS Sort , ";
            strSql += " NavigateUrl , ";
            strSql += " CreateUserName , ";
            strSql += " CreateDate , ";
            strSql += " ModifyUserName , ";
            strSql += " ModifyDate ";
            strSql += " FROM    Base_SysMenu ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " AND Menu_Type != 3 ";
            strSql += " ORDER BY SortCode ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable GetButtonList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  * ";
            strSql += " FROM    Base_Button ";
            strSql += " WHERE   DELETEMARK = 1 ";
            strSql += " ORDER BY SORTCODE ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable GetSysMenuByButton(string Menu_Id)
        {
            string strSql = string.Empty;
            strSql += " SELECT  * ";
            strSql += " FROM    Base_SysMenu ";
            strSql += " WHERE   ParentId = '" + Menu_Id + "' ";
            strSql += " AND DELETEMARK = 1 ";
            strSql += " AND Menu_Type = 3 ";
            strSql += " ORDER BY SORTCODE ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }
   
        public int AllotButton(string pkVal, string ParentId)
        {
            int result;
            try
            {
                DataTable dt_Button = this.GetButtonList();
                DataTable Newdt_Button = DataTableHelper.GetNewDataTable(dt_Button, "Button_ID = '" + pkVal + "'");
                string Button_Name = Newdt_Button.Rows[0]["Button_Name"].ToString();
                string Button_Title = Newdt_Button.Rows[0]["Button_Title"].ToString();
                string Button_Img = Newdt_Button.Rows[0]["Button_Img"].ToString();
                string Button_Code = Newdt_Button.Rows[0]["Button_Code"].ToString();
                Hashtable ht = new Hashtable();
                ht["Menu_Id"] = CommonHelper.GetGuid;
                ht["ParentId"] = ParentId;
                ht["Menu_Name"] = Button_Name;
                ht["Menu_Title"] = Button_Title;
                ht["Menu_Img"] = Button_Img;
                ht["Menu_Type"] = 3;
                ht["NavigateUrl"] = Button_Code;
                ht["SortCode"] = CommonHelper.GetInt(new StringBuilder("SELECT MAX(SortCode) FROM Base_SysMenu WHERE ParentId = '" + ParentId + "' AND DELETEMARK = 1 AND Menu_Type = 3")) + 1;
                ht["Target"] = "Onclick";
                ht["CreateUserId"] = RequestSession.GetSessionUser().UserId;
                ht["CreateUserName"] = RequestSession.GetSessionUser().UserName;
                result = InsertByHashtable("Base_SysMenu", ht);
            }
            catch (Exception)
            {
                result = -1;
            }
            return result;
        }
       
        public DataTable GetButtonHtml(string UserId)
        {
            string URL = RequestHelper.GetScriptName;
            string strSql = string.Empty;
            strSql += " SELECT  M.Menu_Id , ";
            strSql += " M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " M.Menu_Type ";
            strSql += " FROM    ( SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " M.Menu_Type , ";
            strSql += " '角色权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_RoleRight R_R ON R_R.Menu_Id = M.Menu_Id ";
            strSql += " LEFT JOIN Base_UserRole U_R ON U_R.Roles_ID = R_R.Roles_ID ";
            strSql += " WHERE     U_R.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " UNION ALL ";
            strSql += " SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " M.Menu_Type , ";
            strSql += " '用户组权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_UserGroupRight U_R ON U_R.Menu_Id = M.Menu_Id ";
            strSql += " LEFT JOIN Base_UserInfoUserGroup U_G ON U_G.UserGroup_ID = U_R.UserGroup_ID ";
            strSql += " WHERE     U_G.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " UNION ALL ";
            strSql += " SELECT    M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.Menu_Id , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " M.Menu_Type , ";
            strSql += " '用户权限' AS TheirTYPE ";
            strSql += " FROM      Base_SysMenu M ";
            strSql += " LEFT JOIN Base_UserRight U_R ON U_R.Menu_Id = M.Menu_Id ";
            strSql += " WHERE     U_R.User_ID = '" + UserId + "' ";
            strSql += " AND M.DeleteMark = 1 ";
            strSql += " ) M ";
            strSql += " GROUP BY M.Menu_Id , ";
            strSql += " M.Menu_Name , ";
            strSql += " M.Menu_Title , ";
            strSql += " M.Menu_Img , ";
            strSql += " M.TARGET , ";
            strSql += " M.ParentId , ";
            strSql += " M.NavigateUrl , ";
            strSql += " M.SortCode , ";
            strSql += " M.Menu_Type ";
            strSql += " ORDER BY M.SortCode ";
            DataTable dt_Menu =Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()),Universal_ClassLibrary.SizeWriting.Upper);
            return DataTableHelper.GetNewDataTable(dt_Menu, "ParentId='" + this.GetMenuByNavigateUrl(URL, dt_Menu) + "' AND Menu_Type = 3");
        }

        public string GetMenuByNavigateUrl(string NavigateUrl, DataTable dt_Menu)
        {
            string result;
            try
            {
                DataTable dt = DataTableHelper.GetNewDataTable(dt_Menu, "NavigateUrl='" + NavigateUrl + "'");
                result = dt.Rows[0]["Menu_Id"].ToString();
            }
            catch
            {
                result = "";
            }
            return result;
        }

     
     
        public DataTable InitRoleList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  Roles_ID , ";
            strSql += " ParentId , ";
            strSql += " Roles_Name , ";
            strSql += " Roles_Remark , ";
            strSql += " SortCode , ";
            strSql += " DeleteMark , ";
            strSql += " CreateDate , ";
            strSql += " CreateUserName , ";
            strSql += " ModifyDate , ";
            strSql += " ModifyUserName ";
            strSql += " FROM    Base_Roles ";
            strSql += " WHERE   DeleteMark != 0 ";
            strSql += " ORDER BY SortCode ASC ";
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()),Universal_ClassLibrary.SizeWriting.Upper);
        }
       
        public DataTable InitRoleParentId()
        {
            string strSql = string.Empty;
            strSql += " SELECT  Roles_ID , ";
            strSql += " Roles_Name + ' - ' + CASE ParentId ";
            strSql += " WHEN '0' THEN '父节' ";
            strSql += " ELSE '子节' ";
            strSql += " END AS Roles_Name ";
            strSql += " FROM    Base_Roles ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " ORDER BY SortCode ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable InitUserRole(string Roles_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  R.User_ID , ";
            strSql += " U.User_Code + '|' + U.User_Name AS User_Name , ";
            strSql += " O.Organization_Name ";
            strSql += " FROM    Base_UserRole R ";
            strSql += " LEFT JOIN Base_UserInfo U ON U.User_ID = R.User_ID ";
            strSql += " LEFT JOIN Base_StaffOrganize S ON S.User_ID = U.User_ID ";
            strSql += " LEFT JOIN Base_Organization O ON O.Organization_ID = S.Organization_ID ";
            strSql += " WHERE   Roles_ID = '" + Roles_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable InitRoleRight(string Roles_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  Menu_Id ";
            strSql += " FROM    Base_RoleRight ";
            strSql += " WHERE   Roles_ID = '" + Roles_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public bool Add_RoleAllotMember(string[] pkVal, string Roles_ID)
        {
            bool result;
            try
            {
                ArrayList sqls = new ArrayList();
                StringBuilder sbDelete = new StringBuilder();
                sbDelete.Append("Delete From Base_UserRole Where Roles_ID ='" + Roles_ID + "'");
                sqls.Add(sbDelete.ToString());
                for (int i = 0; i < pkVal.Length; i++)
                {
                    string item = pkVal[i];
                    if (item.Length > 0)
                    {
                        StringBuilder sbadd = new StringBuilder();
                        sbadd.Append("Insert into Base_UserRole(");
                        sbadd.Append("UserRole_ID,User_ID,Roles_ID,CreateUserId,CreateUserName");
                        sbadd.Append(")Values(");
                        sbadd.Append("'" + CommonHelper.GetGuid + "','" + item + "','" + Roles_ID + "','" + RequestSession.GetSessionUser().UserId + "','" + RequestSession.GetSessionUser().UserName + "')");
                        sqls.Add(sbadd.ToString());
                    }
                }
                result = DataFactory.SqlDataBase().SqlBatch(sqls);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public bool Add_RoleAllotAuthority(string[] pkVal, string Roles_ID)
        {
            bool result;
            try
            {
                ArrayList sqls = new ArrayList();
                StringBuilder sbDelete = new StringBuilder();
                sbDelete.Append("Delete From Base_RoleRight Where Roles_ID ='" + Roles_ID + "'");
                sqls.Add(sbDelete.ToString());
                for (int i = 0; i < pkVal.Length; i++)
                {
                    string item = pkVal[i];
                    if (item.Length > 0)
                    {
                        StringBuilder sbadd = new StringBuilder();
                        sbadd.Append("Insert into Base_RoleRight(");
                        sbadd.Append("RoleRight_ID,Roles_ID,Menu_Id,CreateUserId,CreateUserName");
                        sbadd.Append(")Values(");
                        sbadd.Append("'" + CommonHelper.GetGuid + "','" + Roles_ID + "','" + item + "','" + RequestSession.GetSessionUser().UserId + "','" + RequestSession.GetSessionUser().UserName + "')");
                        sqls.Add(sbadd.ToString());
                    }
                }
                result = DataFactory.SqlDataBase().SqlBatch(sqls);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public int Virtualdelete(string module, string tableName, string pkName, string[] pkVal)
        {
            int result;
            try
            {
                ArrayList sqls = new ArrayList();
                for (int i = 0; i < pkVal.Length; i++)
                {
                    string item = pkVal[i];
                    StringBuilder sbEdit = new StringBuilder();
                    sbEdit.Append(" Update ");
                    sbEdit.Append(tableName);
                    sbEdit.Append(" Set DeleteMark = 0");
                    sbEdit.Append(" Where ").Append(pkName).Append("=").Append("'" + item + "'");
                    sqls.Add(sbEdit.ToString());
                }
                if (DataFactory.SqlDataBase().SqlBatch(sqls))
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            catch
            {
                result = 0;
            }
            return result;
        }
        public bool Submit_AddOrEdit(string tableName, string pkName, string pkVal, Hashtable ht)
        {
            bool result;
            if (string.IsNullOrEmpty(pkVal))
            {
                result = (this.InsertByHashtable(tableName, ht) > 0);
            }
            else
            {
                result = (this.UpdateByHashtable(tableName, pkName, pkVal, ht) > 0);
            }
            return result;
        }

        public Hashtable GetHashtableById(string tableName, string pkName, string pkVal)
        {
            string Sql = " select * from " + tableName + " where " + pkName + "='" + pkVal + "' ";
            return DataTableHelper.DataTableToHashtable(DataFactory.SqlDataBase().ReturnDataTable(Sql).Copy());
        }

        public int IsExist(string tableName, string pkName, string pkVal)
        {
            string Sql = " select count(1) from " + tableName + " where " + pkName + "='" + pkVal + "'";
            return CommonHelper.GetInt(DataFactory.SqlDataBase().ReturnDataTable(Sql).Rows[0].ToString());
        }

        public int InsertByHashtable(string tableName, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Insert Into ");
            sb.Append(tableName);
            sb.Append("(");
            StringBuilder sp = new StringBuilder();
            StringBuilder sb_prame = new StringBuilder();
            foreach (string key in ht.Keys)
            {
                sb_prame.Append("," + key);
            }
            foreach (var Value in ht.Values)
            {
                sp.Append(",'" + Value+"'");
            }
            sb.Append(sb_prame.ToString().Substring(1, sb_prame.ToString().Length - 1) + ") Values (");
            sb.Append(sp.ToString().Substring(1, sp.ToString().Length - 1) + ")");
            return DataFactory.SqlDataBase().Affected(sb.ToString());
        }

        public int UpdateByHashtable(string tableName, string pkName, string pkVal, Hashtable ht)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" Update ");
            sb.Append(tableName);
            sb.Append(" Set ");
            bool isFirstValue = false;
            foreach (DictionaryEntry de in ht)
            {
                if (isFirstValue==true)
                {
                    sb.Append(",");
                }
                sb.Append(de.Key);
                sb.Append("=");
                sb.Append("'");
                sb.Append(de.Value);
                sb.Append("'");
                isFirstValue = true;
            }
            
            sb.Append(" Where ").Append(pkName).Append("=").Append("'" + pkVal+"'");
            return DataFactory.SqlDataBase().Affected(sb.ToString());
        }
        public void SysLoginLog(string SYS_USER_ACCOUNT, string SYS_LOGINLOG_STATUS, string OWNER_address)
        {
            Hashtable ht = new Hashtable();
            ht["SYS_LOGINLOG_ID"] = CommonHelper.GetGuid;
            ht["User_Account"] = SYS_USER_ACCOUNT;
            ht["SYS_LOGINLOG_IP"] = RequestHelper.GetIP();
            ht["OWNER_address"] = OWNER_address;
            ht["SYS_LOGINLOG_STATUS"] = SYS_LOGINLOG_STATUS;
            InsertByHashtable("Base_SysLoginlog", ht);
        }
        public void SysAbnormalLog(string User_Account, string SYS_Abnorma_Information)
        {
            Hashtable ht = new Hashtable();
            ht["SYS_AbnormaLog_ID"] = CommonHelper.GetGuid;
            ht["User_Account"] = User_Account;
            ht["SYS_Abnorma_Information"] = SYS_Abnorma_Information;
            InsertByHashtable("Base_SysAbnormalLog", ht);
        }
    }
}