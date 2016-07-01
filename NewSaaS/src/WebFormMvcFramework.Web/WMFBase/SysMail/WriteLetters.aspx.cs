using System;
using System.Data;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetBean;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;

namespace WebFormMvcFramework.Web.WMFBase.SysMail
{
    public partial class WriteLetters : PageBase
    {
        private WMF_Mail_IDAO user_mail = new WMF_Mail_Dal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = DataFactory.DBSQL().Query("select * from Base_Organization").Tables[0].Copy();
                object[] str = dt.Rows[0].ItemArray;
                BindTree(tv_Department.Nodes[0].ChildNodes, dt, str[dt.Columns["Organization_ID"].Ordinal].ToString());
            }
        }
        public void BindTree(TreeNodeCollection Nds, DataTable dt, string id)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = "ParentId = '" + id.ToString() + "'";
            TreeNode node;
            TreeNode UserNode;
            foreach (DataRowView drv in dv)
            {
                node = new TreeNode();
                node.Text = drv["Organization_Name"].ToString();
                node.Value = "";
                string SQLSTR = "         SELECT  dbo.Base_UserInfo.User_ID ,";
                SQLSTR += "   dbo.Base_UserInfo.User_Account , ";
                SQLSTR += "   dbo.Base_UserInfo.User_Name ";
                SQLSTR += " FROM    dbo.Base_UserInfo ";
                SQLSTR += "     INNER JOIN dbo.Base_StaffOrganize ON dbo.Base_UserInfo.User_ID = dbo.Base_StaffOrganize.User_ID ";
                SQLSTR += " WHERE   ( Organization_ID = '" + drv["Organization_ID"].ToString() + "' );";
                DataTable UserDT = DataFactory.DBSQL().Query(SQLSTR).Tables[0].Copy();
                for (int i = 0; i < UserDT.Rows.Count; i++)
                {
                    UserNode = new TreeNode();
                    UserNode.Value = UserDT.Rows[i]["User_Account"].ToString();
                    UserNode.Text = UserDT.Rows[i]["User_Name"].ToString();
                    node.ChildNodes.Add(UserNode);
                }
                node.CollapseAll();
                Nds.Add(node);
                BindTree(node.ChildNodes, dt, drv["Organization_ID"].ToString());
            }
        }
        protected void but_SendOut_Click(object sender, EventArgs e)
        {
            but_SendOut.Enabled = false;
            user_mail.SendOutMail(Guid.NewGuid().ToString(), RequestSession.GetSessionUser().UserId.ToString(), RequestSession.GetSessionUser().UserAccount.ToString(), Text1.Value, Request.Form["content1"], txt_Addressee.Text);
            ShowMsgHelper.Alert("邮件发送成功！");
            but_SendOut.Enabled = true;
        }
        protected void tv_Department_SelectedNodeChanged(object sender, EventArgs e)
        {
            if (this.tv_Department.SelectedNode != null)
            {
                string User_ID = this.tv_Department.SelectedNode.Value.Trim();
                if (User_ID != "")
                {
                    txt_Addressee.Text += User_ID + ";";
                }
            }
        }
    }
}