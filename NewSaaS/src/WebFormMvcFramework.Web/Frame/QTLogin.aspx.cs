using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetBean;

namespace WebFormMvcFramework.Web.Frame
{
    public partial class QTLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable SaaS_User = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_User where(u_user='" + TextBox1.Text + "' and u_pwd='" + TextBox2.Text + "')").Copy();
            if (SaaS_User.Rows.Count > 0)
            {
                RequestSession.AddSessionUser(new SessionUser
                {
                    UserId = SaaS_User.Rows[0]["u_guid"].ToString(),
                    UserAccount = SaaS_User.Rows[0]["u_user"].ToString(),
                    UserName = SaaS_User.Rows[0]["u_Name"].ToString(),
                    UserPwd = SaaS_User.Rows[0]["u_pwd"].ToString()
                });
                if (SaaS_User.Rows[0]["u_UserParent"].ToString() != "")
                {
                    HttpContext.Current.Session["u_UserParent"] = SaaS_User.Rows[0]["u_UserParent"].ToString();
                }
                else
                {
                    HttpContext.Current.Session["u_UserParent"] = SaaS_User.Rows[0]["u_guid"].ToString();
                }
                HttpContext.Current.Session["Roles_ID"] = "c70d20db-341e-4b7a-aef4-0f998ad5bbb3";
                Response.Write("<script>window.location.href ='../Frame/MainDefault.aspx'</script>");
            }
        }
    }
}