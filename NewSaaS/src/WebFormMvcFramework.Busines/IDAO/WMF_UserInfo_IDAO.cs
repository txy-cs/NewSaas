using System.Data;
using System.Text;

namespace WebFormMvcFramework.Busines.IDAO
{
    public interface WMF_UserInfo_IDAO
    {

        DataTable UserLogin(string name, string pwd);

        DataTable GetUserInfoInfo(StringBuilder SqlWhere);

        DataTable InitUserRight(string User_ID);

        DataTable InitUserInfoUserGroup(string User_ID);

        DataTable InitUserRole(string User_ID);

        DataTable InitStaffOrganize(string User_ID);

        DataTable Load_StaffOrganizeList();

        DataTable GetOrganizeList();

        DataTable InitUserGroupList();

        DataTable InitUserGroupParentId();

        DataTable Load_UserInfoUserGroupList(string UserGroup_ID);

        DataTable InitUserGroupRight(string UserGroup_ID);

        bool AddUserGroupMenber(string[] User_ID, string UserGroup_ID);

        bool Add_UserGroupAllotAuthority(string[] pkVal, string UserGroup_ID);
    }
}