using System;
using System.Web.UI.HtmlControls;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.Frame
{
    public class MainSwitch : PageBase
    {
        protected HtmlForm form1;

        protected void Page_Load(object sender, EventArgs e)
        {
            string Menu_Type = CookieHelper.GetCookie("Menu_Type");
            if (Menu_Type == "0")
            {
                base.Response.Redirect("../Frame/MainDefault.aspx");
            }
            else
            {
                if (Menu_Type == "1")
                {
                    base.Response.Redirect("../Frame/MainDefault.aspx");
                }
                else
                {
                    if (Menu_Type == "2")
                    {
                        base.Response.Redirect("../Frame/MainIndex.aspx");
                    }
                    else
                    {
                        if (Menu_Type == "3")
                        {
                            base.Response.Redirect("../Frame/MainTree.aspx");
                        }
                        else
                        {
                            base.Response.Redirect("../Frame/MainDefault.aspx");
                        }
                    }
                }
            }
        }
    }
}