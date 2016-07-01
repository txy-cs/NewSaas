using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_WarehouseList : System.Web.UI.Page
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

            SqlWhere.Append(" select * from SaaS_Warehouse where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and w_CommodityName like '%" + u_select.Value + "%') ");

            DataTable SaaS_Warehouse = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            //Session["SaaS_Warehouse"] = SaaS_Warehouse.Copy();
            SaaS_Warehouse = Universal_ClassLibrary.DataTable.DataTableAddSequence.GetDataTable(SaaS_Warehouse.Copy(), "w_number").Copy();
            rp_Item.DataSource = SaaS_Warehouse.Copy();
            rp_Item.DataBind();
        }

        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" delete from SaaS_Warehouse where(w_guid='" + hf_w_guid.Value + "') ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.Alert("删除成功！");
                DataBindGrid();
            }
        }

        protected void lbtExport_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel.numberformat:@";
            this.EnableViewState = false;
            Response.Charset = "UTF-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");//设置输出流为简体中文  
            Response.AppendHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls");
            Response.Write(printHid.Value);
            Response.End();
        }
    }
}