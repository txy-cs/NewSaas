using System;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Web.App_Code;
using WebFormMvcFramework.Web.UserControl;

namespace WebFormMvcFramework.Web.WMFBase.SysLog
{
    public class AbnormalList : PageBase
    {
        protected HtmlForm form1;
        protected HtmlInputText txt_Search;
        protected HtmlInputText BeginBuilTime;
        protected HtmlInputText endBuilTime;
        protected LinkButton lbtSearch;
        protected Repeater rp_Item;
        protected Paging Paging1;

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
            SqlWhere.Append("SELECT * from Base_SysAbnormalLog");
            if (this.BeginBuilTime.Value != "" || this.endBuilTime.Value != "")
            {
                SqlWhere.Append(" and SYS_AbnormaLog_TIME >= '" + CommonHelper.GetDateTime(this.BeginBuilTime.Value + "'"));
                SqlWhere.Append(" and SYS_AbnormaLog_TIME <= '" + CommonHelper.GetDateTime(this.endBuilTime.Value).AddDays(1.0) + "'");
            }
            if (this.txt_Search.Value != "")
            {
                SqlWhere.Append(" and User_Account = '" + this.txt_Search.Value + "'");
            }
            SqlWhere.Append(" ORDER BY SYS_AbnormaLog_TIME DESC ");
            Paging1.SqlPaging = SqlWhere.ToString();
            DataTable TB =Paging1.SqlPager().Copy();
            TB = Universal_ClassLibrary.DataTable.DataTabaleHanDle.ColumnToSizeWriting(TB.Copy(), Universal_ClassLibrary.SizeWriting.Upper).Copy();
            TB = Universal_ClassLibrary.DataTable.DataTableSort.DataTableSmartSort(TB.Copy(), "SYS_AbnormaLog_TIME", Universal_ClassLibrary.LiftingType.DESC).Copy();
            TB = Universal_ClassLibrary.DataTable.DataTableAddSequence.GetDataTable(TB.Copy(), "ROWNUM").Copy();
            TB.TableName = "Table";
            rp_Item.DataSource = TB.Copy();
            DataBind();
        }

        protected void rp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }
    }
}
