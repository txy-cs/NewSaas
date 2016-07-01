using System;
using System.Data;
using System.Text;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysMail
{
    public partial class Deleted : PageBase
    {
        private WMF_Mail_IDAO user_mail = new WMF_Mail_Dal();
        protected void Page_Load(object sender, EventArgs e)
        {
            Paging1.pageHandler += new EventHandler(this.pager_PageChanged);
        }

        private void pager_PageChanged(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }

        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" select * from Base_Mail ");
            SqlWhere.Append("  where(Mail_User_Account='" + RequestSession.GetSessionUser().UserAccount.ToString() + "' and Mail_DeleteMark=0)  ");
            SqlWhere.Append(" ORDER BY Mail_CreateTime DESC ");
            Paging1.SqlPaging = SqlWhere.ToString();
            DataTable TB = Paging1.SqlPager().Copy();

            TB.TableName = "Table";
            rp_Item.DataSource = TB.Copy();
            DataBind();
        }

        protected void lbut_Completelydelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HF_KEY.Value.Split(',').Length; i++)
            {
                user_mail.CompletelyDeleteMail(HF_KEY.Value.Split(',')[i]);
            }
            this.DataBindGrid();
            ShowMsgHelper.Alert("邮件销毁成功！");
        }

        protected void lbut_Recovery_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < HF_KEY.Value.Split(',').Length; i++)
            {
                user_mail.RecoveryMail(HF_KEY.Value.Split(',')[i]);
            }
            this.DataBindGrid();
            ShowMsgHelper.Alert("邮件恢复成功！");
        }
    }
}