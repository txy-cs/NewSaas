using System;
using System.Collections;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetData;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysUserGroup
{
    public class UserGroup_Form : PageBase
    {
        private WMF_System_IDAO system_idao = new WMF_System_Dal();
        protected HtmlForm form1;
        protected HtmlInputText UserGroup_Name;
        protected HtmlInputText UserGroup_Code;
        protected HtmlSelect ParentId;
        protected HtmlInputText SortCode;
        protected HtmlTextArea UserGroup_Remark;
        protected LinkButton Save;
        private WMF_UserInfo_IDAO user_idao = new WMF_UserInfo_Dal();
        private string _key;
        private string _ParentId;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._key = base.Request["key"];
            this._ParentId = base.Request["ParentId"];
            if (!base.IsPostBack)
            {
                this.InitParentId();
                if (!string.IsNullOrEmpty(this._ParentId))
                {
                    this.ParentId.Value = this._ParentId;
                }
                if (!string.IsNullOrEmpty(this._key))
                {
                    this.InitData();
                }
            }
        }
        private void InitData()
        {
            Hashtable ht = system_idao.GetHashtableById("Base_UserGroup", "UserGroup_ID", this._key);
            if (ht.Count > 0 && ht != null)
            {
                ControlBindHelper.SetWebControls(this.Page, ht);
            }
        }
        private void InitParentId()
        {
            DataTable dt = this.user_idao.InitUserGroupParentId();
            if (!string.IsNullOrEmpty(this._key))
            {
                if (DataTableHelper.IsExistRows(dt))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["UserGroup_ID"].ToString() == this._key)
                        {
                            dt.Rows.RemoveAt(i);
                        }
                    }
                }
            }
            ControlBindHelper.BindHtmlSelect(dt, this.ParentId, "UserGroup_Name", "UserGroup_ID", "用户组信息 - 父节");
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht = ControlBindHelper.GetWebControls(this.Page);
            if (string.IsNullOrEmpty(this.ParentId.Value))
            {
                ht["ParentId"] = "0";
            }
            if (!string.IsNullOrEmpty(this._key))
            {
                ht["ModifyDate"] = DateTime.Now;
                ht["ModifyUserId"] = RequestSession.GetSessionUser().UserId;
                ht["ModifyUserName"] = RequestSession.GetSessionUser().UserName;
            }
            else
            {
                ht["UserGroup_ID"] = CommonHelper.GetGuid;
                ht["CreateUserId"] = RequestSession.GetSessionUser().UserId;
                ht["CreateUserName"] = RequestSession.GetSessionUser().UserName;
            }
            bool IsOk = system_idao.Submit_AddOrEdit("Base_UserGroup", "UserGroup_ID", this._key, ht);
            if (IsOk)
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
