using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;
using WebFormMvcFramework.Web.UserControl;

namespace WebFormMvcFramework.Web.WMFBase.SysMenu
{
    public class Button_List : PageBase
    {
        private WMF_System_IDAO systemidao = new WMF_System_Dal();
        protected HtmlHead Head1;
        protected HtmlForm form1;
        protected LoadButton LoadButton1;
        protected Repeater rp_Item;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.InitData();
            }
        }
        private void InitData()
        {
            DataTable dt = this.systemidao.GetButtonList();
            ControlBindHelper.BindRepeaterList(dt, this.rp_Item);
        }
    }
}