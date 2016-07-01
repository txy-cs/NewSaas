using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.Error
{
    public partial class ErrorPage : PageBase
    {
        protected HtmlForm form1;
        protected Label Label1;
        private WMF_System_IDAO sys_idao = new WMF_System_Dal();
        protected void Page_Load(object sender, EventArgs e)
        {
            //sys_idao.SysAbnormalLog(RequestSession.GetSessionUser().UserAccount.ToString(), base.Application["error"].ToString());
            this.Label1.Text = base.Application["error"].ToString();
        }
    }
}