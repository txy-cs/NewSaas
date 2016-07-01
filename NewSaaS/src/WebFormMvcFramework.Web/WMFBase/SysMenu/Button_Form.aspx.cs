using System;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysMenu
{
    public class Button_Form : PageBase
    {
        private WMF_System_IDAO system_idao = new WMF_System_Dal();
        protected HtmlForm form1;
        protected HtmlInputText Button_Name;
        protected HtmlInputText Button_Title;
        protected HtmlSelect Button_Type;
        protected HtmlInputHidden Button_Img;
        protected HtmlImage Img_Button_Img;
        protected HtmlInputText SortCode;
        protected HtmlTextArea Button_Code;
        protected HtmlTextArea Button_Remak;
        protected LinkButton Save;
        private string _key;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._key = base.Request["key"];
            if (!base.IsPostBack)
            {
                if (!string.IsNullOrEmpty(this._key))
                {
                    this.InitData();
                }
            }
        }
        private void InitData()
        {
            Hashtable ht = system_idao.GetHashtableById("Base_Button", "Button_ID", this._key);
            if (ht.Count > 0 && ht != null)
            {
                ControlBindHelper.SetWebControls(this.Page, ht);
                if (!string.IsNullOrEmpty(ht["BUTTON_IMG"].ToString()))
                {
                    this.Img_Button_Img.Src = "../../Themes/Images/16/" + ht["BUTTON_IMG"].ToString();
                }
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            Hashtable ht = new Hashtable();
            ht = ControlBindHelper.GetWebControls(this.Page);
            if (!string.IsNullOrEmpty(this._key))
            {
                ht["ModifyDate"] = DateTime.Now;
                ht["ModifyUserId"] = RequestSession.GetSessionUser().UserId;
                ht["ModifyUserName"] = RequestSession.GetSessionUser().UserName;
            }
            else
            {
                ht["Button_ID"] = CommonHelper.GetGuid;
                ht["CreateUserId"] = RequestSession.GetSessionUser().UserId;
                ht["CreateUserName"] = RequestSession.GetSessionUser().UserName;
            }
            bool IsOk = system_idao.Submit_AddOrEdit("Base_Button", "Button_ID", this._key, ht);
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
