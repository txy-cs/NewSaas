using System.Collections;
using System.Data;

namespace WebFormMvcFramework.Busines.IDAO
{
    public interface WMF_System_IDAO
    {
        DataTable GetMenu(string Roles_ID);
        DataTable GetMenuHtml(string UserId);

        int DeleteData_Base(string tableName, string pkName, string[] pkVal);

        DataTable GetMenuBind();

        DataTable GetMenuList();

        DataTable GetSysMenuByButton(string Menu_Id);

        DataTable GetButtonList();

        int AllotButton(string pkVal, string ParentId);

        DataTable GetButtonHtml(string User_ID);

        DataTable InitRoleList();

        DataTable InitRoleParentId();

        bool Add_RoleAllotMember(string[] pkVal, string Roles_ID);

        DataTable InitRoleRight(string Roles_ID);

        DataTable InitUserRole(string Roles_ID);

        bool Add_RoleAllotAuthority(string[] pkVal, string Roles_ID);

        int Virtualdelete(string module, string tableName, string pkName, string[] pkVal);

        bool Submit_AddOrEdit(string tableName, string pkName, string pkVal, Hashtable ht);

        Hashtable GetHashtableById(string tableName, string pkName, string pkVal);

        int IsExist(string tableName, string pkName, string pkVal);

        int InsertByHashtable(string tableName, Hashtable ht);

        int UpdateByHashtable(string tableName, string pkName, string pkVal, Hashtable ht);

        void SysLoginLog(string SYS_USER_ACCOUNT, string SYS_LOGINLOG_STATUS, string OWNER_address);

        void SysAbnormalLog(string User_Account, string SYS_Abnorma_Information);
    }
}