using System;
using System.Web.UI.HtmlControls;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysPersonal
{
    public class Individuation_Set : PageBase
    {
        protected HtmlSelect Menu_Type;
        protected HtmlSelect PageIndex;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.Menu_Type.Value = CookieHelper.GetCookie("Menu_Type");
                this.PageIndex.Value = CookieHelper.GetCookie("PageIndex");
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            CookieHelper.WriteCookie("Menu_Type", this.Menu_Type.Value, 30);
            CookieHelper.WriteCookie("PageIndex", this.PageIndex.Value, 30);
            ShowMsgHelper.ShowScript("MainSwitch()");
        }
    }
}