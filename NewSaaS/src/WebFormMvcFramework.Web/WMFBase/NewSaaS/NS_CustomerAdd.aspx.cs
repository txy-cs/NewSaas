using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using WebFormMvcFramework.Busines;
using WebFormMvcFramework.Common.DotNetUI;

namespace WebFormMvcFramework.Web.WMFBase.NewSaaS
{
    public partial class NS_CustomerAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable SaaS_CustomerType = DataFactory.SqlDataBase().ReturnDataTable("select * from SaaS_CustomerType").Copy();
                c_CustomerType.DataValueField = "c_guid";
                c_CustomerType.DataTextField = "c_name";
                c_CustomerType.DataSource = SaaS_CustomerType.Copy();
                c_CustomerType.DataBind();
            }
        }
        protected void Save_Click(object sender, EventArgs e)
        {
            StringBuilder SqlWhere = new StringBuilder();
            SqlWhere.Append("         INSERT INTO[dbo].[SaaS_Customer]   ");
            SqlWhere.Append("                  ([c_guid]  ");
            SqlWhere.Append("        ,[c_ContactPhone]   ");
            SqlWhere.Append("        ,[c_ContacTelephone]   ");
            SqlWhere.Append("         ,[c_CustomerName]  ");
            SqlWhere.Append("         ,[c_CustomerType]  ");
            SqlWhere.Append("        ,[c_CustomerNotes]   ");
            SqlWhere.Append("        ,[c_ClientUnit]   ");
            SqlWhere.Append("       ,[c_LicensePlateNumber]  ");
            SqlWhere.Append("         ,[c_BodyColor]  ");
            SqlWhere.Append("         ,[c_LatestMileage]  ");
            SqlWhere.Append("         ,[c_BuyingTime]  ");
            SqlWhere.Append("         ,[c_FrameNumberVINCode]   ");
            SqlWhere.Append("         ,[c_Models]   ");
            SqlWhere.Append("         ,[c_EngineModel]  ");
            SqlWhere.Append("         ,[c_EngineNumber]   ");
            SqlWhere.Append("         ,[c_NextMaintenance]  ");
            SqlWhere.Append("         ,[c_NextTimeMaintenance]   ");
            SqlWhere.Append("         ,[c_NextTime]   ");
            SqlWhere.Append("          ,[c_nextAnnualTime]  ");
            SqlWhere.Append("         ,[c_NextTimeInsurance]  ");
            SqlWhere.Append("          ,[c_insuranceCompany]   ");
            SqlWhere.Append("          ,[c_InsuranceNotes]   ");
            SqlWhere.Append("          ,[c_VehicleNotes]  ");
            SqlWhere.Append("         ,[u_guid]   ");
            SqlWhere.Append("        ,[c_CreationTime]   ");
            SqlWhere.Append("        ,[c_number])   ");
            SqlWhere.Append("     VALUES  ");
            SqlWhere.Append("          ('" + Guid.NewGuid().ToString() + "'  ");
            SqlWhere.Append("          ,'" + c_ContactPhone.Value + "'  ");
            SqlWhere.Append("          ,'" + c_ContacTelephone.Value + "'  ");
            SqlWhere.Append("          ,'" + c_CustomerName.Value + "'  ");
            SqlWhere.Append("          ,'" + c_CustomerType.SelectedItem.Value + "'  ");
            SqlWhere.Append("          ,'" + c_CustomerNotes.Value + "'  ");
            SqlWhere.Append("          ,'" + c_ClientUnit.Value + "'  ");
            SqlWhere.Append("          ,'" + c_LicensePlateNumber.Value + "'  ");
            SqlWhere.Append("          ,'" + c_BodyColor.Value + "'  ");
            SqlWhere.Append("          ,'" + c_LatestMileage.Value + "' ");
            SqlWhere.Append("          ,'" + c_BuyingTime.Value + "'  ");
            SqlWhere.Append("          ,'" + c_FrameNumberVINCode.Value + "'  ");
            SqlWhere.Append("          ,'" + c_Models.Value + "'  ");
            SqlWhere.Append("          ,'" + c_EngineModel.Value + "'   ");
            SqlWhere.Append("          ,'" + c_EngineNumber.Value + "'   ");
            SqlWhere.Append("          ,'" + c_NextMaintenance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTimeMaintenance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTime.Value + "'  ");
            SqlWhere.Append("          ,'" + c_nextAnnualTime.Value + "'  ");
            SqlWhere.Append("          ,'" + c_NextTimeInsurance.Value + "'  ");
            SqlWhere.Append("          ,'" + c_insuranceCompany.Value + "'  ");
            SqlWhere.Append("          ,'" + c_InsuranceNotes.Value + "'  ");
            SqlWhere.Append("        ,'" + c_VehicleNotes.Value + "' ");
            SqlWhere.Append("        , '" + HttpContext.Current.Session["u_UserParent"].ToString() + "' ");
            SqlWhere.Append("        ,'" + DateTime.Now.ToString() + "'   ");
            SqlWhere.Append("        ,'" + c_number.Value + "')  ");
            if (DataFactory.SqlDataBase().Affected(SqlWhere.ToString()) > 0)
            {
                ShowMsgHelper.AlertMsg("添加成功！");
            }
        }
    }
}