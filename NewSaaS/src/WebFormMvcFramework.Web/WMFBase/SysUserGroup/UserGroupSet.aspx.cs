using System;
using System.Web.UI.HtmlControls;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysUserGroup
{
    public class UserGroupSet : PageBase
    {
        protected HtmlForm form1;
        protected HtmlSelect Searchwhere;
        protected HtmlInputText txt_Search;
        public string _UserGroup_ID;
        public string _UserGroup_Name;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._UserGroup_ID = base.Request["UserGroup_ID"];
            this._UserGroup_Name = base.Server.UrlDecode(base.Request["UserGroup_Name"]);
        }
    }
}
