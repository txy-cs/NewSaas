using System;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysMail
{
    public partial class left : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            Page.RegisterStartupScript("center", "<script language='javascript'>window.open('WriteLetters.aspx','center')</script>");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Page.RegisterStartupScript("center", "<script language='javascript'>window.open('recipient.aspx','center')</script>");
        }

        protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.TreeView1.SelectedNode != null)
            {
                string s = this.TreeView1.SelectedNode.Value.Trim();
                switch (s)
                {
                    case "收件箱":
                        //Page.RegisterStartupScript("center", "<script language='javascript'>window.open('recipient.aspx','center','',true)</script>");
                        Page.RegisterStartupScript("center", "<script language='javascript'>window.parent.document.getElementById('center').src='recipient.aspx';</script>");
                        break;
                    case "已发送":
                        //Page.RegisterStartupScript("center", "<script language='javascript'>window.open('Sent.aspx','center','',true)</script>");
                        Page.RegisterStartupScript("center", "<script language='javascript'>window.parent.document.getElementById('center').src='Sent.aspx';</script>");
                        break;
                    case "已删除":
                        //Page.RegisterStartupScript("center", "<script language='javascript'>window.open('Deleted.aspx','center','',true)</script>");
                        Page.RegisterStartupScript("center", "<script language='javascript'>window.parent.document.getElementById('center').src='Deleted.aspx';</script>");
                        break;
                }
            }
        }
    }
}