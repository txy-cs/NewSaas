using System;
using System.Timers;
using System.Web;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetConfig;

namespace WebFormMvcFramework.Web
{
    public class Global : HttpApplication
    {
        private void Application_Start(object sender, EventArgs e)
        {
            base.Application.Lock();
            base.Application["CurrentUsers"] = 0;
            base.Application.UnLock();
            Timer myTimer = new Timer(60000.0);
            myTimer.Elapsed += new ElapsedEventHandler(this.OnTimedEvent);
            myTimer.Interval = 1000.0;
            myTimer.Enabled = true;
        }
        private void Application_Error(object sender, EventArgs e)
        {
            //Exception objErr = base.Server.GetLastError().GetBaseException();
            //string error = objErr.Message ?? "";
            //base.Server.ClearError();
            //base.Application["error"] = error;
            //base.Response.Redirect(WebFormMvcFramework.Common.DotNetConfig.ConfigHelper.GetAppSettings("VirtualDirectory") + "Error/ErrorPage.aspx");
        }
        private void Session_Start(object sender, EventArgs e)
        {
            base.Application.Lock();
            base.Application["CurrentUsers"] = (int)base.Application["CurrentUsers"] + 1;
            base.Application.UnLock();
        }
        private void Session_End(object sender, EventArgs e)
        {
            base.Application.Lock();
            base.Application["CurrentUsers"] = (int)base.Application["CurrentUsers"] - 1;
            base.Application.UnLock();
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {

        }
    }
}