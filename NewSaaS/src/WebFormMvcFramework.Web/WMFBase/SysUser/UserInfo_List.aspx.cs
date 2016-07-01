using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines.DAL;
using WebFormMvcFramework.Busines.IDAO;
using WebFormMvcFramework.Common.DotNetCode;
using WebFormMvcFramework.Common.DotNetUI;
using WebFormMvcFramework.Web.App_Code;
using WebFormMvcFramework.Web.UserControl;

namespace WebFormMvcFramework.Web.WMFBase.SysUser
{
    public class UserInfo_List : PageBase
    {
        protected HtmlForm form1;
        protected HtmlSelect Searchwhere;
        protected HtmlInputText txt_Search;
        protected LinkButton lbtSearch;
        protected LoadButton LoadButton1;
        protected Repeater rp_Item;
        protected Paging Paging1;
        private string _Organization_ID;
        protected void Page_Load(object sender, EventArgs e)
        {
            this._Organization_ID = base.Request["Organization_ID"];
            Paging1.pageHandler += new EventHandler(this.pager_PageChanged);
            if (!base.IsPostBack)
            {
            }
        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }
        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("SELECT U.User_ID,U.User_Code,U.User_Name,U.User_Account,U.User_Sex,U.Title,U.DeleteMark,U.User_Remark,U.CreateDate from Base_UserInfo U LEFT JOIN Base_StaffOrganize S ON U.User_ID = S.User_ID where U.DeleteMark !=0");
            if (!string.IsNullOrEmpty(this.txt_Search.Value))
            {
                SqlWhere.Append(" and U." + this.Searchwhere.Value + " like  '%" + this.txt_Search.Value.Trim() + "%' ");
            }
            if (!string.IsNullOrEmpty(this._Organization_ID))
            {
                SqlWhere.Append(" AND S.Organization_ID IN(" + this._Organization_ID + ")");
            }
            SqlWhere.Append("GROUP BY U.User_ID,U.User_Code,U.User_Name,U.User_Account,U.User_Sex,U.Title,U.DeleteMark,U.User_Remark,U.CreateDate");
            Paging1.SqlPaging = SqlWhere.ToString(); ;
            rp_Item.DataSource = Paging1.SqlPager();
            rp_Item.DataBind();
        }
        protected void rp_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblUser_Sex = e.Item.FindControl("lblUser_Sex") as Label;
                Label lblDeleteMark = e.Item.FindControl("lblDeleteMark") as Label;
                if (lblUser_Sex != null)
                {
                    string text = lblUser_Sex.Text;
                    text = text.Replace("1", "男士");
                    text = text.Replace("0", "女士");
                    lblUser_Sex.Text = text;
                    string textDeleteMark = lblDeleteMark.Text;
                    textDeleteMark = textDeleteMark.Replace("1", "<span style='color:Blue'>启用</span>");
                    textDeleteMark = textDeleteMark.Replace("2", "<span style='color:red'>停用</span>");
                    lblDeleteMark.Text = textDeleteMark;
                }
            }
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }
    }
}