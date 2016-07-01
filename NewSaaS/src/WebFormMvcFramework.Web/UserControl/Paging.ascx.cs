using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.UserControl
{
    public partial class Paging : System.Web.UI.UserControl
    {
        public event EventHandler pageHandler;
        private DataSet TmpDS;
        /// <summary>
        /// SQL语句
        /// </summary>
        public string SqlPaging
        {
            set { Session["SqlPaging"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.pager_PageChanged(sender, e);
            }
        }
        public void pager_PageChanged(object sender, EventArgs e)
        {
            this.pageHandler(sender, e);
            this.PageChecking();
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hlkNext_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblCurrentPageIndex.Text) < Convert.ToInt32(lblPageCount.Text))
            {
                lblCurrentPageIndex.Text = Convert.ToString(Convert.ToInt32(lblCurrentPageIndex.Text) + 1);
                this.pager_PageChanged(sender, e);
                SqlPager();
            }
        }
        /// <summary>
        /// 分页显示权限
        /// </summary>
        public void PageChecking()
        {
            if (Convert.ToInt32(lblPageCount.Text) == 0 || Convert.ToInt32(lblPageCount.Text) == 1)
            {
                this.hlkFirst.Enabled = false;
                this.hlkPrev.Enabled = false;
                this.hlkNext.Enabled = false;
                this.hlkLast.Enabled = false;
                ShowMsgHelper.ShowScript("Script(1)");
            }
            else
            {
                if (Convert.ToInt32(lblCurrentPageIndex.Text) == 1)
                {
                    this.hlkFirst.Enabled = false;
                    this.hlkPrev.Enabled = false;
                    this.hlkNext.Enabled = true;
                    this.hlkLast.Enabled = true;
                    ShowMsgHelper.ShowScript("Script(2)");
                }
                else
                {
                    if (Convert.ToInt32(lblCurrentPageIndex.Text) == Convert.ToInt32(lblPageCount.Text))
                    {
                        this.hlkFirst.Enabled = true;
                        this.hlkPrev.Enabled = true;
                        this.hlkNext.Enabled = false;
                        this.hlkLast.Enabled = false;
                        ShowMsgHelper.ShowScript("Script(3)");
                    }
                    else
                    {
                        this.hlkFirst.Enabled = true;
                        this.hlkPrev.Enabled = true;
                        this.hlkNext.Enabled = true;
                        this.hlkLast.Enabled = true;
                        ShowMsgHelper.ShowScript("Script(4)");
                    }
                }
            }
        }
        /// <summary>
        /// 第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hlkFirst_Click(object sender, EventArgs e)
        {
            lblCurrentPageIndex.Text = "1";
            this.pager_PageChanged(sender, e);
            SqlPager();
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hlkPrev_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(lblCurrentPageIndex.Text) > 0)
            {
                lblCurrentPageIndex.Text = Convert.ToString(Convert.ToInt32(lblCurrentPageIndex.Text) - 1);
                this.pager_PageChanged(sender, e);
                SqlPager();
            }
        }
        /// <summary>
        /// 最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void hlkLast_Click(object sender, EventArgs e)
        {
            lblCurrentPageIndex.Text = Convert.ToString(Convert.ToInt32(lblPageCount.Text));
            this.pager_PageChanged(sender, e);
            SqlPager();
        }
        /// <summary>
        /// 当前页数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlpageList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.pager_PageChanged(sender, e);
            SqlPager();
        }
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <returns>返回添加了分页代码的SQL语句</returns>
        public DataTable SqlPager()
        {
            TmpDS = DataFactory.SqlPager(Session["SqlPaging"].ToString(), Convert.ToInt32(lblCurrentPageIndex.Text), Convert.ToInt32(ddlpageList.Text));

            lblCurrentPageIndex.Text = TmpDS.Tables[1].Rows[0]["当前页"].ToString();
            lblPageCount.Text = TmpDS.Tables[1].Rows[0]["总页数"].ToString();
            lblRecordCount.Text = TmpDS.Tables[2].Rows.Count.ToString();
            if (TmpDS.Tables[2].Rows.Count == 0)
            {
                default_pgStartRecord.Text = "0";
                default_pgEndRecord.Text = "0";
            }
            else
            {
                default_pgStartRecord.Text = "1";
                default_pgEndRecord.Text = TmpDS.Tables[2].Rows.Count.ToString();
            }
            return TmpDS.Tables[2].Copy();
        }
    }
}
//1.当页面里面拖拽这个控件
//2.在Load时间里面编写      Paging.pageHandler += new EventHandler(this.pager_PageChanged);
//3.在查询数据里面    Paging.SqlPaging = SqlStr;
//            rp_Item.DataSource = Paging.SqlPager();
//            rp_Item.DataBind();