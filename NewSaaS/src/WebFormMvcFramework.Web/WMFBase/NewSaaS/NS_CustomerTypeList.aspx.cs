using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_CustomerTypeList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.DataBindGrid();
            }
        }
        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();

            SqlWhere.Append(" select * from SaaS_CustomerType where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and c_name like '%" + u_select.Value + "%') ");

            DataTable SaaS_CustomerType = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            rp_Item.DataSource = SaaS_CustomerType.Copy();
            rp_Item.DataBind();
        }
        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" delete from SaaS_CustomerType where(c_guid='" + hf_c_guid.Value + "') ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.Alert("删除成功！");
                DataBindGrid();
            }
        }
    }
}