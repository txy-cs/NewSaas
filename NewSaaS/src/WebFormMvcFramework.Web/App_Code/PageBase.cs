using System;
using WebFormMvcFramework.Common.DotNetBean;

namespace WebFormMvcFramework.Web.App_Code
{
    public partial class PageBase : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            //if (RequestSession.GetSessionUser() == null)
            //{
            //    this.Session.Abandon();
            //    this.Session.Clear();
            //    base.Response.Redirect("~/Index.htm");
            //}
            //base.OnLoad(e);
        }
    }
}