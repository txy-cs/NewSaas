using System.Collections;
using System.Data;
using System.Text;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetEncrypt;

namespace WebFormMvcFramework.Busines.DAL
{
    public class WMF_UserInfo_Dal : WMF_UserInfo_IDAO
    {

        public DataTable Load_StaffOrganizeList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  Organization_ID , ";
            strSql += " Organization_Name , ";
            strSql += " ParentId , ";
            strSql += " '0' AS isUser ";
            strSql += " FROM    Base_Organization ";
            strSql += " UNION ALL ";
            strSql += " SELECT  U.User_ID AS Organization_ID , ";
            strSql += " U.User_Code + '|' + U.User_Name AS User_Name , ";
            strSql += " S.Organization_ID , ";
            strSql += " '1' AS isUser ";
            strSql += " FROM    Base_UserInfo U ";
            strSql += " RIGHT JOIN Base_StaffOrganize S ON U.User_ID = S.User_ID ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable GetOrganizeList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  * ";
            strSql += " FROM    Base_Organization ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " ORDER BY SortCode ASC ";
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()),Universal_ClassLibrary.SizeWriting.Upper);
        }

        public DataTable UserLogin(string name, string pwd)
        {
            string strSql = string.Empty;
            strSql = " SELECT  User_ID , ";
            strSql += " User_Account , ";
            strSql += " User_Pwd , ";
            strSql += " User_Name , ";
            strSql += " DeleteMark ";
            strSql += " FROM    Base_UserInfo ";
            strSql += " WHERE   User_Account = '" + name + "' ";
            strSql += " AND User_Pwd = '" + Md5Helper.MD5(pwd, 32) + "' ";
            strSql += " AND DeleteMark != 0 ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }
     
        public DataTable GetUserInfoInfo(StringBuilder SqlWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * from Base_UserInfo where DeleteMark !=0");
            strSql.Append(SqlWhere);
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy(), Universal_ClassLibrary.SizeWriting.Upper).Copy();
        }

        public DataTable InitUserRight(string User_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  Menu_Id ";
            strSql += " FROM    Base_UserRight ";
            strSql += " WHERE   User_ID = '" + User_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy();
        }

        public DataTable InitUserInfoUserGroup(string User_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  UserGroup_ID ";
            strSql += " FROM    Base_UserInfoUserGroup ";
            strSql += " WHERE   User_ID = '" + User_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy();
        }

        public DataTable InitUserRole(string User_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  Roles_ID ";
            strSql += " FROM    Base_UserRole ";
            strSql += " WHERE   User_ID = '" + User_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy();
        }

        public DataTable InitStaffOrganize(string User_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  Organization_ID ";
            strSql += " FROM    Base_StaffOrganize ";
            strSql += " WHERE   User_ID = '" + User_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()).Copy();
        }

        public DataTable InitUserGroupList()
        {
            string strSql = string.Empty;
            strSql += " SELECT  * ";
            strSql += " FROM    Base_UserGroup ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " ORDER BY SortCode ASC ";
            return Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString()),Universal_ClassLibrary.SizeWriting.Upper).Copy();
        }

        public DataTable InitUserGroupParentId()
        {
            string strSql = string.Empty;
            strSql += " SELECT  UserGroup_ID , ";
            strSql += " UserGroup_Name + ' - ' + CASE ParentId ";
            strSql += " WHEN '0' THEN '父节' ";
            strSql += " ELSE '子节' ";
            strSql += " END AS UserGroup_Name ";
            strSql += " FROM    Base_UserGroup ";
            strSql += " WHERE   DeleteMark = 1 ";
            strSql += " ORDER BY SortCode ASC ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable Load_UserInfoUserGroupList(string UserGroup_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  UserInfoUserGroup_ID , ";
            strSql += " U.User_Name + '|' + U.User_Code AS User_Name , ";
            strSql += " U.User_Account , ";
            strSql += " U.User_Sex , ";
            strSql += " U.Title , ";
            strSql += " U.DeleteMark , ";
            strSql += " U.User_Remark ";
            strSql += " FROM    Base_UserInfo U ";
            strSql += " RIGHT JOIN Base_UserInfoUserGroup G ON G.User_ID = U.User_ID ";
            strSql += " WHERE   G.UserGroup_ID = '" + UserGroup_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public DataTable InitUserGroupRight(string UserGroup_ID)
        {
            string strSql = string.Empty;
            strSql += " SELECT  Menu_Id ";
            strSql += " FROM    Base_UserGroupRight ";
            strSql += " WHERE   UserGroup_ID = '" + UserGroup_ID + "' ";
            return DataFactory.SqlDataBase().ReturnDataTable(strSql.ToString());
        }

        public bool AddUserGroupMenber(string[] User_ID, string UserGroup_ID)
        {
            bool result;
            try
            {
                ArrayList sqls = new ArrayList();
                for (int i = 0; i < User_ID.Length; i++)
                {
                    string item = User_ID[i];
                    if (item.Length > 0)
                    {
                        StringBuilder sbadd = new StringBuilder();
                        sbadd.Append("Insert into Base_UserInfoUserGroup(");
                        sbadd.Append("UserInfoUserGroup_ID,User_ID,UserGroup_ID,CreateUserId,CreateUserName");
                        sbadd.Append(")Values(");
                        sbadd.Append("'" + CommonHelper.GetGuid + "','" + item + "','" + UserGroup_ID + "','" + RequestSession.GetSessionUser().UserId + "','" + RequestSession.GetSessionUser().UserName + "')");
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

        public bool Add_UserGroupAllotAuthority(string[] pkVal, string UserGroup_ID)
        {
            bool result;
            try
            {
                ArrayList sqls = new ArrayList();
                StringBuilder sbDelete = new StringBuilder();
                sbDelete.Append("Delete From Base_UserGroupRight Where UserGroup_ID ='" + UserGroup_ID + "'");
                sqls.Add(sbDelete.ToString());
                for (int i = 0; i < pkVal.Length; i++)
                {
                    string item = pkVal[i];
                    if (item.Length > 0)
                    {
                        StringBuilder sbadd = new StringBuilder();
                        sbadd.Append("Insert into Base_UserGroupRight(");
                        sbadd.Append("UserGroupRight_ID,UserGroup_ID,Menu_Id,CreateUserId,CreateUserName");
                        sbadd.Append(")Values(");
                        sbadd.Append("'" + CommonHelper.GetGuid + "','" + UserGroup_ID + "','" + item + "','" + RequestSession.GetSessionUser().UserId + "','" + RequestSession.GetSessionUser().UserName + "')");
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
    }
}