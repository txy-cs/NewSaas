﻿using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_BalancePaymentsList : System.Web.UI.Page
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

            SqlWhere.Append(" select * from View_BalancePayments where(u_guid='" + HttpContext.Current.Session["u_UserParent"].ToString() + "' and b_abstract like '%" + u_select.Value + "%') ");

            DataTable SaaS_businessType = DataFactory.SqlDataBase().ReturnDataTable(SqlWhere.ToString()).Copy();
            Session["SaaS_businessType"] = SaaS_businessType.Copy();
            rp_Item.DataSource = SaaS_businessType.Copy();
            rp_Item.DataBind();
        }
        protected void lbtUserSel_Click(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        protected void lbtUserDel_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append(" delete from SaaS_BalancePayments where(b_guid='" + hf_b_guid.Value + "') ");
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